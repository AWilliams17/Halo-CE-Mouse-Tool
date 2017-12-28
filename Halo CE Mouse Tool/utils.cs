using System;
using System.Windows.Forms;
using System.Security.Principal; //For checking if user is running as admin
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace Halo_CE_Mouse_Tool
{
    /*
            -utils.cs-
        This class contains code originally in mainform.cs which bloated the shit out of it.
        Very bloated and hideous. Better than it was before tho.
    */
    public static class Utils
    {
        public static void WriteHaloMemory(SettingsHandler settings, int hideMessages)
        { //Calls WriteMemory with selected settings.
            byte[] mouseaccelnop = { 0x90, 0x90, 0x90, 0x90, 0x90, 0x90 }; //For noping the acceleration
            int currAddr = 0;
            byte[] currVal = { };
            for (int i = 0; i != 4; i++)
            {
                if (i == 0)
                {
                    currVal = BitConverter.GetBytes((settings.SensX *= 0.25F));
                    currAddr = 0x2ABB50;
                }
                if (i == 1)
                {
                    currVal = BitConverter.GetBytes((settings.SensY *= 0.25F));
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
                int returnValue = MemoryHandler.WriteToProcessMemory("haloce", currVal, currAddr);
                if (returnValue != 0)
                {
                    string returnMsg;
                    SoundHandler.sound_error(settings);
                    if (returnValue == 1)
                    {
                        returnMsg = "Access Denied. Are you running the tool as Admin?";
                    }
                    else
                    {
                        returnMsg = "One or more values failed to write. Error code " + returnValue;
                    }
                    MessageBox.Show(returnMsg, "Failed to write");
                }
            }
            SoundHandler.sound_success(settings);
            if (hideMessages == 0)
            {
                MessageBox.Show("Successfully wrote values to memory.", "Successfully wrote to memory");
            }
        }

        //This method is kind of... yea... might wanna try to shorten this.
        public static void LoadSettings(SettingsHandler settings, int context) //Pass the context so if I need to call SerializeSettings, I will have something to pass it.
        { //For loading settings from the XML file.
            SettingsHandler loadedSettings = XmlHandler.DeSerialize_Settings();
            if (loadedSettings == null)
            {
                SoundHandler.sound_error(settings);
                string dialogResult;
                if (!XmlHandler.XmlExists())
                {
                    dialogResult = "I did not find an XML config file. A new one will be generated with default values.";
                    MessageBox.Show(dialogResult, "XML does not exist");
                }
                else
                {
                    dialogResult = "An XML config file was found, but I failed to load it properly. It is possible it is damaged. A new one will be generated.";
                    MessageBox.Show(dialogResult, "Failed to load XML");
                    FileInfo fi = new FileInfo(XmlHandler.XmlPath);
                    if (fi.IsReadOnly && IsAdministrator()) //If the file is readonly for some reason, that will cause an unauthorizedaccessexception.
                    {
                        File.SetAttributes(XmlHandler.XmlPath, File.GetAttributes(XmlHandler.XmlPath) & ~FileAttributes.ReadOnly); //So make it not readonly.
                        //Since the application must be run as admin in order to set attributes, I check for that.
                    }
                    try
                    {
                        File.Delete(XmlHandler.XmlPath);
                    }
                    catch (UnauthorizedAccessException)
                    {
                        const string errText = "An error occurred whilst attempting to delete the corrupt config file. ";
                        const string errTextDeletion = errText + "You are not running as administrator, so it's possible I do not have permission to access the file. Please re-run the tool as admin.";
                        if (!IsAdministrator()) //If the user isn't an administrator, then the file might be set to readonly.
                        {
                            MessageBox.Show(errTextDeletion, "Not running as Admin");
                            Application.Exit(); //Exit the tool so the user can re-run as admin. Really not much else I can do.
                        }
                    }
                }
                SaveSettings(settings, 2); //Try to generate a new config. Since I am calling from loadsettings, pass 2 to the context arg.
            }
            else
            {
                string dialogResult;
                try
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
                    SoundHandler.sound_success(settings);
                    dialogResult = "Successfully loaded the XML file.";
                }
                catch (Exception ex)
                {
                    SoundHandler.sound_error(settings);
                    if (ex is ArgumentException || ex is ArgumentOutOfRangeException)
                    {
                        dialogResult = "An error occurred whilst loading the settings file: One or more values were not set correctly. Did you manually edit the file? These settings have been set to their defaults.";
                    }
                    else
                    {
                        dialogResult = "An error occurred whilst loading the settings file: Unspecified error. Possible malformation of config file. Settings that failed to load have been set back to their defaults.";
                    }
                }
                MessageBox.Show(dialogResult, "Result");
            }
        }

        /*
            If the context passed is 1, then the caller was the on_exit function, and I will ignore the exceptions to let it close gracefully.
            If the context passed is 2, then the caller was the load settings function, and I will tell the user an error occured generating a new config.
        */
        public static void SaveSettings(SettingsHandler settings, int context)
        { //For saving settings to the XML file.
            string adminError = "An access violation occurred whilst generating a new configuration file. Are you running as admin?";
            int saveSettings = XmlHandler.Serialize_Settings(settings); //Return 1 for success, 0 on unauthorized access exception.
            if (context == 1 && saveSettings != 1)
            {
                XmlHandler.Serialize_Settings(settings); //If an exception occurs, ignore it and exit.
            }
            else if (context == 2 && saveSettings != 1)
            {
                SoundHandler.sound_error(settings);
                MessageBox.Show(adminError, "Access Violation");
            }
        }

        public static bool IsAdministrator()
        { //Detects if the user is admin or not (dur)
            return (new WindowsPrincipal(WindowsIdentity.GetCurrent()))
                      .IsInRole(WindowsBuiltInRole.Administrator);
        }

        public static void parse_sensitivity(TextBox origin, char sens, SettingsHandler settings)
        { //For performing validation on the sensitivity text boxes.
            if (origin.Text != "")
            {
                float conv_float;
                string BelowZeroErrorMsg = "Error: Sensitivities can not go below 0.";
                string OnlyNumbersMsg = "Invalid input. Only numbers allowed.";
                if (!float.TryParse(origin.Text, out conv_float))
                {
                    origin.Text = "0";
                    SoundHandler.sound_error(settings);
                    MessageBox.Show(OnlyNumbersMsg, "Error - Only numbers allowed!");
                }
                else {
                    if (sens == 'x')
                    { //If the sensitivity value is the x one or y one.
                        try
                        {
                            settings.SensX = float.Parse(origin.Text);
                        }
                        catch (ArgumentOutOfRangeException)
                        {
                            MessageBox.Show(BelowZeroErrorMsg, "Error - Can't be below zero!");
                        }
                    }
                    else
                    {
                        try
                        {
                            settings.SensY = float.Parse(origin.Text);
                        }
                        catch (ArgumentOutOfRangeException)
                        {
                            MessageBox.Show(BelowZeroErrorMsg, "Error - Can't be below zero!");
                        }
                    }
                }
            }
        }

        public static void check_if_blank(TextBox origin, SettingsHandler settings)
        { //Check if the sensitivity textbox is blank or not. Prevent user from leaving if it is.
            if (origin.Text == "")
            {
                origin.Focus();
                SoundHandler.sound_error(settings);
                MessageBox.Show("Error: You can't leave this field blank.", "Field can not be blank!");
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
                else {
                    SoundHandler.sound_notice(settings);
                    if (res == 0)
                    {
                        MessageBox.Show("No updates were found.", "No updates needed");
                    }
                    else {
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
        public static void keybind_handle(SettingsHandler settings, TextBox sensXText, TextBox sensYText)
        { //Detects if the hotkey is pressed or not. IDK if there's a better way of doing this or not.
            if (KeybindHandler.KeybindsEnabled && settings.HotkeyEnabled == 1)
            {
                if (KeybindHandler.IsKeyPushedDown((Keys)Enum.Parse(typeof(Keys), settings.Hotkey)))
                {
                    WriteHaloMemory(settings, settings.HideKeybindSuccessMsg);
                }
            }
            if (settings.IncrementSens == 1 && KeybindHandler.KeybindsEnabled)
            {
                if (KeybindHandler.IsKeyPushedDown(Keys.Oemplus))
                {
                    try
                    {
                        settings.SensX = settings.SensX += settings.IncrementAmount;
                        settings.SensY = settings.SensY += settings.IncrementAmount;
                        WriteHaloMemory(settings, 1);
                        sensXText.Text = settings.SensX.ToString();
                        sensYText.Text = settings.SensY.ToString();
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        SoundHandler.sound_error(settings);
                    }
                }

                else if (KeybindHandler.IsKeyPushedDown(Keys.OemMinus))
                {
                    try
                    {
                        settings.SensX = settings.SensX -= settings.IncrementAmount;
                        settings.SensY = settings.SensY -= settings.IncrementAmount;
                        WriteHaloMemory(settings, 1);
                        sensXText.Text = settings.SensX.ToString();
                        sensYText.Text = settings.SensY.ToString();
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        SoundHandler.sound_error(settings);
                    }
                }
            }
        }
    }
}
