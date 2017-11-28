using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Halo_CE_Mouse_Tool {
    public partial class SettingsForm : Form {
        public SettingsForm(string hotkey, int checkforupdatesonlaunch, int patchaccel, int hotkeyon) {
            InitializeComponent();

            HotkeyText.Text = hotkey;
            if (checkforupdatesonlaunch == 1) {
                UpdateCheckbox.Checked = true;
            }
            if (patchaccel == 1) {
                MouseAccelCheckbox.Checked = true;
            }
            if (hotkeyon == 1) {
                EnableHotkeyCheckbox.Checked = true;
            }

        }

        private void SettingsForm_Load(object sender, EventArgs e) {

        }
    }
}
