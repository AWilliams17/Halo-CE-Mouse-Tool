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
using System.IO;
using System.Media;

namespace Halo_CE_Mouse_Tool {
    public partial class Mainform : Form { //And here we go...
        public static SettingsHandler settings = new SettingsHandler();
        //TODO: Why aren't these static?
        public SettingsForm settingsform;
        public DonateForm donateform;

        public Mainform() {
            InitializeComponent();
            AppDomain.CurrentDomain.ProcessExit += new EventHandler(OnProcessExit);
        }

        private void Mainform_Load(object sender, EventArgs e) {
            utils.HandleXML();
            if (settings.CheckForUpdatesOnStart == 1) {
                utils.CheckForUpdates();
            }
            //Perhaps I can move these to handlexml?
            SensX.Text = settings.SensX.ToString();
            SensY.Text = settings.SensY.ToString();

            string window_title = "Halo CE Mouse Tool v" + UpdateHandler.version.ToString();
            if (!utils.IsAdministrator()) {
                window_title += " -NOT ADMIN-";
                SoundHandler.sound_notice();
                MessageBox.Show("Warning - You must run this tool as an administrator in order for it to work properly.");
            }
            this.Text = window_title;
        }

        private void ActivateBtn_Click_1(object sender, EventArgs e) {
            utils.WriteHaloMemory();
        }

        private void StatusLabelTimer_Tick(object sender, EventArgs e) {
            if (ProcessHandler.ProcessIsRunning("HALOCE")) {
                StatusLabel.Text = "Halo CE Process found.";
                StatusLabel.ForeColor = Color.Green;
                ActivateBtn.Enabled = true;
                KeybindHandler.KeybindsEnabled = true;
            } else {
                StatusLabel.Text = "Halo CE Process not found.";
                StatusLabel.ForeColor = Color.Red;
                ActivateBtn.Enabled = false;
                KeybindHandler.KeybindsEnabled = false;
            }
        }

        private void SettingsBtn_Click(object sender, EventArgs e) {
            FormHandler.formopen(settingsform, this);
        }

        private void DonateLink_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e) {
            FormHandler.formopen(donateform, this);
        }

        private void GithubLink_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e) {
            Process.Start("https://github.com/AWilliams17/Halo-CE-Mouse-Tool");
        }

        private void RedditLink_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e) {
            Process.Start("https://www.reddit.com/r/halospv3/comments/7fdrpr/just_released_halo_mouse_tool_v3/?st=jan506jz&sh=1bd4ebda");
        }

        private void HotkeyLabelTimer_Tick(object sender, EventArgs e) {
            if (settings.HotkeyEnabled == 1) {
                HotkeyStatus.Text = "Keybind is set to: " + settings.Hotkey;
            } else {
                HotkeyStatus.Text = "Keybind is disabled/not set.";
            }
        }

        private void SensX_TextChanged(object sender, EventArgs e) {
            utils.parse_sensitivity(this.SensX, 'x'); //Make sure the input is valid.
        }

        private void SensY_TextChanged(object sender, EventArgs e) {
            utils.parse_sensitivity(this.SensX, 'y'); //Same as above.
        }

        static void OnProcessExit(object sender, EventArgs e) {
            XMLHandler.WriteSettingsToXML(settings); //When the application exits, purge all the current settings to the config.
        }

        private void HotkeyTimer_Tick(object sender, EventArgs e) {
            utils.keybind_handle(); //If the user presses their hotkey, then handle it.
            //Is there a better way of doing this?
        }

        private void SensX_Leave(object sender, EventArgs e) {
            utils.check_if_blank(this.SensX); //If the user tries to leave with the textbox being blank, then force them back to it.
        }

        private void SensY_Leave(object sender, EventArgs e) {
            utils.check_if_blank(this.SensY); //Same as above.
        }
    }
}
