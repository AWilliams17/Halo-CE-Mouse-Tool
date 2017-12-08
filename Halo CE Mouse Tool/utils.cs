using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Principal; //For checking if user is running as admin
using System.Diagnostics;
using System.Media;
using System.IO;

namespace Halo_CE_Mouse_Tool
{
    /*
            -utils.cs-
        This class contains code originally in mainform.cs which bloated the shit out of it.
        Very bloated and hideous. Better than it was before tho.
    */
    public static class utils
    {
        public static void WriteHaloMemory(SettingsHandler settings)
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
            MessageBox.Show("Successfully wrote values to memory.");
        }

        public static void LoadSettings(SettingsHandler settings)
        { //For loading settings from the XML file.
            SettingsHandler loaded_settings = XMLHandler.DeSerialize_Settings();
            settings.SensX = loaded_settings.SensX;
            settings.SensY = loaded_settings.SensY;
            settings.PatchAcceleration = loaded_settings.PatchAcceleration;
            settings.Hotkey = loaded_settings.Hotkey;
            settings.HotkeyEnabled = loaded_settings.HotkeyEnabled;
            settings.SoundsEnabled = loaded_settings.SoundsEnabled;
            settings.CheckForUpdatesOnStart = loaded_settings.CheckForUpdatesOnStart;
        }

        public static void SaveSettings(SettingsHandler settings)
        { //For saving settings to the XML file.
            XMLHandler.Serialize_Settings(settings);
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
                        settings.SensX = float.Parse(origin.Text);
                    }
                    else {
                        settings.SensY = float.Parse(origin.Text);
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
            int res = UpdateHandler.CheckForUpdates();
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
        }
        public static void keybind_handle(SettingsHandler settings)
        { //Detects if the hotkey is pressed or not. IDK if there's a better way of doing this or not.
            if (KeybindHandler.KeybindsEnabled && settings.HotkeyEnabled == 1)
            {
                if (KeybindHandler.IsKeyPushedDown((Keys)Enum.Parse(typeof(Keys), settings.Hotkey)))
                {
                    WriteHaloMemory(settings);
                }
            }
        }
    }
}
