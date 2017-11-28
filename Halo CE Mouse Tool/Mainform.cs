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
        }
    }
}
