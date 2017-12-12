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
    public static class utils
    {
        public static void WriteHaloMemory(SettingsHandler settings, int hide_messages)
        { //Calls WriteMemory with selected settings.
            byte[] mouseaccelnop = { 0x90, 0x90, 0x90, 0x90, 0x90, 0x90 }; //For noping the acceleration
            int return_value;
            int curr_addr = 0;
            byte[] curr_val = { };
            for (int i = 0; i != 4; i++)
            {
                if (i == 0)
                {
                    curr_val = BitConverter.GetBytes(settings.SensX);
                    curr_addr = 0x2ABB50;
                }
                if (i == 1)
                {
                    curr_val = BitConverter.GetBytes(settings.SensY);
                    curr_addr = 0x2ABB54;
                }
                if (i == 2 && settings.PatchAcceleration == 1)
                {
                    curr_val = mouseaccelnop;
                    curr_addr = 0x8F836;
                }
                if (i == 3 && settings.PatchAcceleration == 1)
                {
                    curr_val = mouseaccelnop;
                    curr_addr = 0x8F830;
                }
                return_value = MemoryHandler.WriteToProcessMemory("haloce", curr_val, curr_addr);
                if (return_value != 0)
                {
                    SoundHandler.sound_error(settings);
                    if (return_value == 1)
                    {
                        MessageBox.Show("Access Denied. Are you running the tool as Admin?");
                    }
                    else {
                        MessageBox.Show("One or more values failed to write. Error code " + return_value);
                    }
                }
            }
            SoundHandler.sound_success(settings);
            if (hide_messages == 0)
            {
                MessageBox.Show("Successfully wrote values to memory.");
            }
        }

        //This method is kind of... yea... might wanna try to shorten this.
        public static void LoadSettings(SettingsHandler settings, int context) //Pass the context so if I need to call SerializeSettings, I will have something to pass it.
        { //For loading settings from the XML file.
            SettingsHandler loaded_settings = XMLHandler.DeSerialize_Settings();
            if (loaded_settings == null)
            {
                SoundHandler.sound_error(settings);
                if (!XMLHandler.XMLExists())
                {
                    MessageBox.Show("I did not find an XML config file. A new one will be generated with default values.");
                }
                else
                {
                    MessageBox.Show("An XML config file was found, but I failed to load it properly. It is possible it is damaged. A new one will be generated.");
                    FileInfo fi = new FileInfo(XMLHandler.XMLPath);
                    if (fi.IsReadOnly && IsAdministrator()) //If the file is readonly for some reason, that will cause an unauthorizedaccessexception.
                    {
                        File.SetAttributes(XMLHandler.XMLPath, File.GetAttributes(XMLHandler.XMLPath) & ~FileAttributes.ReadOnly); //So make it not readonly.
                        //Since the application must be run as admin in order to set attributes, I check for that.
                    }
                    try
                    {
                        File.Delete(XMLHandler.XMLPath);
                    }
                    catch (UnauthorizedAccessException)
                    {
                        string err_text = "An error occurred whilst attempting to delete the corrupt config file. ";
                        if (!IsAdministrator()) //If the user isn't an administrator, then the file might be set to readonly.
                        {
                            MessageBox.Show(err_text + "You are not running as administrator, so it's possible I do not have permission to access the file. Please re-run the tool as admin.");
                            Application.Exit(); //Exit the tool so the user can re-run as admin. Really not much else I can do.
                        }
                    }
                }
                SaveSettings(settings, 2); //Try to generate a new config. Since I am calling from loadsettings, pass 2 to the context arg.
            }
            else
            {
                settings.setSensX(loaded_settings.SensX);
                settings.setSensY(loaded_settings.SensY);
                settings.setPatchAcceleration(loaded_settings.PatchAcceleration);
                settings.Hotkey = loaded_settings.Hotkey;
                settings.setHotKeyEnabled(loaded_settings.HotkeyEnabled);
                settings.setSoundsEnabled(loaded_settings.SoundsEnabled);
                settings.setCheckForUpdates(loaded_settings.CheckForUpdatesOnStart);
                settings.setHideKeybindSuccessMsg(loaded_settings.HideKeybindSuccessMsg);
                settings.setUpdateTimeout(loaded_settings.UpdateTimeout);
                settings.setIncrementSens(loaded_settings.IncrementSens);
                settings.setIncrementAmount(loaded_settings.IncrementAmount);
                SoundHandler.sound_success(settings);
                MessageBox.Show("Successfully loaded the XML file.");
            }
        }

        /*
            If the context passed is 1, then the caller was the on_exit function, and I will ignore the exceptions to let it close gracefully.
            If the context passed is 2, then the caller was the load settings function, and I will tell the user an error occured generating a new config.
        */
        public static void SaveSettings(SettingsHandler settings, int context)
        { //For saving settings to the XML file.
            int save_settings = XMLHandler.Serialize_Settings(settings); //Return 1 for success, 0 on unauthorized access exception.
            if (context == 1 && save_settings != 1)
            {
                save_settings = XMLHandler.Serialize_Settings(settings); //If an exception occurs, ignore it and exit.
            }
            else if (context == 2 && save_settings != 1)
            {
                SoundHandler.sound_error(settings);
                MessageBox.Show("An access violation occurred whilst generating a new configuration file. Are you running as admin?");
            }
        }

        public static bool IsAdministrator()
        { //Detects if the user is admin or not (dur)
            return (new WindowsPrincipal(WindowsIdentity.GetCurrent()))
                      .IsInRole(WindowsBuiltInRole.Administrator);
        }

        public static void parse_sensitivity(TextBox origin, char sens, SettingsHandler settings)
        { //For performing validation on the sensitivity text boxes.
            float conv_float;
            if (origin.Text != "")
            {
                if (!float.TryParse(origin.Text, out conv_float))
                {
                    origin.Text = "0";
                    SoundHandler.sound_error(settings);
                    MessageBox.Show("Invalid input. Only numbers allowed.");
                }
                else {
                    if (sens == 'x')
                    { //If the sensitivity value is the x one or y one.
                        settings.setSensX(float.Parse(origin.Text));
                    }
                    else {
                        settings.setSensY(float.Parse(origin.Text));
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
                MessageBox.Show("Error: You can't leave this field blank.");
            }
        }

        public static void CheckForUpdates(SettingsHandler settings)
        { //For checking for updates...
            Thread update_thread = new Thread(() => {
                int res = UpdateHandler.CheckForUpdates(settings.UpdateTimeout);
                if (res == 2)
                {
                    SoundHandler.sound_error(settings);
                    MessageBox.Show("An error occurred while checking for updates(Timeout?)");
                }
                else {
                    SoundHandler.sound_notice(settings);
                    if (res == 0)
                    {
                        MessageBox.Show("No updates were found.");
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
                    float SensX = settings.SensX;
                    float SensY = settings.SensY;
                    float res = SensX + settings.IncrementAmount;
                    float res2 = SensY + settings.IncrementAmount;
                    if (res > 12 || res2 > 12) //Don't increase sensitivity if it will make it go above 12.
                    {
                        SoundHandler.sound_error(settings);
                    }
                    else
                    {
                        settings.setSensX(SensX += settings.IncrementAmount);
                        settings.setSensY(SensY += settings.IncrementAmount);
                        WriteHaloMemory(settings, 1);
                        sensXText.Text = settings.SensX.ToString();
                        sensYText.Text = settings.SensY.ToString();
                    }
                }
                else if (KeybindHandler.IsKeyPushedDown(Keys.OemMinus))
                {
                    float SensX = settings.SensX;
                    float SensY = settings.SensY;
                    float res = SensX - settings.IncrementAmount;
                    float res2 = SensY - settings.IncrementAmount;
                    if (res <= 0 || res2 <= 0) //Don't decrease the sensitivity if it will make it drop below 0.
                    {
                        SoundHandler.sound_error(settings);
                    }
                    else
                    {
                        settings.setSensX(SensX -= settings.IncrementAmount);
                        settings.setSensY(SensY -= settings.IncrementAmount);
                        WriteHaloMemory(settings, 1);
                        sensXText.Text = settings.SensX.ToString();
                        sensYText.Text = settings.SensY.ToString();
                    }
                }
            }
        }
    }
}
