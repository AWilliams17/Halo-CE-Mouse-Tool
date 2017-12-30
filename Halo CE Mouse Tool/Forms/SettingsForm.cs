using System;
using System.Windows.Forms;

namespace Halo_CE_Mouse_Tool
{
    public partial class SettingsForm : Form
    {
        public SettingsHandler Settings;
        public SettingsForm(SettingsHandler settingsRef)
        { //Grab all the users settings and set the controls accordingly
            InitializeComponent();
            Settings = settingsRef;
            HotkeyText.Text = Settings.Hotkey;
            if (Settings.HotkeyEnabled == 1)
            {
                EnableHotkeyCheckbox.Checked = true;
            }
            if (Settings.PatchAcceleration == 1)
            {
                MouseAccelCheckbox.Checked = true;
            }
            if (Settings.CheckForUpdatesOnStart == 1)
            {
                UpdateCheckbox.Checked = true;
            }
            if (Settings.SoundsEnabled == 1)
            {
                SoundsEnabledCheckbox.Checked = true;
            }
            if (Settings.HideKeybindSuccessMsg == 1)
            {
                HideHotkeyMsgCheckbox.Checked = true;
            }
            if (Settings.IncrementSens == 1)
            {
                IncrementHotkeyCheckbox.Checked = true;
            }
            UpdateTimeoutUpDown.Value = Convert.ToDecimal(Settings.UpdateTimeout) / 1000;
            IncrementAmount.Value = Convert.ToDecimal(Settings.IncrementAmount);

        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            //idk why this is here
        }

        private void EnableHotkeyCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            Settings.HotkeyEnabled = EnableHotkeyCheckbox.Checked ? 1 : 0;
        }

        private void UpdateCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            Settings.CheckForUpdatesOnStart = UpdateCheckbox.Checked ? 1 : 0;
        }

        private void MouseAccelCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            Settings.PatchAcceleration = MouseAccelCheckbox.Checked ? 1 : 0;
        }

        private void SoundsEnabledCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            Settings.SoundsEnabled = SoundsEnabledCheckbox.Checked ? 1 : 0;
        }

        private void HideHotkeyMsgCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            Settings.HideKeybindSuccessMsg = HideHotkeyMsgCheckbox.Checked ? 1 : 0;
        }

        private void IncrementHotkeyCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            Settings.IncrementSens = IncrementHotkeyCheckbox.Checked ? 1 : 0;
        }

        private void CheckforUpdatesBtn_Click(object sender, EventArgs e)
        {
            Utils.CheckForUpdates(Settings);
        }

        private void HotkeyText_KeyDown(object sender, KeyEventArgs e)
        {
            string key = e.KeyCode.ToString();

            HotkeyText.Text = key;
            Settings.Hotkey = key;
        }

        private void UpdateTimeoutUpDown_ValueChanged(object sender, EventArgs e)
        {
            int val = Convert.ToInt32(UpdateTimeoutUpDown.Value);
            val = val * 1000;

            Settings.UpdateTimeout = val;
        }

        private void IncrementAmount_ValueChanged(object sender, EventArgs e)
        {
            float val = (float)IncrementAmount.Value;
            Settings.IncrementAmount = val;
        }
    }
}
