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
using System.IO;
using System.Media;

namespace Halo_CE_Mouse_Tool {
    public partial class Mainform : Form {
        public ProcessHandler processhandler = new ProcessHandler();
        public UpdateHandler updatehandler = new UpdateHandler();
        public FormHandler formhandler = new FormHandler();
        static MemoryHandler memoryhandler = new MemoryHandler();
        public static SettingsHandler settings = new SettingsHandler();
        public static KeybindHandler keybindhandler = new KeybindHandler();
        public static XMLHandler xmlhandler = new XMLHandler();

        static Stream success_file = Properties.Resources.SND_Success;
        static Stream notice_file = Properties.Resources.SND_Notice;
        static Stream error_file = Properties.Resources.SND_Error;
        public SoundPlayer success = new System.Media.SoundPlayer(success_file);
        public SoundPlayer notice = new System.Media.SoundPlayer(notice_file);
        public SoundPlayer error = new System.Media.SoundPlayer(error_file);

        static SettingsForm settingsform;
        static DonateForm donateform;

        public static bool IsAdministrator() {
            return (new WindowsPrincipal(WindowsIdentity.GetCurrent()))
                      .IsInRole(WindowsBuiltInRole.Administrator);
        }

        public Mainform() {
            InitializeComponent();
            AppDomain.CurrentDomain.ProcessExit += new EventHandler(OnProcessExit);
        }

        private void Mainform_Load(object sender, EventArgs e) {
            HandleXML();
            if (settings.CheckForUpdatesOnStart == 1) {
                CheckForUpdates();
            }
            SensX.Text = settings.SensX.ToString();
            SensY.Text = settings.SensY.ToString();

            string window_title = "Halo CE Mouse Tool v" + updatehandler.version.ToString();
            if (!IsAdministrator()) {
                window_title += " -NOT ADMIN-";
                sound_notice();
                MessageBox.Show("Warning - You must run this tool as an administrator in order for it to work properly.");
            }
            this.Text = window_title;
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
                return_value = memoryhandler.WriteToProcessMemory("haloce", curr_val, curr_addr);
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

        private void GithubLink_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e) {
            Process.Start("https://github.com/AWilliams17/Halo-CE-Mouse-Tool");
        }

        private void RedditLink_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e) {
            Process.Start("https://www.reddit.com/r/halospv3/comments/6aoxu0/halo_ce_mouse_tool_released_fine_tune_your_mouse/");
        }

        private void HotkeyLabelTimer_Tick(object sender, EventArgs e) {
            if (settings.HotkeyEnabled == 1) {
                HotkeyStatus.Text = "Keybind is set to: " + settings.Hotkey;
            } else {
                HotkeyStatus.Text = "Keybind is disabled/not set.";
            }
        }

        private void SensX_TextChanged(object sender, EventArgs e) {
            float conv_SensX;
            if (SensX.Text != "") {
                 if (!float.TryParse(SensX.Text, out conv_SensX)){
                    SensX.Text = "0";
                    MessageBox.Show("Invalid input. Only numbers allowed.");
                } else {
                    settings.SensX = conv_SensX;
                }
            }
        }

        private void SensY_TextChanged(object sender, EventArgs e) {
            float conv_SensY;
            if (SensY.Text != "") {
                if (!float.TryParse(SensY.Text, out conv_SensY)) {
                    SensY.Text = "0";
                    MessageBox.Show("Invalid input. Only numbers allowed.");
                } else {
                    settings.SensY = conv_SensY;
                }
            }
        }

        static void OnProcessExit(object sender, EventArgs e) {
            xmlhandler.WriteSettingsToXML(settings);
        }

        private void HotkeyTimer_Tick(object sender, EventArgs e) {
            if (keybindhandler.KeybindsEnabled && settings.HotkeyEnabled == 1) {
                if (KeybindHandler.IsKeyPushedDown((Keys)Enum.Parse(typeof(Keys), settings.Hotkey))) {
                    WriteHaloMemory();
                }
            }
        }

        private void SensX_Leave(object sender, EventArgs e) {
            if (SensX.Text == "") {
                SensX.Focus();
                MessageBox.Show("Error: You can't leave this field blank.");
            }
        }

        private void SensY_Leave(object sender, EventArgs e) {
            if (SensY.Text == "") {
                SensY.Focus();
                MessageBox.Show("Error: You can't leave this field blank.");
            }
        }

        private void HandleXML() {
            int loadxml = xmlhandler.LoadSettingsFromXML(settings);
            if (loadxml == 1) {
                sound_success();
                MessageBox.Show("Successfully found & Read XML.");
            } else if (loadxml == 2 || loadxml == 3) {
                sound_error();
                MessageBox.Show("An XML file was found, but an error occurred whilst reading it. It is possible one or more settings were not set. They have been set to default.");
            } else {
                sound_notice();
                MessageBox.Show("Didn't find an XML file. Will now generate one with default values...");
                xmlhandler.GenerateXML();
                xmlhandler.LoadSettingsFromXML(settings);
            }
        }

        public void CheckForUpdates() {
            int res = updatehandler.CheckForUpdates();
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
                success.Play();
            }
        }

        public void sound_error() {
            if (settings.SoundsEnabled == 1) {
                error.Play();
            }
        }

        public void sound_notice() {
            if (settings.SoundsEnabled == 1) {
                notice.Play();
            }
        }
    }
}
