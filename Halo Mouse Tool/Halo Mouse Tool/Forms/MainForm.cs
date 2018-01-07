using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Security.Principal;
using System.Reflection;

namespace Halo_Mouse_Tool
{
    public partial class MainForm : Form
    {
        static SettingsForm Settingsform = new SettingsForm();
        static DonateForm Donateform = new DonateForm();
        static Settings settings = new Settings();

        public static bool IsAdministrator()
        { //Detects if the user is admin or not (dur)
            return (new WindowsPrincipal(WindowsIdentity.GetCurrent()))
                      .IsInRole(WindowsBuiltInRole.Administrator);
        }

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                if (UpdateHandlingUtils.UpdateAvailable(5))
                {
                    UpdateStatusLabel.IsLink = true;
                    UpdateStatusLabel.Text = "Yes!";
                }
                else
                {
                    UpdateStatusLabel.Text = "None.";
                }
            }
            catch (System.Net.WebException ex)
            {
                MessageBox.Show("An error occured whilst checking for updates: " + ex.Message, "Update Error");
                UpdateStatusLabel.Text = "Error.";
            }

            string title = "Halo Mouse Tool v" + Assembly.GetExecutingAssembly().GetName().Version.ToString()[0];
            if (!IsAdministrator())
            {
                title += " -NOT ADMIN-";
            }
            Text = title;
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void DonateBtn_Click(object sender, EventArgs e)
        {
            if (!FormHandlingUtils.Formopen(Donateform))
            {
                Donateform = new DonateForm();
            }
            Donateform.Show();
        }

        private void OptionsBtn_Click(object sender, EventArgs e)
        {
            if (!FormHandlingUtils.Formopen(Settingsform))
            {
                Settingsform = new SettingsForm(settings);
            }
            Settingsform.Show();
        }

        private void AboutBtn_Click(object sender, EventArgs e)
        {
            //About
        }

        private void HelpBtn_Click(object sender, EventArgs e)
        {
            //Open Help doc
        }

        private void SaveSettingsBtn_Click(object sender, EventArgs e)
        {
            //Save Settings to Registry
        }

        private void DeployDllBtn_Click(object sender, EventArgs e)
        {
            //Deploy the DLL
        }

        private void CheckForUpdateBtn_Click(object sender, EventArgs e)
        {
            //Check if an update is available
        }

        private void HaloCustomEditionBtn_Click(object sender, EventArgs e)
        {
            //Set the game to Halo CE
        }

        private void HaloCombatEvolvedBtn_Click(object sender, EventArgs e)
        {
            //Set the game to Halo PC
        }

        private void UpdateStatusLabel_Click(object sender, EventArgs e)
        {
            Process.Start(@"https://github.com/AWilliams17/Halo-CE-Mouse-Tool/releases");
        }
    }
}
