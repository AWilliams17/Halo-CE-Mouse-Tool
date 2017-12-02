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
using System.Diagnostics;

namespace Halo_CE_Mouse_Tool {
    public partial class SettingsForm : Form {
        public SettingsHandler settings;
        public SettingsForm(SettingsHandler settings_ref) { //Grab all the users settings and set the controls accordingly
            InitializeComponent();
            settings = settings_ref;
            HotkeyText.Text = settings.Hotkey;
            if (settings.HotkeyEnabled == 1) {
                EnableHotkeyCheckbox.Checked = true;
            }
            if (settings.PatchAcceleration == 1) {
                MouseAccelCheckbox.Checked = true;
            }
            if (settings.CheckForUpdatesOnStart == 1) {
                UpdateCheckbox.Checked = true;
            }
            if (settings.SoundsEnabled == 1) {
                SoundsEnabledCheckbox.Checked = true;
            }

        }

        private void SettingsForm_Load(object sender, EventArgs e) {
            //idk why this is here
        }

        private void EnableHotkeyCheckbox_CheckedChanged(object sender, EventArgs e) {
            if (EnableHotkeyCheckbox.Checked) {
                settings.HotkeyEnabled = 1;
            } else {
                settings.HotkeyEnabled = 0;
            }
        }

        private void UpdateCheckbox_CheckedChanged(object sender, EventArgs e) {
            if (UpdateCheckbox.Checked) {
                settings.CheckForUpdatesOnStart = 1;
            } else {
                settings.CheckForUpdatesOnStart = 0;
            }
        }

        private void MouseAccelCheckbox_CheckedChanged(object sender, EventArgs e) {
            if (MouseAccelCheckbox.Checked) {
                settings.PatchAcceleration = 1;
            } else {
                settings.PatchAcceleration = 0;
            }
        }

        private void SoundsEnabledCheckbox_CheckedChanged(object sender, EventArgs e) {
            if (SoundsEnabledCheckbox.Checked) {
                settings.SoundsEnabled = 1;
            } else {
                settings.SoundsEnabled = 0;
            }
        }

        private void CheckforUpdatesBtn_Click(object sender, EventArgs e) {
            utils.CheckForUpdates(settings);
        }

        private void HotkeyText_KeyDown(object sender, KeyEventArgs e) {
            string key = e.KeyCode.ToString();

            HotkeyText.Text = key;
            settings.Hotkey = key;
        }
    }
}
