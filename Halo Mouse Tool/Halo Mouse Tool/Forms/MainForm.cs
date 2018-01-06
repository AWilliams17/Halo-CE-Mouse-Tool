using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Halo_Mouse_Tool
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            //Exit
            Application.Exit();
        }

        private void DonateBtn_Click(object sender, EventArgs e)
        {
            //Open Donate Form
        }

        private void AboutBtn_Click(object sender, EventArgs e)
        {
            //About
        }

        private void HelpBtn_Click(object sender, EventArgs e)
        {
            //Open Help doc
        }

        private void SaveSettingsBtn_Click(object sender, EventArgs e)
        {
            //Save Settings to Registry
        }

        private void DeployDllBtn_Click(object sender, EventArgs e)
        {
            //Deploy the DLL
        }

        private void CheckForUpdateBtn_Click(object sender, EventArgs e)
        {
            //Check if an update is available
        }

        private void OptionsBtn_Click(object sender, EventArgs e)
        {
            //Display Options form
        }

        private void HaloCustomEditionBtn_Click(object sender, EventArgs e)
        {
            //Set the game to Halo CE
        }

        private void HaloCombatEvolvedBtn_Click(object sender, EventArgs e)
        {
            //Set the game to Halo PC
        }
    }
}
