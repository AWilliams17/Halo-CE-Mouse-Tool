using System;
using System.Windows.Forms;

namespace Halo_Mouse_Tool
{
    public partial class SettingsForm : Form
    {
        public Settings settings;
        public SettingsForm(Settings settingsRef)
        {
            InitializeComponent();
            settings = settingsRef;

            //Checkboxes
            HotkeyCheckbox.Checked = settings.HotKeyEnabled;
            SuccessMessagesCheckbox.Checked = settings.SuccessMessages;
            SuccessMessagesDll.Checked = settings.SuccessMessagesDll;
            SoundsCheckbox.Checked = settings.SoundsEnabled;
            DllSoundsCheckbox.Checked = settings.SoundsEnabledDll;
            CheckForUpdatesCheckbox.Checked = settings.CheckForUpdates;
            IncrementCheckbox.Checked = settings.IncrementKeysEnabled;
            IncrementDllCheckbox.Checked = settings.IncrementKeysEnabledDll;

            //Textboxes & increment up/downs
            HotkeyTextbox.Text = settings.HotKeyApplication;
            DllHotkeyTextbox.Text = settings.HotKeyDll;
            UpdateIncrement.Value = decimal.Parse(settings.UpdateTimeout.ToString()) / 1000;
            IncrementAmountUpDown.Value = decimal.Parse(settings.IncrementAmount.ToString());
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void HotkeyCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            settings.HotKeyEnabled = HotkeyCheckbox.Checked;
        }

        private void CheckForUpdatesCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            settings.CheckForUpdates = CheckForUpdatesCheckbox.Checked;
        }

        private void SoundsCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            settings.SoundsEnabled = SoundsCheckbox.Checked;
        }

        private void DllSoundsCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            settings.SoundsEnabledDll = DllSoundsCheckbox.Checked;
        }

        private void SuccessMessagesCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            settings.SuccessMessages = SuccessMessagesCheckbox.Checked;
        }

        private void SuccessMessagesDll_CheckedChanged(object sender, EventArgs e)
        {
            settings.SuccessMessagesDll = SuccessMessagesDll.Checked;
        }

        private void IncrementCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            settings.IncrementKeysEnabled = IncrementCheckbox.Checked;
        }

        private void IncrementDllCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            settings.IncrementKeysEnabledDll = IncrementDllCheckbox.Checked;
        }

        private void IncrementAmountUpDown_ValueChanged(object sender, EventArgs e)
        {
            float val = (float)IncrementAmountUpDown.Value;
            settings.IncrementAmount = val;
        }

        private void UpdateIncrement_ValueChanged(object sender, EventArgs e)
        {
            int val = (int)UpdateIncrement.Value * 1000;
            settings.UpdateTimeout = val;
        }

        private void HotkeyTextbox_KeyDown(object sender, KeyEventArgs e)
        {
            string key = e.KeyCode.ToString();

            HotkeyTextbox.Text = key;
            settings.HotKeyApplication = key;
        }

        private void DllHotkeyTextbox_KeyDown(object sender, KeyEventArgs e)
        {
            string key = e.KeyCode.ToString();

            DllHotkeyTextbox.Text = key;
            settings.HotKeyDll = key;
        }
    }
}
