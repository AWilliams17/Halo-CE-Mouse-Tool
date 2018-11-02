using Halo_Mouse_Tool.Windows;
using Halo_Mouse_Tool.Classes.ConfigContainer;
using Registrar;
using System;
using System.Windows;
using SharpUtils.WPFUtils;
using System.Diagnostics;
using System.Threading;
using SharpUtils.WebUtils;
using System.Net;

namespace Halo_Mouse_Tool
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private static Config config = new Config();
        private enum CurrentGame {HaloCE, HaloPC, Halo2};

        public MainWindow()
        {
            InitializeComponent();
            Closing += MainWindow_Closing;

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

            SetSensitivityBoxes(config.settings.GetOption<float>("SensitivityX"), config.settings.GetOption<float>("SensitivityY"));
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

        }

        private void HaloCombatEvolvedBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Halo2VistaBtn_Click(object sender, RoutedEventArgs e)
        {

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
    }
}
