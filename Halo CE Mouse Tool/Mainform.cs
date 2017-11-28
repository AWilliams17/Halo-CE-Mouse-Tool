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

        private void ActivateBtn_Click(object sender, EventArgs e) {
            
        }

        private void GithubLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {

        }

        private void DonateLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {

        }

        private void RedditLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {

        }

        private void SetUp() { //Create objects
            processhandler = new ProcessHandler();
            updatehandler = new UpdateHandler();
            settings = new SettingsHandler();
            keybindhandler = new KeybindHandler();
            formhandler = new FormHandler();
        }

        private void StatusLabelTimer_Tick(object sender, EventArgs e) {
            if (processhandler.ProcessIsRunning("Halo Custom Edition")) {
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
    }
}
