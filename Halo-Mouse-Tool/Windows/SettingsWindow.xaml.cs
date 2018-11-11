﻿using Halo_Mouse_Tool.Classes.ConfigContainer;
using System.Windows;
using System.Windows.Input;

namespace Halo_Mouse_Tool.Windows
{
    /// <summary>
    /// Interaction logic for SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow
    {
        Config config;

        public SettingsWindow(Config ConfigInstance)
        {
            InitializeComponent();
            config = ConfigInstance;
            SetControls();
        }

        private void SetControls()
        {
            HotkeyCheckbox.IsChecked = config.settings.GetOption<int>("HotkeyEnabled") == 1;
            KeyIncrementCheckbox.IsChecked = config.settings.GetOption<int>("IncrementKeysEnabled") == 1;
            HotkeyTextbox.Text = config.settings.GetOption<string>("Hotkey");
            IncrementAmountUpDown.Value = config.settings.GetOption<float>("IncrementAmount");
        }

        private void HotkeyCheckbox_Checked(object sender, RoutedEventArgs e)
        {
            config.settings.SetOption("HotkeyEnabled", 1);
        }

        private void HotkeyCheckbox_Unchecked(object sender, RoutedEventArgs e)
        {
            config.settings.SetOption("HotkeyEnabled", 0);
        }

        private void HotkeyTextbox_KeyDown(object sender, KeyEventArgs e)
        {
            config.settings.SetOption("Hotkey", e.Key);
        }

        private void IncrementAmountUpDown_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            float incrementValue = IncrementAmountUpDown.Value.Value;
            config?.settings.SetOption("IncrementAmount", incrementValue);
        }
        
        private void KeyIncrementCheckbox_Checked(object sender, RoutedEventArgs e)
        {
            config.settings.SetOption("IncrementKeysEnabled", 1);
        }

        private void KeyIncrementCheckbox_Unchecked(object sender, RoutedEventArgs e)
        {
            config.settings.SetOption("IncrementKeysEnabled", 0);
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            config.settings.SaveSettings();
            Close();
        }

        private void QuietModeCheckbox_Checked(object sender, RoutedEventArgs e)
        {
            config.settings.SetOption("QuietMode", 1);
        }

        private void QuietModeCheckbox_Unchecked(object sender, RoutedEventArgs e)
        {
            config.settings.SetOption("QuietMode", 0);
        }
    }
}