using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Principal; //For checking if user is running as admin

namespace Halo_CE_Mouse_Tool {
    public partial class Mainform : Form {
        public ProcessHandler processhandler = new ProcessHandler();
        public UpdateHandler updatehandler = new UpdateHandler();
        public static KeybindHandler keybindhandler = new KeybindHandler();
        public FormHandler formhandler = new FormHandler();
        static MemoryHandler memoryhandler = new MemoryHandler();
        public static SettingsHandler settings = new SettingsHandler();

        static SettingsForm settingsform;
        static DonateForm donateform;

        public static bool IsAdministrator() {
            return (new WindowsPrincipal(WindowsIdentity.GetCurrent()))
                      .IsInRole(WindowsBuiltInRole.Administrator);
        }

        public Mainform() {
            InitializeComponent();
            AppDomain.CurrentDomain.ProcessExit += new EventHandler(OnProcessExit);

            string window_title = "Halo CE Mouse Tool v" + updatehandler.GetVersion().ToString();
            if (!IsAdministrator()) {
                window_title += " -NOT ADMIN-";
                MessageBox.Show("Warning - You must run this tool as an administrator in order for it to work properly.");
            }
            this.Text = window_title;
        }

        private void Mainform_Load(object sender, EventArgs e) {
            int loadxml = settings.LoadSettingsFromXML();
            if (loadxml == 1) {
                MessageBox.Show("Successfully found & Read XML.");
            } else {
                MessageBox.Show("Didn't find an XML file. Will now generate one with default values...");
                settings.GenerateXML();
                settings.LoadSettingsFromXML();
            }

            if (settings.CheckForUpdatesOnStart() == 1) {
                updatehandler.CheckForUpdates();
            }

            SensX.Text = settings.GetSensX().ToString();
            SensY.Text = settings.GetSensY().ToString();
        }

        private void ActivateBtn_Click_1(object sender, EventArgs e) {
            WriteHaloMemory();
        }

        private void StatusLabelTimer_Tick(object sender, EventArgs e) {
            if (processhandler.ProcessIsRunning("HALOCE")) {
                StatusLabel.Text = "Halo CE Process found.";
                StatusLabel.ForeColor = Color.Green;
                ActivateBtn.Enabled = true;
                keybindhandler.EnableKeybinds();
            } else {
                StatusLabel.Text = "Halo CE Process not found.";
                StatusLabel.ForeColor = Color.Red;
                ActivateBtn.Enabled = false;
                keybindhandler.SuspendKeybinds();
            }
        }

        private void SettingsBtn_Click(object sender, EventArgs e) {
            if (formhandler.formopen(settingsform)) {
                settingsform.Show();
            } else {
                settingsform = new SettingsForm(this);
                settingsform.Show();
            }
        }

        private void DonateLink_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e) {
            if (formhandler.formopen(donateform)) {
                donateform.Show();
            } else {
                donateform = new DonateForm();
                donateform.Show();
            }
        }

        public static int WriteHaloMemory() {
            byte[] mouseaccelnop = { 0x90, 0x90, 0x90, 0x90, 0x90, 0x90 };
            int return_value;
            int curr_addr = 0;
            byte[] curr_val = { };
            for (int i = 0; i != 4; i++) {
                if (i == 0) {
                    curr_val = BitConverter.GetBytes(settings.GetSensX());
                    curr_addr = 0x2ABB50;
                }
                if (i == 1) {
                    curr_val = BitConverter.GetBytes(settings.GetSensY());
                    curr_addr = 0x2ABB54;
                }
                if (i == 2 && settings.GetPatchAcceleration() == 1) {
                    curr_val = mouseaccelnop;
                    curr_addr = 0x8F836;
                }
                if (i == 3 && settings.GetPatchAcceleration() == 1) {
                    curr_val = mouseaccelnop;
                    curr_addr = 0x8F830;
                }
                return_value = memoryhandler.WriteToProcessMemory("haloce", curr_val, curr_addr);
                if (return_value != 0) {
                    if (return_value == 1) {
                        MessageBox.Show("Access Denied. Are you running the tool as an admin?");
                        return 1;
                    } else {
                        MessageBox.Show("One or more values failed to write. Error code: " + return_value.ToString());
                        return return_value;
                    }
                } else if (i == 3 && return_value == 0) {
                    MessageBox.Show("Successfully wrote sensitivity values to memory.");
                }
            }
            return 0;
        }

        private void GithubLink_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e) {
            Process.Start("https://github.com/AWilliams17/Halo-CE-Mouse-Tool");
        }

        private void RedditLink_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e) {
            Process.Start("https://www.reddit.com/r/halospv3/comments/6aoxu0/halo_ce_mouse_tool_released_fine_tune_your_mouse/");
        }

        private void HotkeyLabelTimer_Tick(object sender, EventArgs e) {
            if (settings.GetHotkeyEnabled() == 1 && settings.GetHotkey() != null) {
                HotkeyStatus.Text = "Keybind is set to: " + settings.GetHotkey();
            } else {
                HotkeyStatus.Text = "Keybind is disabled/not set.";
            }
        }

        private void SensX_TextChanged(object sender, EventArgs e) {
            settings.SetSensX(float.Parse(SensX.Text));
        }

        private void SensY_TextChanged(object sender, EventArgs e) {
            settings.SetSensY(float.Parse(SensY.Text));
        }

        static void OnProcessExit(object sender, EventArgs e) {
            settings.WriteXML();
        }

        private void HotkeyTimer_Tick(object sender, EventArgs e) {
            if (keybindhandler.GetKeybindStatus() && settings.GetHotkeyEnabled() == 1) {
                if (KeybindHandler.IsKeyPushedDown((Keys)Enum.Parse(typeof(Keys), settings.GetHotkey()))) {
                    if (WriteHaloMemory() == 0) {
                        System.Media.SystemSounds.Beep.Play();
                    } else {
                        System.Media.SystemSounds.Exclamation.Play();
                    }
                }
            }
        }
    }
}
