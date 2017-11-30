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
        public ProcessHandler processhandler = new ProcessHandler();
        public UpdateHandler updatehandler = new UpdateHandler();
        public FormHandler formhandler = new FormHandler();
        public MemoryHandler memoryhandler = new MemoryHandler();
        public utils utilities;
        public static SettingsHandler settings = new SettingsHandler();
        public static KeybindHandler keybindhandler = new KeybindHandler();
        public static XMLHandler xmlhandler = new XMLHandler();

        static Stream success_file = Properties.Resources.SND_Success;
        static Stream notice_file = Properties.Resources.SND_Notice;
        static Stream error_file = Properties.Resources.SND_Error;
        public SoundPlayer success = new System.Media.SoundPlayer(success_file);
        public SoundPlayer notice = new System.Media.SoundPlayer(notice_file);
        public SoundPlayer error = new System.Media.SoundPlayer(error_file);

        public SettingsForm settingsform;
        public DonateForm donateform;

        public Mainform() {
            InitializeComponent();
            AppDomain.CurrentDomain.ProcessExit += new EventHandler(OnProcessExit);
        }

        private void Mainform_Load(object sender, EventArgs e) {
            utilities = new utils(this);
            utilities.HandleXML();
            if (settings.CheckForUpdatesOnStart == 1) {
                utilities.CheckForUpdates();
            }
            SensX.Text = settings.SensX.ToString();
            SensY.Text = settings.SensY.ToString();

            string window_title = "Halo CE Mouse Tool v" + updatehandler.version.ToString();
            if (!utilities.IsAdministrator()) {
                window_title += " -NOT ADMIN-";
                utilities.sound_notice();
                MessageBox.Show("Warning - You must run this tool as an administrator in order for it to work properly.");
            }
            this.Text = window_title;
        }

        private void ActivateBtn_Click_1(object sender, EventArgs e) {
            utilities.WriteHaloMemory();
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
            formhandler.formopen(settingsform, this);
        }

        private void DonateLink_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e) {
            formhandler.formopen(donateform, this);
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
            utilities.parse_sensitivity(this.SensX, 'x');
        }

        private void SensY_TextChanged(object sender, EventArgs e) {
            utilities.parse_sensitivity(this.SensX, 'y');
        }

        static void OnProcessExit(object sender, EventArgs e) {
            xmlhandler.WriteSettingsToXML(settings);
        }

        private void HotkeyTimer_Tick(object sender, EventArgs e) {
            utilities.keybind_handle();
        }

        private void SensX_Leave(object sender, EventArgs e) {
            utilities.check_if_blank(this.SensX);
        }

        private void SensY_Leave(object sender, EventArgs e) {
            utilities.check_if_blank(this.SensY);
        }
    }
}
