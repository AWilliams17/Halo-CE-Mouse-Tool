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
        SettingsHandler settings;
        public SettingsForm(Mainform f1) {
            InitializeComponent();
            settings = f1.settings;

            HotkeyText.Text = settings.GetHotkey();
            if (settings.GetHotkeyEnabled() == 1) {
                EnableHotkeyCheckbox.Checked = true;
            }
            if (settings.GetPatchAcceleration() == 1) {
                MouseAccelCheckbox.Checked = true;
            }
            if (settings.CheckForUpdatesOnStart() == 1) {
                UpdateCheckbox.Checked = true;
            }

        }

        private void SettingsForm_Load(object sender, EventArgs e) {

        }
    }
}
