using System.Windows.Forms;
using System.Diagnostics;

namespace Halo_Mouse_Tool
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
