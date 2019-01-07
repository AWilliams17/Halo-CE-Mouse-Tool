using Halo_Mouse_Tool.Windows;
using Halo_Mouse_Tool.Classes.ConfigContainer;
using Halo_Mouse_Tool.Classes.HaloMemoryWriter;
using Halo_Mouse_Tool.Classes.KeybindUtils;
using Registrar;
using SharpUtils.WebUtils;
using SharpUtils.WPFUtils;
using SharpUtils.MiscUtils;
using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Diagnostics;
using System.Threading;
using System.Net;
using System.Windows.Input;
using System.Windows.Threading;
using Keys = System.Windows.Forms.Keys;

namespace Halo_Mouse_Tool
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private enum Game {HaloPC, HaloCE};
        private Game selectedGame;
        private Config config = new Config();
        private DispatcherTimer hotkeyListener = new DispatcherTimer();
        private KeyConverter keyConverter = new KeyConverter();

        public MainWindow()
        {
            InitializeComponent();
            InitializeApplication();
            Closing += MainWindow_Closing;
        }
        
        private void InitializeApplication()
        {
            DoAdminCheck();
            LoadSettings();
            selectedGame = (Game)config.settings.GetOption<int>("CurrentGame");
            SetSensitivityBoxes(config.settings.GetOption<float>("SensitivityX"), config.settings.GetOption<float>("SensitivityY"));
            SetCurrentGameBtnStatuses();
            SetWindowTitle();
            StartHotkeyListener();
        }

        private void StartHotkeyListener()
        {
            if (!hotkeyListener.IsEnabled)
            {
                hotkeyListener.Tick += HotkeyListener_Tick;
                hotkeyListener.Interval = new TimeSpan(0, 0, 0, 0, 25);
                hotkeyListener.Start();
            }
        }

        private void LoadSettings()
        {
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
                    System.Media.SystemSounds.Hand.Play();
                    MessageBox.Show($"Failed to save default settings. Error message: {ex.Message}", "Error while saving settings to Registry.");
                }
            }
        }

        private void DoAdminCheck()
        {
            if (!AdminCheckHelper.IsRunningAsAdmin())
            {
                System.Media.SystemSounds.Hand.Play();
                MessageBox.Show("This application requires you to run it as an administrator to work properly. " +
                    "Please re-run as administrator.", "Not Admin!");
                Application.Current.Shutdown();
            }
        }

        private void SetWindowTitle()
        {
            string currentVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            string windowTitle = $"Halo Mouse Tool v{currentVersion.Substring(0, currentVersion.Length - 4)}";
            Title = windowTitle;
        }

        private void SetSensitivityBoxes(float SensX, float SensY)
        {
            (SensXUpDown.Value, SensYUpDown.Value) = (SensX, SensY);
        }

        private void SetCurrentGameBtnStatuses()
        {
            HaloCustomEditionBtn.IsChecked = (selectedGame == Game.HaloCE);
            HaloCombatEvolvedBtn.IsChecked = (selectedGame == Game.HaloPC);
        }
        
        private void SettingsBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!WindowHelpers.IsWindowOpen(typeof(SettingsWindow)))
            {
                SettingsWindow settingsWindow = new SettingsWindow(config);
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
                else
                {
                    System.Media.SystemSounds.Asterisk.Play();
                    MessageBox.Show("Failed to get Reddit thread link from Github Readme.", "Failed to find Reddit thread link");
                }
            }
            catch (WebException ex)
            {
                System.Media.SystemSounds.Hand.Play();
                MessageBox.Show($"Error occurred while getting Reddit thread link from Github Readme: {ex.Message}", "Error getting Reddit thread link");
            }
        }

        private void WriteMemoryBtn_Click(object sender, RoutedEventArgs e)
        {
            WriteToMemory();
        }

        private void MainWindow_Closing(object sender, EventArgs e)
        {
            config.settings.SaveSettings();
            Application.Current.Shutdown();
        }

        private void HotkeyListener_Tick(object sender, EventArgs e)
        {
            if (config.settings.GetOption<int>("HotkeyEnabled") == 1)
            {
                Keys hotKey = (Keys)Enum.Parse(typeof(Keys), config.settings.GetOption<string>("Hotkey"));
                if (KeybindUtils.IsKeyPushedDown(hotKey))
                {
                    WriteToMemory();
                }
            }

            if (config.settings.GetOption<int>("IncrementHotkeysEnabled") == 1)
            {
                if (KeybindUtils.IsKeyPushedDown(Keys.Oemplus))
                {
                    SensXUpDown.Value += config.settings.GetOption<float>("IncrementAmount");
                    SensYUpDown.Value += config.settings.GetOption<float>("IncrementAmount");
                    WriteToMemory();
                }
                if (KeybindUtils.IsKeyPushedDown(Keys.OemMinus))
                {
                    SensXUpDown.Value -= config.settings.GetOption<float>("IncrementAmount");
                    SensYUpDown.Value -= config.settings.GetOption<float>("IncrementAmount");
                    WriteToMemory();
                }
            }
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
                {
                    System.Media.SystemSounds.Hand.Play();
                    MessageBox.Show($"Error: Failed to write to '{targetHaloGame}' - Error Code: '{Marshal.GetLastWin32Error()}' - " +
                        $"Refer to the readme/ask in the thread for help.");
                }
                else Console.Beep(250, 200);
            }
            else
            {
                System.Media.SystemSounds.Asterisk.Play();
                MessageBox.Show($"Error: '{targetHaloGame}' is not running.", $"{targetHaloGame} Not Running");
            }
        }
    }
}
