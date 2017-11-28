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

namespace Halo_CE_Mouse_Tool {
    public partial class Mainform : Form {
        ProcessHandler processhandler;
        UpdateHandler updatehandler;
        SettingsHandler settings;
        KeybindHandler keybindhandler;
        FormHandler formhandler;
        MemoryHandler memoryhandler;
        static SettingsForm settingsform;
        static DonateForm donateform;

        public Mainform() {
            InitializeComponent();
        }

        private void Mainform_Load(object sender, EventArgs e) {
            SetUp();
            this.Text =  "Halo CE Mouse Tool v" + updatehandler.GetVersion().ToString();
            
            if (settings.CheckForUpdatesOnStart()) {
                updatehandler.CheckForUpdates();
            }

            settings.LoadSettingsFromIni();
        }

        private void ActivateBtn_Click_1(object sender, EventArgs e) {
            WriteHaloMemory();
        }

        private void SetUp() { //Create objects
            processhandler = new ProcessHandler();
            updatehandler = new UpdateHandler();
            settings = new SettingsHandler();
            keybindhandler = new KeybindHandler();
            formhandler = new FormHandler();
            memoryhandler = new MemoryHandler();
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
                settingsform = new SettingsForm();
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

        private void WriteHaloMemory() {
            byte[] mouseaccelnop = { 0x90, 0x90, 0x90, 0x90, 0x90, 0x90 };
            int return_value;
            int curr_addr = 0;
            byte[] curr_val = { };
            for (int i = 0; i != 4; i++) {
                if (i == 0) {
                    curr_val = BitConverter.GetBytes(settings.SensX());
                    curr_addr = 0x2ABB50;
                }
                if (i == 1) {
                    curr_val = BitConverter.GetBytes(settings.SensX());
                    curr_addr = 0x2ABB54;
                }
                if (i == 2 && settings.PatchAcceleration()) {
                    curr_val = mouseaccelnop;
                    curr_addr = 0x8F836;
                }
                if (i == 3 && settings.PatchAcceleration()) {
                    curr_val = mouseaccelnop;
                    curr_addr = 0x8F830;
                }
                return_value = memoryhandler.WriteToProcessMemory("haloce", curr_val, curr_addr);
                if (return_value != 0) {
                    if (return_value == 1) {
                        MessageBox.Show("Access Denied. Are you running the tool as an admin?");
                    } else {
                        MessageBox.Show("One or more values failed to write. Error code: " + return_value.ToString());
                    }
                    break;
                }
                else if (i == 3 && return_value == 0) {
                    MessageBox.Show("Successfully wrote sensitivity values to memory.");
                }
            }
        }

        private void GithubLink_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e) {
            Process.Start("https://github.com/AWilliams17/Halo-CE-Mouse-Tool");
        }

        private void RedditLink_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e) {
            Process.Start("https://www.reddit.com/r/halospv3/comments/6aoxu0/halo_ce_mouse_tool_released_fine_tune_your_mouse/");
        }

        private void HotkeyLabelTimer_Tick(object sender, EventArgs e) {

        }
    }
}
