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

namespace Halo_CE_Mouse_Tool
{
    public partial class Mainform : Form
    {
        public Mainform()
        {
            InitializeComponent();
            this.Icon = Halo_CE_Mouse_Tool.Properties.Resources.HMFIcon;
        }
        
        private void EnableBtnTimer_Tick(object sender, EventArgs e)
        {
            if (Process.GetProcessesByName("haloce").Length > 0)
            {
                ActivateBtn.Enabled = true;
                StatusLabel.Text = "Halo CE Process Detected.";
                StatusLabel.ForeColor = Color.Green;
            }
            else
            {
                ActivateBtn.Enabled = false;
                StatusLabel.Text = "Waiting for Halo CE Process...";
                StatusLabel.ForeColor = Color.Red;
            }
        }


        private void ActivateBtn_Click(object sender, EventArgs e)
        {
            float mousesens;
            bool valid = float.TryParse(Sens.Text, out mousesens);
            if (!valid)
            {
                MessageBox.Show("Only numbers allowed in this field.");
            }
            else
            {
                MessageBox.Show(HaloMemWriter.WriteHaloMemory(mousesens * 0.25f).ToString());
            }
        }

        private void GithubLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Put Github Link here later
        }

        private void RedditLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           Process.Start("https://www.reddit.com/r/halospv3/comments/5dk9ta/finallyhalo_ce_mouse_fix_tool_v10_also_open_source/");
        }

        private void Mainform_Load(object sender, EventArgs e)
        {
            if (CheckForUpdates.UpdateAvailable() == "yes")
            {
                DialogResult d = MessageBox.Show("An Update is Available. Would you like to visit the downloads page?", "Update Found", MessageBoxButtons.YesNo);
                if (d == DialogResult.Yes)
                {
                    Process.Start("https://www.ayy.com");
                }
            }
            else if (CheckForUpdates.UpdateAvailable() == "error")
            {
                MessageBox.Show("Failed to check for available updates.");
            }
        }
    }
}
