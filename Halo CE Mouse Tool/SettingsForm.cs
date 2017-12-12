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

namespace Halo_CE_Mouse_Tool
{
    public partial class SettingsForm : Form
    {
        public SettingsHandler settings;
        public SettingsForm(SettingsHandler settings_ref)
        { //Grab all the users settings and set the controls accordingly
            InitializeComponent();
            settings = settings_ref;
            HotkeyText.Text = settings.Hotkey;
            if (settings.HotkeyEnabled == 1)
            {
                EnableHotkeyCheckbox.Checked = true;
            }
            if (settings.PatchAcceleration == 1)
            {
                MouseAccelCheckbox.Checked = true;
            }
            if (settings.CheckForUpdatesOnStart == 1)
            {
                UpdateCheckbox.Checked = true;
            }
            if (settings.SoundsEnabled == 1)
            {
                SoundsEnabledCheckbox.Checked = true;
            }
            if (settings.HideKeybindSuccessMsg == 1)
            {
                HideHotkeyMsgCheckbox.Checked = true;
            }
            if (settings.IncrementSens == 1)
            {
                IncrementHotkeyCheckbox.Checked = true;
            }
            UpdateTimeoutUpDown.Value = Convert.ToDecimal(settings.UpdateTimeout) / 1000;
            IncrementAmount.Value = Convert.ToDecimal(settings.IncrementAmount);

        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            //idk why this is here
        }

        private void EnableHotkeyCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (EnableHotkeyCheckbox.Checked)
            {
                settings.HotkeyEnabled = 1;
            }
            else {
                settings.HotkeyEnabled = 0;
            }
        }

        private void UpdateCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (UpdateCheckbox.Checked)
            {
                settings.CheckForUpdatesOnStart = 1;
            }
            else {
                settings.CheckForUpdatesOnStart = 0;
            }
        }

        private void MouseAccelCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (MouseAccelCheckbox.Checked)
            {
                settings.PatchAcceleration = 1;
            }
            else {
                settings.PatchAcceleration = 0;
            }
        }

        private void SoundsEnabledCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (SoundsEnabledCheckbox.Checked)
            {
                settings.SoundsEnabled = 1;
            }
            else {
                settings.SoundsEnabled = 0;
            }
        }

        private void CheckforUpdatesBtn_Click(object sender, EventArgs e)
        {
            utils.CheckForUpdates(settings);
        }

        private void HotkeyText_KeyDown(object sender, KeyEventArgs e)
        {
            string key = e.KeyCode.ToString();

            HotkeyText.Text = key;
            settings.Hotkey = key;
        }

        private void HideHotkeyMsgCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (HideHotkeyMsgCheckbox.Checked)
            {
                settings.HideKeybindSuccessMsg = 1;
            }
            else
            {
                settings.HideKeybindSuccessMsg = 0;
            }
        }

        private void UpdateTimeoutUpDown_ValueChanged(object sender, EventArgs e)
        {
            int val = Convert.ToInt32(UpdateTimeoutUpDown.Value);
            val = val * 1000;

            settings.UpdateTimeout = val;
        }

        private void IncrementHotkeyCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (IncrementHotkeyCheckbox.Checked)
            {
                settings.IncrementSens = 1;
            }
            else
            {
                settings.IncrementSens = 0;
            }
        }

        private void IncrementAmount_ValueChanged(object sender, EventArgs e)
        {
            float val = (float)IncrementAmount.Value;
            settings.IncrementAmount = val;
        }
    }
}
