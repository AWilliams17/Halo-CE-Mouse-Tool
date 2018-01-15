using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Reflection;
using System.Drawing;
using System.IO;

namespace Halo_Mouse_Tool
{
    public partial class MainForm : Form
    {
        static Settings settings = new Settings();
        static SettingsForm settingsForm = new SettingsForm(settings);
        static DonateForm donateForm = new DonateForm();
        static AboutForm aboutForm = new AboutForm();
        KeysConverter kc = new KeysConverter();

        public MainForm()
        {
            InitializeComponent();
            AppDomain.CurrentDomain.ProcessExit += OnProcessExit;
        }

        private void OnProcessExit(object sender, EventArgs e)
        {
            settings.SaveSettings();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                settings.LoadSettings();
            }
            catch (Exception ex)
            {
                if (ex is NullReferenceException || ex is ArgumentException || ex is ArgumentOutOfRangeException)
                {
                    MessageBoxSnd("Error loading registry", "Failed to load settings from the registry. Settings reset to defaults. Error Message: " + ex.Message, SoundHandlingUtils.SoundType.Error);
                    settings.SaveSettings();
                }
            }

            if (settings.CheckForUpdates)
            {
                CheckForUpdates();
            }

            string title = "Halo Mouse Tool v" + Assembly.GetExecutingAssembly().GetName().Version.ToString()[0];
            if (!MiscUtils.IsAdministrator())
            {
                title += " -NOT ADMIN-";
            }
            Text = title;

            SetControls();
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
            if (!FormHandlingUtils.Formopen(donateForm))
            {
                aboutForm = new AboutForm();
            }
            aboutForm.Show();
        }

        private void HelpBtn_Click(object sender, EventArgs e)
        {
            MiscUtils.ShowHelp(this);
        }

        private void DeployDllBtn_Click(object sender, EventArgs e)
        {
            DeployDLL();
        }

        private void CheckForUpdateBtn_Click(object sender, EventArgs e)
        {
            CheckForUpdates(true);
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
            if (UpdateStatusLabel.IsLink)
            {
                Process.Start(@"https://github.com/AWilliams17/Halo-CE-Mouse-Tool/releases");
            }
        }

        private void WriteBtn_Click(object sender, EventArgs e) //Note: SuccessMessages needs to be added
        {
            try
            {
                MiscUtils.WriteHaloMemory(settings);
                if (settings.SoundsEnabled && !settings.SuccessMessages) {
                    SoundHandlingUtils.sound_success();
                }
                else //Success messages are enabled, and the messageboxsnd function has a sound setting check, so just call that.
                {
                    MessageBoxSnd("Success", "Successfully wrote to memory.", SoundHandlingUtils.SoundType.Success);
                }
            }
            catch (WriteProcessException ex)
            {
                MessageBoxSnd("Failed to write to memory", ex.Message, SoundHandlingUtils.SoundType.Error);
            }
        }

        private void CheckForUpdates(bool messageBox = false)
        {
            try
            {
                if (UpdateHandlingUtils.UpdateAvailable(settings.UpdateTimeout))
                {
                    UpdateStatusLabel.IsLink = true;
                    UpdateStatusLabel.Text = "Yes!";
                    if (messageBox)
                    {
                        MessageBoxSnd("Update available", "An update is available.", SoundHandlingUtils.SoundType.Alert);
                    }
                }
                else
                {
                    UpdateStatusLabel.Text = "None.";
                    if (messageBox)
                    {
                        MessageBoxSnd("No updates found", "No updates found.", SoundHandlingUtils.SoundType.Alert);
                    }
                }
            }
            catch (System.Net.WebException ex)
            {
                MessageBoxSnd("Update Error", "An error occurred while checking for updates: " + ex.Message, SoundHandlingUtils.SoundType.Error);
                UpdateStatusLabel.Text = "Error.";
            }
        }

        private void SetControls()
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

            if (settings.PatchAcceleration)
            {
                patchMouseAccelerationToolStripMenuItem.Checked = true;
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
            settings.SaveSettings();
        }

        private void HotkeyLabelTimer_Tick(object sender, EventArgs e)
        {
            if (settings.HotKeyEnabled)
            {
                HotkeyLabel.Text = kc.ConvertToString(settings.HotKeyApplication);
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
                if (KeybindHandlingUtils.IsKeyPushedDown((Keys)Enum.Parse(typeof(Keys), ((Keys)settings.HotKeyApplication).ToString())))
                {
                    try
                    {
                        MiscUtils.WriteHaloMemory(settings);
                        if (settings.SoundsEnabled && !settings.SuccessMessages)
                        {
                            SoundHandlingUtils.sound_success();
                        }
                        else //Success messages are enabled, and the messageboxsnd function has a sound setting check, so just call that.
                        {
                            MessageBoxSnd("Success", "Successfully wrote to memory.", SoundHandlingUtils.SoundType.Success);
                        }
                    }
                    catch (WriteProcessException ex)
                    {
                        MessageBoxSnd("Failed to write to memory", ex.Message, SoundHandlingUtils.SoundType.Error);
                    }
                }
            }

            if (WriteBtn.Enabled && settings.IncrementKeysEnabled) //ToDo: these error messages are horrible. Fix them.
            {
                if (KeybindHandlingUtils.IsKeyPushedDown(Keys.Oemplus))
                {
                    try
                    {
                        settings.SensX = settings.SensX += settings.IncrementAmount;
                        settings.SensY = settings.SensY += settings.IncrementAmount;
                        MiscUtils.WriteHaloMemory(settings);
                        if (settings.SoundsEnabled && !settings.SuccessMessages)
                        {
                            SoundHandlingUtils.sound_success();
                        }
                        else //Success messages are enabled, and the messageboxsnd function has a sound setting check, so just call that.
                        {
                            MessageBoxSnd("Success", "Successfully wrote to memory.", SoundHandlingUtils.SoundType.Success);
                        }
                        SensXTextBox.Text = settings.SensX.ToString();
                        SensYTextBox.Text = settings.SensY.ToString();
                    }
                    catch (ArgumentOutOfRangeException ex)
                    {
                        MessageBoxSnd("Invalid setting", ex.Message, SoundHandlingUtils.SoundType.Error);
                    }
                    catch (WriteProcessException ex)
                    {
                        MessageBoxSnd("Failed to write memory.", ex.Message, SoundHandlingUtils.SoundType.Error);
                    }
                }

                else if (KeybindHandlingUtils.IsKeyPushedDown(Keys.OemMinus))
                {
                    try
                    {
                        settings.SensX = settings.SensX -= settings.IncrementAmount;
                        settings.SensY = settings.SensY -= settings.IncrementAmount;
                        MiscUtils.WriteHaloMemory(settings);
                        if (settings.SoundsEnabled && !settings.SuccessMessages)
                        {
                            SoundHandlingUtils.sound_success();
                        }
                        else //Success messages are enabled, and the messageboxsnd function has a sound setting check, so just call that.
                        {
                            MessageBoxSnd("Success", "Successfully wrote to memory.", SoundHandlingUtils.SoundType.Success);
                        }
                        SensXTextBox.Text = settings.SensX.ToString();
                        SensYTextBox.Text = settings.SensY.ToString();
                    }
                    catch (ArgumentOutOfRangeException ex)
                    {
                        MessageBoxSnd("Invalid setting", ex.Message, SoundHandlingUtils.SoundType.Error);
                    }
                    catch (WriteProcessException ex)
                    {
                        MessageBoxSnd("Failed to write memory.", ex.Message, SoundHandlingUtils.SoundType.Error);
                    }
                }
            }
        }

        private void SensXTextBox_TextChanged(object sender, EventArgs e)
        {
            MiscUtils.TextboxResult t = MiscUtils.TextboxValid(SensXTextBox);
            if (t != MiscUtils.TextboxResult.valid)
            {
                if (t != MiscUtils.TextboxResult.is_empty)
                {
                    SensXTextBox.Text = "";
                    SoundHandlingUtils.sound_error();
                }
            }
            else
            {
                settings.SensX = float.Parse(SensXTextBox.Text);
            }
        }

        private void SensYTextBox_TextChanged(object sender, EventArgs e)
        {
            MiscUtils.TextboxResult t = MiscUtils.TextboxValid(SensYTextBox);
            if (t != MiscUtils.TextboxResult.valid)
            {
                if (t != MiscUtils.TextboxResult.is_empty)
                {
                    SensYTextBox.Text = "0";
                    SoundHandlingUtils.sound_error();
                    SensYTextBox.Focus();
                }
            }
            else
            {
                settings.SensY = float.Parse(SensYTextBox.Text);
            }
        }

        private void SensYTextBox_Leave(object sender, EventArgs e)
        {
            if (MiscUtils.TextboxValid(SensYTextBox) == MiscUtils.TextboxResult.is_empty)
            {
                SoundHandlingUtils.sound_error();
                SensYTextBox.Focus();
            }
        }

        private void SensXTextBox_Leave(object sender, EventArgs e)
        {
            if (MiscUtils.TextboxValid(SensXTextBox) == MiscUtils.TextboxResult.is_empty)
            {
                SoundHandlingUtils.sound_error();
                SensXTextBox.Focus();
            }
        }

        private void MessageBoxSnd(string title, string text, SoundHandlingUtils.SoundType soundtype)
        {
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
            MessageBox.Show(text, title);
        }

        private void DeployDLL()
        {
            using (var fbd = new FolderBrowserDialog())
            {
                string description =
                    "Select the Halo CE/SPV3 Controls directory." + Environment.NewLine +
                    "If you wish to only use this for SPV3, you just have to select SPV3's control directory. " +
                    "If you want to use it for Halo CE, select Halo CE's control directory." +
                    "For reference, this folder will have a dll in it called 'controls.dll'.";
                fbd.ShowNewFolderButton = false;
                fbd.Description = description;
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    bool validselection = false;
                    try
                    {
                        string[] files = Directory.GetFiles(fbd.SelectedPath);
                        for (int i = 0; i < files.Length; i++)
                        {
                            if (files[i].ToLower().Contains("controls.dll"))
                            {
                                validselection = true;
                                break;
                            }
                        }
                        if (validselection)
                        {
                            if (settings.Current_Game == Settings.Game.CombatEvolved)
                            {
                                string dll = Path.Combine(fbd.SelectedPath, "HaloCombatEvolvedMouseFix.dll");
                                File.WriteAllBytes(dll, Properties.Resources.HaloCombatEvolvedMouseFix);
                            }
                            else
                            {
                                string dll = Path.Combine(fbd.SelectedPath, "HaloCustomEditionMouseFix.dll");
                                File.WriteAllBytes(dll, Properties.Resources.HaloCustomEditionMouseFix);
                            }
                            string successMsg =
                                "Successfully deployed DLL to controls folder." +
                                " All you must do from here is just set your settings in this application, and then make sure you have saved them " +
                                "(file -> save settings just to be sure), run the game, and press your hotkey!";
                            MessageBoxSnd("Successfully deployed DLL", successMsg, SoundHandlingUtils.SoundType.Success);
                        }
                        else
                        {
                            MessageBoxSnd("Wrong folder!", "Error - the selected folder did not have a controls.dll file.", SoundHandlingUtils.SoundType.Error);
                        }
                    }
                    catch (UnauthorizedAccessException)
                    {
                        MessageBoxSnd("Access Denied!", "Error - you do not have access to this location. Are you running as admin?", SoundHandlingUtils.SoundType.Error);
                    }
                }
            }
        }

        private void patchMouseAccelerationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (settings.PatchAcceleration)
            {
                patchMouseAccelerationToolStripMenuItem.Checked = false;
                settings.PatchAcceleration = false;
            }
            else
            {
                patchMouseAccelerationToolStripMenuItem.Checked = true;
                settings.PatchAcceleration = true;
            }
        }
    }
}
