using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Security.Principal;
using System.Reflection;
using Microsoft.Win32;
using System.Drawing;
/*
 * I will refactor all this BS out of mainform when it all works lol
 */
namespace Halo_Mouse_Tool
{
    public partial class MainForm : Form
    {
        static Settings settings = new Settings();
        static SettingsForm settingsForm = new SettingsForm(settings);
        static DonateForm donateForm = new DonateForm();

        public static bool IsAdministrator()
        {
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
            catch (Exception ex)
            {
                if (ex is NullReferenceException || ex is ArgumentException || ex is ArgumentOutOfRangeException)
                {
                    MessageBox.Show("One or more settings did not load from the registry. Settings have been restored to defaults. Error message was: " + ex.Message, "Error loading settings");
                    saveSettings();
                }
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
            try
            {
                WriteHaloMemory();
                MessageBox.Show("It work?");
            }
            catch (WriteProcessException ex)
            {
                MessageBox.Show(ex.Message);
            }
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

        private void LoadSettings() //ToDo: Refactor this garbage
        {
            RegistryKey HaloMouseToolRegistry = Registry.CurrentUser.OpenSubKey("Software\\HaloMouseTool", false);
            if (HaloMouseToolRegistry == null)
            {
                saveSettings();
            }
            else
            {
                object sensX = HaloMouseToolRegistry.GetValue("SensX");
                object sensY = HaloMouseToolRegistry.GetValue("SensY");
                object mouseAcceleration = HaloMouseToolRegistry.GetValue("PatchMouseAcceleration");
                object hotKeyApplication = HaloMouseToolRegistry.GetValue("HotkeyApplication");
                object hotKeyDll = HaloMouseToolRegistry.GetValue("HotkeyDll");

                object incrementAmount = HaloMouseToolRegistry.GetValue("IncrementAmount");
                object incrementEnabled = HaloMouseToolRegistry.GetValue("IncrementKeysEnabled");
                object incrementEnabledDll = HaloMouseToolRegistry.GetValue("IncrementKeysEnabledDll");
                object currentGame = HaloMouseToolRegistry.GetValue("CurrentGame");

                object checkForUpdates = HaloMouseToolRegistry.GetValue("CheckForUpdates");
                object updateTimeout = HaloMouseToolRegistry.GetValue("UpdateTimeout");
                object soundsEnabled = HaloMouseToolRegistry.GetValue("SoundsEnabled");
                object soundsEnabledDll = HaloMouseToolRegistry.GetValue("SoundsEnabledDll");
                object successMessages = HaloMouseToolRegistry.GetValue("SuccessMessages");
                object successMessagesDll = HaloMouseToolRegistry.GetValue("SuccessMessagesDll");

                settings.SensX = float.Parse(sensX.ToString());
                settings.SensY = float.Parse(sensY.ToString());
                if (mouseAcceleration.ToString() == "0")
                {
                    settings.PatchAcceleration = false;
                }
                settings.HotKeyApplication = hotKeyApplication.ToString();
                settings.HotKeyDll = hotKeyDll.ToString();
                if (checkForUpdates.ToString() == "0")
                {
                    settings.CheckForUpdates = false;
                }
                settings.UpdateTimeout = int.Parse(updateTimeout.ToString());
                if (soundsEnabled.ToString() == "0")
                {
                    settings.SoundsEnabled = false;
                }
                if (soundsEnabledDll.ToString() == "0")
                {
                    settings.SoundsEnabledDll = false;
                }
                if (successMessages.ToString() == "0")
                {
                    settings.SuccessMessages = false;
                }
                if(successMessagesDll.ToString() == "0")
                {
                    settings.SuccessMessagesDll = false;
                }
                if (incrementEnabled.ToString() == "0")
                {
                    settings.IncrementKeysEnabled = false;
                }
                if (incrementEnabledDll.ToString() == "0")
                {
                    settings.IncrementKeysEnabledDll = false;
                }
                if ((int)currentGame == 1)
                {
                    settings.Current_Game = Settings.Game.CombatEvolved;
                }
                settings.IncrementAmount = float.Parse(incrementAmount.ToString());
            }
        }

        private void saveSettings() //ToDo: Refactor this garbage.
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

            if (settings.SuccessMessagesDll)
            {
                Registry.SetValue("HKEY_CURRENT_USER\\Software\\HaloMouseTool", "SuccessMessagesDll", 1, RegistryValueKind.DWord);
            }
            else
            {
                Registry.SetValue("HKEY_CURRENT_USER\\Software\\HaloMouseTool", "SuccessMessagesDll", 0, RegistryValueKind.DWord);
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

        private void WriteHaloMemory() //ToDo: Refactor this garbage lol
        {
            byte[] mouseaccelnop = { 0x90, 0x90, 0x90, 0x90, 0x90, 0x90 }; //For noping the acceleration
            int currAddr = 0;
            byte[] currVal = { };
            string game;
            if (settings.Current_Game == Settings.Game.CombatEvolved)
            {
                game = "halo";
                for (int i = 0; i != 3; i++)
                {
                    if (i == 0)
                    {
                        currVal = BitConverter.GetBytes((settings.SensX * 0.25F));
                        currAddr = 0x310B50;
                    }
                    if (i == 1)
                    {
                        currVal = BitConverter.GetBytes((settings.SensY * 0.25F));
                        currAddr = 0x310B54;
                    }
                    if (i == 2 && settings.PatchAcceleration)
                    {
                        currVal = mouseaccelnop;
                        currAddr = 0x963C0;
                    }
                    MemoryHandlingUtils.WriteToProcessMemory(game, currVal, currAddr);
                }
            }
            else
            {
                game = "haloce";
                for (int i = 0; i != 3; i++)
                {
                    if (i == 0)
                    {
                        currVal = BitConverter.GetBytes((settings.SensX * 0.25F));
                        currAddr = 0x2ABB50;
                    }
                    if (i == 1)
                    {
                        currVal = BitConverter.GetBytes((settings.SensY * 0.25F));
                        currAddr = 0x2ABB54;
                    }
                    if (i == 2 && settings.PatchAcceleration)
                    {
                        currVal = mouseaccelnop;
                        currAddr = 0x8F836;
                    }
                    if (i == 3 && settings.PatchAcceleration)
                    {
                        currVal = mouseaccelnop;
                        currAddr = 0x8F830;
                    }
                    MemoryHandlingUtils.WriteToProcessMemory(game, currVal, currAddr);
                }
            }
        }

        private void StatusTimer_Tick(object sender, EventArgs e)
        {
            string status;
            string game;
            string proc;
            if (settings.Current_Game == Settings.Game.CombatEvolved)
            {
                game = "Halo PC";
                proc = "halo";
            }
            else
            {
                game = "Halo CE";
                proc = "haloce";
            }
            Color labelColor;
            if (ProcessHandlingUtils.ProcessIsRunning(proc))
            {
                labelColor = Color.Green;
                status = game + " found.";
                WriteBtn.Enabled = true;
            }
            else
            {
                labelColor = Color.Red;
                status = game + " not found.";
                WriteBtn.Enabled = false;
            }
            HaloStatusLabel.Text = status;
            HaloStatusLabel.ForeColor = labelColor;
        }

        private void HotkeyLabelTimer_Tick(object sender, EventArgs e)
        {
            if (settings.HotKeyEnabled)
            {
                HotkeyLabel.Text = settings.HotKeyApplication;
            }
            else
            {
                HotkeyLabel.Text = "Disabled.";
            }
        }

        private void HotkeyTimer_Tick(object sender, EventArgs e)
        {
            if (WriteBtn.Enabled && settings.HotKeyEnabled)
            {
                if (KeybindHandlingUtils.IsKeyPushedDown((Keys)Enum.Parse(typeof(Keys), settings.HotKeyApplication)))
                {
                    WriteHaloMemory();
                }
            }
        }

        private void SensXTextBox_TextChanged(object sender, EventArgs e)
        {
            float res;
            if (!float.TryParse(SensXTextBox.Text, out res))
            {
                MessageBox.Show("");
                SensXTextBox.Text = "0";
                SensXTextBox.Focus();
            }
        }

        private void SensYTextBox_TextChanged(object sender, EventArgs e)
        {
            float res;
            if (!float.TryParse(SensYTextBox.Text, out res))
            {
                MessageBox.Show("");
                SensYTextBox.Text = "0";
                SensYTextBox.Focus();
            }
        }

        private void SensYTextBox_Leave(object sender, EventArgs e)
        {
            if (SensYTextBox.Text == "")
            {
                MessageBox.Show("");
                SensXTextBox.Focus();
            }
        }

        private void SensXTextBox_Leave(object sender, EventArgs e)
        {
            if (SensXTextBox.Text == "")
            {
                MessageBox.Show("");
                SensXTextBox.Focus();
            }
        }

        private void SensYTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.OemMinus || e.KeyData == Keys.Space)
            {
                MessageBox.Show("");
                SensXTextBox.Text = "0";
            }
        }

        private void SensXTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.OemMinus || e.KeyData == Keys.Space)
            {
                MessageBox.Show("");
                SensXTextBox.Text = "0";
            }
        }

        private void MessageBoxSnd(string title, string text, SoundHandlingUtils.SoundType soundtype)
        {
            MessageBox.Show(text, title);
            if (settings.SoundsEnabled)
            {
                if (soundtype == SoundHandlingUtils.SoundType.Success)
                {
                    SoundHandlingUtils.sound_success();
                }

                if (soundtype == SoundHandlingUtils.SoundType.Error)
                {
                    SoundHandlingUtils.sound_error();
                }

                if (soundtype == SoundHandlingUtils.SoundType.IncrementError)
                {
                    SoundHandlingUtils.sound_incrementerror();
                }

                if (soundtype == SoundHandlingUtils.SoundType.Alert)
                {
                    SoundHandlingUtils.sound_alert();
                }
            }
        }
    }
}
