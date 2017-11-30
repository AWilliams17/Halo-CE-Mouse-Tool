using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Halo_CE_Mouse_Tool {
    public partial class SettingsForm : Form {

        SettingsHandler settings;
        UpdateHandler updatehandler;
        public SettingsForm(Mainform f1) {
            InitializeComponent();
            settings = Mainform.settings;
            updatehandler = f1.updatehandler;

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

        private void EnableHotkeyCheckbox_CheckedChanged(object sender, EventArgs e) {
            if (EnableHotkeyCheckbox.Checked) {
                settings.SetHotkeyEnabled(1);
            } else {
                settings.SetHotkeyEnabled(0);
            }
        }

        private void UpdateCheckbox_CheckedChanged(object sender, EventArgs e) {
            if (UpdateCheckbox.Checked) {
                settings.SetCheckForUpdates(1);
            } else {
                settings.SetCheckForUpdates(0);
            }
        }

        private void MouseAccelCheckbox_CheckedChanged(object sender, EventArgs e) {
            if (MouseAccelCheckbox.Checked) {
                settings.SetPatchAcceleration(1);
            } else {
                settings.SetPatchAcceleration(0);
            }
        }

        private void CheckforUpdatesBtn_Click(object sender, EventArgs e) {
            updatehandler.CheckForUpdates();
        }

        private void HotkeyText_KeyDown(object sender, KeyEventArgs e) {
            string key = e.KeyCode.ToString();

            HotkeyText.Text = key;
            settings.SetHotkey(key);
        }
    }
}
