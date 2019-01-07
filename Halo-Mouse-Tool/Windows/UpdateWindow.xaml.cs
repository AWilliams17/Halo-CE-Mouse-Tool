using SharpUtils.WebUtils;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Threading;
using System.Windows;
using System.Windows.Threading;

namespace Halo_Mouse_Tool.Windows
{
    /// <summary>
    /// Interaction logic for UpdateWindow.xaml
    /// </summary>
    public partial class UpdateWindow // TODO: Re-write this mess.
    {
        private bool checkInProgress = false;
        private CancellationTokenSource cancellationTokenSource;
        private DispatcherTimer updateTimeoutTimer = new DispatcherTimer();
        private int timeoutCountdown;

        private void UpdateTimeoutTimer_Tick(object sender, EventArgs e)
        {
            UpdateCheckBtn.Content = $"Timeout in {timeoutCountdown -= 1}... (Press to cancel)";
        }

        public UpdateWindow()
        {
            InitializeComponent();
            Closing += OnWindowClosing;
            updateTimeoutTimer.Tick += UpdateTimeoutTimer_Tick;
            updateTimeoutTimer.Interval = new TimeSpan(0, 0, 1);
        }

        private void UpdateCheckBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!checkInProgress)
            {
                StartUpdateCheck();
            }
            else
            {
                StopUpdateCheck();
            }
        }

        private async void StartUpdateCheck()
        {
            cancellationTokenSource = new CancellationTokenSource();
            updateTimeoutTimer.Start();
            TimeoutUpDown.IsEnabled = false;
            checkInProgress = true;
            int updateTimeOut = (int)TimeoutUpDown.Value;
            timeoutCountdown = updateTimeOut;
            try
            {
                string currentVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
                bool updateAvailable = await GithubReleaseParser.GetUpdateAvailableAsync(currentVersion, "AWilliams17", "Halo-CE-Mouse-Tool", updateTimeOut, cancellationTokenSource.Token);
                ShowUpdateAvailableDialog(updateAvailable);
            }
            catch (WebException ex)
            {
                System.Media.SystemSounds.Hand.Play();
                MessageBox.Show($"Update Check Failed: '{ex.Message}'", "Update Check Failed");
            }
            finally
            {
                StopUpdateCheck();
            }
        }

        private void StopUpdateCheck()
        {
            TimeoutUpDown.IsEnabled = true;
            updateTimeoutTimer.Stop();
            UpdateCheckBtn.Content = "Check for Updates";
            if (checkInProgress)
            {
                checkInProgress = false;
                if (cancellationTokenSource.IsCancellationRequested)
                {
                    cancellationTokenSource.Cancel();
                    System.Media.SystemSounds.Asterisk.Play();
                    MessageBox.Show("Update Check was cancelled.", "Update cancelled");
                }
            }
        }

        private void ShowUpdateAvailableDialog(bool UpdateAvailable)
        {
            StopUpdateCheck();
            if (!UpdateAvailable)
            {
                System.Media.SystemSounds.Asterisk.Play();
                MessageBox.Show("No updates are available.", "No updates found");
            }
            else
            {
                System.Media.SystemSounds.Exclamation.Play();
                string updateAvailableMessage = "An update is available. Would you like to go to the download page?";
                var userAction = MessageBox.Show(updateAvailableMessage, "Update Available", MessageBoxButton.YesNo);
                if (userAction == MessageBoxResult.Yes)
                {
                    Process.Start("https://github.com/AWilliams17/Halo-CE-Mouse-Tool");
                }
            }
        }

        public void OnWindowClosing(object sender, CancelEventArgs e)
        {
            if (cancellationTokenSource != null)
                cancellationTokenSource.Cancel();
        }
    }
}
