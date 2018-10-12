using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Registrar;
using SharpUtils.WPFUtils;
using Halo_Mouse_Tool.Windows;

namespace Halo_Mouse_Tool
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void SettingsBtn_Click(object sender, RoutedEventArgs e)
        {
            
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

        private void HelpBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void GithubBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RedditBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void WriteMemoryBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MainWindow_Closing(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
