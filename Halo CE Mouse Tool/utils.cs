using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Principal; //For checking if user is running as admin
using System.Diagnostics;

namespace Halo_CE_Mouse_Tool {
    public class utils {
        SettingsHandler settings;
        MemoryHandler m;
        Mainform mainform;
        
        public utils (Mainform f) {
            mainform = f;
            settings = Mainform.settings;
            m = mainform.memoryhandler;
        }

        public void WriteHaloMemory() {
            byte[] mouseaccelnop = { 0x90, 0x90, 0x90, 0x90, 0x90, 0x90 };
            int return_value;
            int curr_addr = 0;
            byte[] curr_val = { };
            for (int i = 0; i != 4; i++) {
                if (i == 0) {
                    curr_val = BitConverter.GetBytes(settings.SensX);
                    curr_addr = 0x2ABB50;
                }
                if (i == 1) {
                    curr_val = BitConverter.GetBytes(settings.SensY);
                    curr_addr = 0x2ABB54;
                }
                if (i == 2 && settings.PatchAcceleration == 1) {
                    curr_val = mouseaccelnop;
                    curr_addr = 0x8F836;
                }
                if (i == 3 && settings.PatchAcceleration == 1) {
                    curr_val = mouseaccelnop;
                    curr_addr = 0x8F830;
                }
                return_value = m.WriteToProcessMemory("haloce", curr_val, curr_addr);
                if (return_value != 0) {
                    sound_error();
                    if (return_value == 1) {
                        MessageBox.Show("Access Denied. Are you running the tool as Admin?");
                    } else {
                        MessageBox.Show("One or more values failed to write. Error code " + return_value);
                    }
                }
            }
            sound_success();
            MessageBox.Show("Successfully wrote values to memory.");
        }

        public void HandleXML() {
            int loadxml = Mainform.xmlhandler.LoadSettingsFromXML(settings);
            if (loadxml == 1) {
                sound_success();
                MessageBox.Show("Successfully found & Read XML.");
            } else if (loadxml == 2 || loadxml == 3) {
                sound_error();
                MessageBox.Show("An XML file was found, but an error occurred whilst reading it. It is possible one or more settings were not set. They have been set to default.");
            } else {
                sound_notice();
                MessageBox.Show("Didn't find an XML file. Will now generate one with default values...");
                Mainform.xmlhandler.GenerateXML();
                Mainform.xmlhandler.LoadSettingsFromXML(settings);
            }
        }

        public bool IsAdministrator() {
            return (new WindowsPrincipal(WindowsIdentity.GetCurrent()))
                      .IsInRole(WindowsBuiltInRole.Administrator);
        }

        public void parse_sensitivity(TextBox origin, char sens) {
            float conv_float;
            if (origin.Text != "") {
                if (!float.TryParse(origin.Text, out conv_float)) {
                    origin.Text = "0";
                    MessageBox.Show("Invalid input. Only numbers allowed.");
                } else {
                    if (sens == 'x') {
                        settings.SensX = conv_float;
                    } else {
                        settings.SensY = conv_float;
                    }
                }
            }
        }

        public void check_if_blank(TextBox origin) {
            if (origin.Text == "") {
                origin.Focus();
                MessageBox.Show("Error: You can't leave this field blank.");
            }
        }

        public void CheckForUpdates() {
            int res = mainform.updatehandler.CheckForUpdates();
            if (res == 2) {
                sound_error();
                MessageBox.Show("An error occurred while checking for updates.");
            } else {
                sound_notice();
                if (res == 0) {
                    MessageBox.Show("No updates were found.");
                } else {
                    DialogResult d = MessageBox.Show("An Update is Available. Would you like to visit the downloads page?", "Update Found", MessageBoxButtons.YesNo);
                    if (d == DialogResult.Yes) {
                        Process.Start("https://github.com/AWilliams17/Halo-CE-Mouse-Tool/releases");
                    }
                }
            }
        }

        public void sound_success() {
            if (settings.SoundsEnabled == 1) {
                mainform.success.Play();
            }
        }

        public void sound_error() {
            if (settings.SoundsEnabled == 1) {
                mainform.error.Play();
            }
        }

        public void sound_notice() {
            if (settings.SoundsEnabled == 1) {
                mainform.notice.Play();
            }
        }
        
        public void keybind_handle() {
            if (Mainform.keybindhandler.KeybindsEnabled && settings.HotkeyEnabled == 1) {
                if (KeybindHandler.IsKeyPushedDown((Keys)Enum.Parse(typeof(Keys), settings.Hotkey))) {
                    WriteHaloMemory();
                }
            }
        }
    }
}
