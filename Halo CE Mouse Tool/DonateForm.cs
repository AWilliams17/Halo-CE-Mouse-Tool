using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;

namespace Halo_CE_Mouse_Tool {
    public partial class DonateForm : Form {
        public DonateForm() {
            InitializeComponent();
        }

        private void PaypalLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            Process.Start("https://www.paypal.me/AWilliams17411");
        }
    }
}
