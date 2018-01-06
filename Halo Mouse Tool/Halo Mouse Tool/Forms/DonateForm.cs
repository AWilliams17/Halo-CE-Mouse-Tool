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

namespace Halo_Mouse_Tool.Forms
{
    public partial class DonateForm : Form
    {
        public DonateForm()
        {
            InitializeComponent();
        }

        private void PaypalLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.paypal.me/AWilliams17411");
        }
    }
}
