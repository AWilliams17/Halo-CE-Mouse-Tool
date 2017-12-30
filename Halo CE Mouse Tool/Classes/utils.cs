using System;
using System.Windows.Forms;
using System.Security.Principal; //For checking if user is running as admin
using System.IO;
using System.Threading;
using System.Diagnostics;

namespace Halo_CE_Mouse_Tool
{
    /*
            -utils.cs-
        This class contains code originally in mainform.cs which bloated the shit out of it.
        Very bloated and hideous. Better than it was before tho.
    */
    public static class Utils
    {
        public static void WriteHaloMemory(SettingsHandler settings)
        { //Calls WriteMemory with selected settings.
            byte[] mouseaccelnop = { 0x90, 0x90, 0x90, 0x90, 0x90, 0x90 }; //For noping the acceleration
            int currAddr = 0;
            byte[] currVal = { };
            int returnValue = 0;
            for (int i = 0; i != 4; i++)
            {
                if (i == 0)
                {
                    currVal = BitConverter.GetBytes((settings.SensX * 0.25F));
                    currAddr = 0x2ABB50;
                }
                if (i == 1)
                {
                    currVal = BitConverter.GetBytes((settings.SensY * 0.25F));
                    currAddr = 0x2ABB54;
                }
                if (i == 2 && settings.PatchAcceleration == 1)
                {
                    currVal = mouseaccelnop;
                    currAddr = 0x8F836;
                }
                if (i == 3 && settings.PatchAcceleration == 1)
                {
                    currVal = mouseaccelnop;
                    currAddr = 0x8F830;
                }
                returnValue = MemoryHandler.WriteToProcessMemory("haloce", currVal, currAddr);
                if (returnValue != 0)
                {
                    SoundHandler.sound_error(settings);
                    if (returnValue == 1)
                    {
                        throw new UnauthorizedAccessException();
                    }
                    else
                    {
                        throw new SystemException();
                    }
                }
            }
        }

        public static void LoadSettings(SettingsHandler settings, int context) //Pass the context so if I need to call SerializeSettings, I will have something to pass it.
        { //For loading settings from the XML file.
            SettingsHandler loadedSettings = XmlHandler.DeSerialize_Settings();
            if (loadedSettings == null && XmlHandler.XmlExists())
            {
                throw new FileLoadException();
            }
            else if (loadedSettings == null)
            {
                throw new FileNotFoundException();
            }
            else
            {
                settings.SensX = loadedSettings.SensX;
                settings.SensY = loadedSettings.SensY;
                settings.PatchAcceleration = loadedSettings.PatchAcceleration;
                settings.Hotkey = loadedSettings.Hotkey;
                settings.HotkeyEnabled = loadedSettings.HotkeyEnabled;
                settings.SoundsEnabled = loadedSettings.SoundsEnabled;
                settings.CheckForUpdatesOnStart = loadedSettings.CheckForUpdatesOnStart;
                settings.HideKeybindSuccessMsg = loadedSettings.HideKeybindSuccessMsg;
                settings.UpdateTimeout = loadedSettings.UpdateTimeout;
                settings.IncrementSens = loadedSettings.IncrementSens;
                settings.IncrementAmount = loadedSettings.IncrementAmount;
            }
        }

        public static void GenerateXML() //Generate a new XML file
        {
            FileInfo fi = new FileInfo(XmlHandler.XmlPath);
            if (fi.IsReadOnly && IsAdministrator()) //If the file is readonly for some reason, that will cause an unauthorizedaccessexception.
            {
                File.SetAttributes(XmlHandler.XmlPath, File.GetAttributes(XmlHandler.XmlPath) & ~FileAttributes.ReadOnly); //So make it not readonly.
                                                                                                                           //Since the application must be run as admin in order to set attributes, I check for that.
            }
            File.Delete(XmlHandler.XmlPath);
        }

        /*
            If the context passed is 1, then the caller was the on_exit function, and I will ignore the exceptions to let it close gracefully.
            If the context passed is 2, then the caller was the load settings function, and I will tell the user an error occured generating a new config.
        */
        public static void SaveSettings(SettingsHandler settings, int context)
        {
            int saveSettings = XmlHandler.Serialize_Settings(settings);
            if (context == 1 && saveSettings != 1)
            {
                XmlHandler.Serialize_Settings(settings); //If an exception occurs, ignore it and exit.
            }
            else if (context == 2 && saveSettings != 1)
            {
                throw new AccessViolationException();
            }
        }

        public static bool IsAdministrator()
        { //Detects if the user is admin or not (dur)
            return (new WindowsPrincipal(WindowsIdentity.GetCurrent()))
                      .IsInRole(WindowsBuiltInRole.Administrator);
        }

        public static void Parse_Sensitivity(TextBox origin, char sens, SettingsHandler settings)
        { //For performing validation on the sensitivity text boxes.
            if (origin.Text != "")
            {
                if (sens == 'x')
                { //If the sensitivity value is the x one or y one.
                    settings.SensX = float.Parse(origin.Text);
                }
                else
                {
                    settings.SensY = float.Parse(origin.Text);
                }
            }
        }

        public static void DeployDLL()
        {
            using (var fbd = new FolderBrowserDialog())
            {
                string description =
                    "Select the Halo CE/SPV3 Controls directory." + Environment.NewLine +
                    "If you wish to only use this for SPV3, you just have to select SPV3's control directory. " +
                    "If you want to use it for Halo CE, select Halo CE's control directory." +
                    "For reference, this folder will have a dll in it called 'controls.dll'.";
                fbd.ShowNewFolderButton = false;
                fbd.Description = description;
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    bool validselection = false; string[] files = Directory.GetFiles(fbd.SelectedPath);
                    for (int i = 0; i < files.Length; i++)
                    {
                        if (files[i].ToLower().Contains("controls.dll"))
                        {
                            validselection = true;
                            break;
                        }
                    }
                    if (validselection)
                    {
                        string dllsettings = Path.Combine(fbd.SelectedPath, "DLL Settings.exe");
                        string dll = Path.Combine(fbd.SelectedPath, "HaloMouseFix.dll");
                        File.WriteAllBytes(dllsettings, Properties.Resources.DLL_Settings);
                        File.WriteAllBytes(dll, Properties.Resources.DLL_Settings);
                    }
                    else
                    {
                        throw new FileNotFoundException();
                    }
                }
            }
        }

        public static void CheckForUpdates(SettingsHandler settings)
        { //For checking for updates...
            Thread update_thread = new Thread(() =>
            {
                int res = UpdateHandler.CheckForUpdates(settings.UpdateTimeout);
                if (res == 2)
                {
                    SoundHandler.sound_error(settings);
                    MessageBox.Show("An error occurred while checking for updates(Timeout?)", "Update timeout/error");
                }
                else
                {
                    SoundHandler.sound_notice(settings);
                    if (res == 0)
                    {
                        MessageBox.Show("No updates were found.", "No updates needed");
                    }
                    else
                    {
                        DialogResult d = MessageBox.Show("An Update is Available. Would you like to visit the downloads page?", "Update Found", MessageBoxButtons.YesNo);
                        if (d == DialogResult.Yes)
                        {
                            Process.Start("https://github.com/AWilliams17/Halo-CE-Mouse-Tool/releases");
                        }
                    }
                }
            });
            update_thread.IsBackground = true;
            update_thread.Start();
        }
    }
}
