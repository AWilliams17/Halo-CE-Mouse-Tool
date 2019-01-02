using Halo_Mouse_Tool.Classes.ConfigContainer;
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
            KeyIncrementCheckbox.IsChecked = config.settings.GetOption<int>("IncrementHotkeysEnabled") == 1;
            SoundsCheckbox.IsChecked = config.settings.GetOption<int>("SuccessSoundsEnabled") == 1;
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
            HotkeyTextbox.Text = e.Key.ToString();
        }

        private void IncrementAmountUpDown_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            float incrementValue = IncrementAmountUpDown.Value.Value;
            config?.settings.SetOption("IncrementAmount", incrementValue);
        }
        
        private void KeyIncrementCheckbox_Checked(object sender, RoutedEventArgs e)
        {
            config.settings.SetOption("IncrementHotkeysEnabled", 1);
        }

        private void KeyIncrementCheckbox_Unchecked(object sender, RoutedEventArgs e)
        {
            config.settings.SetOption("IncrementHotkeysEnabled", 0);
        }
        
        private void SoundsCheckbox_Checked(object sender, RoutedEventArgs e)
        {
            config.settings.SetOption("SuccessSoundsEnabled", 1);
        }

        private void SoundsCheckbox_Unchecked(object sender, RoutedEventArgs e)
        {
            config.settings.SetOption("SuccessSoundsEnabled", 0);
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            config.settings.SaveSettings();
            Close();
        }
    }
}
