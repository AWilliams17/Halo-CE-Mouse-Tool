using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Security.Principal;
using System.Reflection;
using Microsoft.Win32;

namespace Halo_Mouse_Tool
{
    public partial class MainForm : Form
    {
        static Settings settings = new Settings();
        static SettingsForm settingsForm = new SettingsForm(settings);
        static DonateForm donateForm = new DonateForm();

        public static bool IsAdministrator()
        { //Detects if the user is admin or not (dur)
            return (new WindowsPrincipal(WindowsIdentity.GetCurrent()))
                      .IsInRole(WindowsBuiltInRole.Administrator);
        }

        public MainForm()
        {
            InitializeComponent();
            AppDomain.CurrentDomain.ProcessExit += OnProcessExit;
        }

        private void OnProcessExit(object sender, EventArgs e)
        {
            saveSettings();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                LoadSettings();
            }
            catch (NullReferenceException) //1 or more settings == null
            {
                MessageBox.Show("One or more settings did not load from the registry. They have been set to the default values and will be saved on exit.");
            }

            if (settings.CheckForUpdates)
            {
                CheckForUpdates();
            }

            string title = "Halo Mouse Tool v" + Assembly.GetExecutingAssembly().GetName().Version.ToString()[0];
            if (!IsAdministrator())
            {
                title += " -NOT ADMIN-";
            }
            Text = title;

            setControls();
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void DonateBtn_Click(object sender, EventArgs e)
        {
            if (!FormHandlingUtils.Formopen(donateForm))
            {
                donateForm = new DonateForm();
            }
            donateForm.Show();
        }

        private void OptionsBtn_Click(object sender, EventArgs e)
        {
            if (!FormHandlingUtils.Formopen(settingsForm))
            {
                settingsForm = new SettingsForm(settings);
            }
            settingsForm.Show();
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
            saveSettings();
        }

        private void DeployDllBtn_Click(object sender, EventArgs e)
        {
            //Deploy the DLL
        }

        private void CheckForUpdateBtn_Click(object sender, EventArgs e)
        {
            CheckForUpdates();
        }

        private void HaloCustomEditionBtn_Click(object sender, EventArgs e)
        {
            settings.Current_Game = Settings.Game.CustomEdition;
            HaloCustomEditionBtn.Checked = true;
            HaloCombatEvolvedBtn.Checked = false;
        }

        private void HaloCombatEvolvedBtn_Click(object sender, EventArgs e)
        {
            settings.Current_Game = Settings.Game.CombatEvolved;
            HaloCustomEditionBtn.Checked = false;
            HaloCombatEvolvedBtn.Checked = true;
        }

        private void UpdateStatusLabel_Click(object sender, EventArgs e)
        {
            Process.Start(@"https://github.com/AWilliams17/Halo-CE-Mouse-Tool/releases");
        }

        private void WriteBtn_Click(object sender, EventArgs e)
        {

        }

        private void CheckForUpdates()
        {
            try
            {
                if (UpdateHandlingUtils.UpdateAvailable(settings.UpdateTimeout))
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
        }

        private void LoadSettings()
        {
            RegistryKey HaloMouseToolRegistry = Registry.CurrentUser.OpenSubKey("Software\\HaloMouseTool", false);
            if (HaloMouseToolRegistry == null) //The registry key doesn't exist.
            {
                saveSettings(); //Generate new one with default values
            }
            else
            {
                object sensX = HaloMouseToolRegistry.GetValue("SensX");
                object sensY = HaloMouseToolRegistry.GetValue("SensY");
                object mouseAcceleration = HaloMouseToolRegistry.GetValue("MouseAcceleration");
                object hotKeyApplication = HaloMouseToolRegistry.GetValue("HotkeyApplication");
                object hotKeyDll = HaloMouseToolRegistry.GetValue("HotkeyDll");
                object checkForUpdates = HaloMouseToolRegistry.GetValue("CheckForUpdates");
                object updateTimeout = HaloMouseToolRegistry.GetValue("UpdateTimeout");
                object soundsEnabled = HaloMouseToolRegistry.GetValue("SoundsEnabled");
                object soundsEnabledDll = HaloMouseToolRegistry.GetValue("SoundsEnabledDll");
                object successMessages = HaloMouseToolRegistry.GetValue("SuccessMessages");
            }
        }

        private void saveSettings()
        {
            Registry.SetValue("HKEY_CURRENT_USER\\Software\\HaloMouseTool", "SensX", settings.SensX, RegistryValueKind.String);
            Registry.SetValue("HKEY_CURRENT_USER\\Software\\HaloMouseTool", "SensY", settings.SensY, RegistryValueKind.String);
            if (settings.PatchAcceleration)
            {
                Registry.SetValue("HKEY_CURRENT_USER\\Software\\HaloMouseTool", "PatchMouseAcceleration", 1, RegistryValueKind.DWord);
            }
            else
            {
                Registry.SetValue("HKEY_CURRENT_USER\\Software\\HaloMouseTool", "PatchMouseAcceleration", 0, RegistryValueKind.DWord);
            }
            Registry.SetValue("HKEY_CURRENT_USER\\Software\\HaloMouseTool", "HotkeyApplication", settings.HotKeyApplication, RegistryValueKind.String);
            Registry.SetValue("HKEY_CURRENT_USER\\Software\\HaloMouseTool", "HotkeyDll", settings.HotKeyDll, RegistryValueKind.String);
            if (settings.CheckForUpdates)
            {
                Registry.SetValue("HKEY_CURRENT_USER\\Software\\HaloMouseTool", "CheckForUpdates", 1, RegistryValueKind.DWord);
            }
            else
            {
                Registry.SetValue("HKEY_CURRENT_USER\\Software\\HaloMouseTool", "CheckForUpdates", 0, RegistryValueKind.DWord);
            }

            Registry.SetValue("HKEY_CURRENT_USER\\Software\\HaloMouseTool", "UpdateTimeout", settings.UpdateTimeout, RegistryValueKind.DWord);

            if (settings.HotKeyEnabled)
            {
                Registry.SetValue("HKEY_CURRENT_USER\\Software\\HaloMouseTool", "HotKeyEnabled", 1, RegistryValueKind.DWord);
            }
            else
            {
                Registry.SetValue("HKEY_CURRENT_USER\\Software\\HaloMouseTool", "HotKeyEnabled", 0, RegistryValueKind.DWord);
            }

            if (settings.SoundsEnabled)
            {
                Registry.SetValue("HKEY_CURRENT_USER\\Software\\HaloMouseTool", "SoundsEnabled", 1, RegistryValueKind.DWord);
            }
            else
            {
                Registry.SetValue("HKEY_CURRENT_USER\\Software\\HaloMouseTool", "SoundsEnabled", 0, RegistryValueKind.DWord);
            }

            if (settings.SoundsEnabledDll)
            {
                Registry.SetValue("HKEY_CURRENT_USER\\Software\\HaloMouseTool", "SoundsEnabledDll", 1, RegistryValueKind.DWord);
            }
            else
            {
                Registry.SetValue("HKEY_CURRENT_USER\\Software\\HaloMouseTool", "SoundsEnabledDll", 0, RegistryValueKind.DWord);
            }

            if (settings.SuccessMessages)
            {
                Registry.SetValue("HKEY_CURRENT_USER\\Software\\HaloMouseTool", "SuccessMessages", 1, RegistryValueKind.DWord);
            }
            else
            {
                Registry.SetValue("HKEY_CURRENT_USER\\Software\\HaloMouseTool", "SuccessMessages", 0, RegistryValueKind.DWord);
            }

            if (settings.Current_Game == Settings.Game.CombatEvolved)
            {
                Registry.SetValue("HKEY_CURRENT_USER\\Software\\HaloMouseTool", "CurrentGame", 1, RegistryValueKind.DWord);
            }
            else
            {
                Registry.SetValue("HKEY_CURRENT_USER\\Software\\HaloMouseTool", "CurrentGame", 0, RegistryValueKind.DWord);
            }

            if (settings.IncrementKeysEnabled)
            {
                Registry.SetValue("HKEY_CURRENT_USER\\Software\\HaloMouseTool", "IncrementKeysEnabled", 1, RegistryValueKind.DWord);
            }
            else
            {
                Registry.SetValue("HKEY_CURRENT_USER\\Software\\HaloMouseTool", "IncrementKeysEnabled", 0, RegistryValueKind.DWord);
            }

            if (settings.IncrementKeysEnabledDll)
            {
                Registry.SetValue("HKEY_CURRENT_USER\\Software\\HaloMouseTool", "IncrementKeysEnabledDll", 1, RegistryValueKind.DWord);
            }
            else
            {
                Registry.SetValue("HKEY_CURRENT_USER\\Software\\HaloMouseTool", "IncrementKeysEnabledDll", 0, RegistryValueKind.DWord);
            }
            Registry.SetValue("HKEY_CURRENT_USER\\Software\\HaloMouseTool", "IncrementAmount", settings.IncrementAmount, RegistryValueKind.String);
        }

        private void setControls()
        {
            SensXTextBox.Text = settings.SensX.ToString();
            SensYTextBox.Text = settings.SensY.ToString();
            if (settings.Current_Game == Settings.Game.CustomEdition)
            {
                HaloCustomEditionBtn.Checked = true;
                HaloCombatEvolvedBtn.Checked = false;
            }
            else
            {
                HaloCustomEditionBtn.Checked = false;
                HaloCombatEvolvedBtn.Checked = true;
            }
        }
    }
}
