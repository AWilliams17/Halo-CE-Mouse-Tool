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
    }
}
