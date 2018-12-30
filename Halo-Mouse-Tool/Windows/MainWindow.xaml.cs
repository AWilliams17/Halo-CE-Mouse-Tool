using Halo_Mouse_Tool.Windows;
using Halo_Mouse_Tool.Classes.ConfigContainer;
using Halo_Mouse_Tool.Classes.HaloMemoryWriter;
using Registrar;
using System;
using System.Runtime.InteropServices;
using System.Windows;
using SharpUtils.WPFUtils;
using System.Diagnostics;
using System.Threading;
using SharpUtils.WebUtils;
using System.Net;
using NHotkey.Wpf;
using NHotkey;
using System.Windows.Input;

namespace Halo_Mouse_Tool
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private static Config config;
        private enum Game {HaloCE, HaloPC};
        private Game selectedGame;

        public MainWindow()
        {
            InitializeComponent();
            Closing += MainWindow_Closing;
            config = new Config();

            try
            {
                config.settings.LoadSettings();
            }
            catch (RegLoadException)
            {
                try
                {
                    config.settings.SaveSettings();
                }
                catch (RegSaveException ex)
                {
                    MessageBox.Show($"Failed to save default settings. Error message: {ex.Message}", "Error while saving settings to Registry.");
                }
            }

            selectedGame = (Game)config.settings.GetOption<int>("CurrentGame");
            SetSensitivityBoxes(config.settings.GetOption<float>("SensitivityX"), config.settings.GetOption<float>("SensitivityY"));
            SetCurrentGameBtnStatuses();
            InitHotkeys();
        }

        private void InitHotkeys()
        {
            KeyConverter keyConverter = new KeyConverter();
            Key activateKey = (Key)keyConverter.ConvertFromString(config.settings.GetOption<string>("Hotkey"));

            HotkeyManager.Current.AddOrReplace("Activate", activateKey, 0, OnHotkeyPressed_WriteMemory);
            HotkeyManager.Current.AddOrReplace("Increment", Key.OemPlus, 0, OnHotkeyPressed_PlusMinus);
            HotkeyManager.Current.AddOrReplace("Decrement", Key.OemMinus, 0, OnHotkeyPressed_PlusMinus);
        }

        private void OnHotkeyPressed_PlusMinus(object sender, HotkeyEventArgs e)
        {
            if (config.settings.GetOption<int>("IncrementKeysEnabled") == 1)
            {
                if (e.Name == "Increment")
                {
                    SensXUpDown.Value += config.settings.GetOption<float>("IncrementAmount");
                    SensYUpDown.Value += config.settings.GetOption<float>("IncrementAmount");
                }
                if (e.Name == "Decrement")
                {
                    SensXUpDown.Value -= config.settings.GetOption<float>("IncrementAmount");
                    SensYUpDown.Value -= config.settings.GetOption<float>("IncrementAmount");
                }
                WriteToMemory();
            }
            e.Handled = true;
        }

        public void OnHotkeyPressed_WriteMemory(object sender, HotkeyEventArgs e)
        {
            if (config.settings.GetOption<int>("HotkeyEnabled") == 1)
            {
                WriteToMemory();
            }
            e.Handled = true;
        }

        private void SettingsBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!WindowHelpers.IsWindowOpen(typeof(SettingsWindow)))
            {
                SettingsWindow settingsWindow = new SettingsWindow(config, this);
                settingsWindow.Show();
            }
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!WindowHelpers.IsWindowOpen(typeof(UpdateWindow)))
            {
                UpdateWindow updateWindow = new UpdateWindow();
                updateWindow.Show();
            }
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void SetCurrentGameBtnStatuses()
        {
            HaloCustomEditionBtn.IsChecked = (selectedGame == Game.HaloCE);
            HaloCombatEvolvedBtn.IsChecked = (selectedGame == Game.HaloPC);
        }

        private void HaloCustomEditionBtn_Click(object sender, RoutedEventArgs e)
        {
            selectedGame = Game.HaloCE;
            config.settings.SetOption("CurrentGame", (int)selectedGame);
            SetCurrentGameBtnStatuses();
        }

        private void HaloCombatEvolvedBtn_Click(object sender, RoutedEventArgs e)
        {
            selectedGame = Game.HaloPC;
            config.settings.SetOption("CurrentGame", (int)selectedGame);
            SetCurrentGameBtnStatuses();
        }

        private void GithubBtn_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("https://github.com/AWilliams17/Halo-CE-Mouse-Tool");
        }

        private async void RedditBtn_Click(object sender, RoutedEventArgs e)
        {
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            try
            {
                string readmeLink = "https://raw.githubusercontent.com/AWilliams17/Halo-CE-Mouse-Tool/master/README.md";
                string redditThreadLink = await GithubReadmeParser.GetLineFromReadmeAsync(readmeLink, "Reddit: ", 5, cancellationTokenSource.Token);

                if (redditThreadLink != null)
                {
                    Process.Start(redditThreadLink);
                }
                else MessageBox.Show("Failed to get Reddit thread link from Github Readme.", "Failed to find Reddit thread link");
            }
            catch (WebException ex)
            {
                MessageBox.Show($"Error occurred while getting Reddit thread link from Github Readme: {ex.Message}", "Error getting Reddit thread link");
            }
        }

        private void WriteMemoryBtn_Click(object sender, RoutedEventArgs e)
        {
            WriteToMemory();
        }

        private void WriteToMemory()
        {
            string targetHaloGame = selectedGame.ToString();
            float sensitivityX = SensXUpDown.Value.Value;
            float sensitivityY = SensYUpDown.Value.Value;
            if (HaloMemoryWriter.IsProcessRunning(targetHaloGame.ToLower()))
            {
                bool writeSuccessful = false;
                if (selectedGame == Game.HaloCE)
                    writeSuccessful = HaloMemoryWriter.WriteToCustomEdition(sensitivityX, sensitivityY);
                else
                    writeSuccessful = HaloMemoryWriter.WriteToCombatEvolved(sensitivityX, sensitivityY);
                if (!writeSuccessful)
                    MessageBox.Show($"Error: Failed to write to '{targetHaloGame}' - Error Code: '{Marshal.GetLastWin32Error()}' - Refer to the readme/ask in the thread for help.");
            }
            else
                MessageBox.Show($"Error: '{targetHaloGame}' is not running.", $"{targetHaloGame} Not Running");
        }

        private void MainWindow_Closing(object sender, EventArgs e)
        {
            config.settings.SaveSettings();
            Application.Current.Shutdown();
        }

        private void SetSensitivityBoxes(float SensX, float SensY)
        {
            SensXUpDown.Value = SensX;
            SensYUpDown.Value = SensY;
        }

        private void SensXUpDown_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (e.OldValue != null & e.NewValue != null)
            {
                if ((float)e.NewValue > 0.1)
                {
                    config?.settings.SetOption("SensitivityX", SensXUpDown.Value);
                }
                else SensXUpDown.Value = (float)e.OldValue;
            }
        }

        private void SensYUpDown_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (e.OldValue != null & e.NewValue != null)
            {
                if ((float)e.NewValue > 0.1)
                {
                    config?.settings.SetOption("SensitivityY", SensYUpDown.Value);
                }
                else SensYUpDown.Value = (float)e.OldValue;
            }
        }
    }
}
