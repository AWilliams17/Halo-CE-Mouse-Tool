using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace Halo_CE_Mouse_Tool
{
    public partial class Mainform : Form
    { //And here we go...
        public XmlHandler Xmlhandler = new XmlHandler(Application.StartupPath + "/CEMT.xml");
        public SettingsHandler Settings = new SettingsHandler();
        public SettingsForm Settingsform;
        public DonateForm Donateform;

        public Mainform()
        {
            InitializeComponent();
            AppDomain.CurrentDomain.ProcessExit += OnProcessExit;
        }

        private void Mainform_Load(object sender, EventArgs e)
        {
            string dialogResult;
            try
            {
                Utils.LoadSettings(Settings, 2);
                SoundHandler.sound_success(Settings);
                MessageBox.Show("Successfully loaded XML file.");
            }
            catch (FileNotFoundException)
            {
                SoundHandler.sound_error(Settings);
                dialogResult = "I did not find an XML config file. A new one will be generated with default values.";
                MessageBox.Show(dialogResult, "XML does not exist.");

            }
            catch (Exception ex)
            {
                SoundHandler.sound_error(Settings);
                if (ex is ArgumentException || ex is ArgumentOutOfRangeException)
                {
                    dialogResult = "An error occurred whilst loading the settings file: One or more values were not set correctly. Did you manually edit the file? These settings have been set to their defaults.";
                }
                else
                {
                    MessageBox.Show(ex.Message);
                    dialogResult = "An error occurred whilst loading the settings file: Unspecified error. Possible malformation of config file. Settings that failed to load have been set back to their defaults.";
                }
                MessageBox.Show(dialogResult, "Settings Status");
            }


            SensX.Text = Settings.SensX.ToString();
            SensY.Text = Settings.SensY.ToString();
            string windowTitle = "Halo CE Mouse Tool v" + UpdateHandler.Version;
            if (!Utils.IsAdministrator())
            { //Gripe at the user if they're not an admin.
                windowTitle += " -NOT ADMIN-";
                const string adminWarning = "Warning - You must run this tool as an administrator in order for it to work properly.";
                SoundHandler.sound_notice(Settings);
                MessageBox.Show(adminWarning, "You are not an admin!");
            }
            Text = windowTitle;

            if (Settings.CheckForUpdatesOnStart == 1)
            {
                Utils.CheckForUpdates(Settings);
            }
        }

        private void ActivateBtn_Click_1(object sender, EventArgs e)
        {
            try
            {
                Utils.WriteHaloMemory(Settings);
                SoundHandler.sound_success(Settings);
                MessageBox.Show("Successfully wrote values to memory.", "Successfully wrote to memory!");
            }
            catch (UnauthorizedAccessException)
            {
                SoundHandler.sound_error(Settings);
                MessageBox.Show("Access Denied. Are you running the tool as Admin?", "Access Denied.");
            }
            catch (SystemException)
            {
                SoundHandler.sound_error(Settings);
                MessageBox.Show("Error: One or more values failed to write.", "Error"); // bad
            }
        }

        private void StatusLabelTimer_Tick(object sender, EventArgs e)
        {
            string status;
            Color labelColor;
            if (ProcessHandler.ProcessIsRunning("haloce"))
            {
                labelColor = Color.Green;
                status = "Halo CE Process found.";
                KeybindHandler.KeybindsEnabled = true;
                ActivateBtn.Enabled = true;
            }
            else
            {
                labelColor = Color.Red;
                status = "Halo CE process not found.";
                KeybindHandler.KeybindsEnabled = false;
                ActivateBtn.Enabled = false;
            }
            StatusLabel.Text = status;
            StatusLabel.ForeColor = labelColor;
        }

        private void SettingsBtn_Click(object sender, EventArgs e)
        {
            if (FormHandler.Formopen(Settingsform))
            {
                Settingsform.Dispose();
            }
            Settingsform = new SettingsForm(Settings);
            Settingsform.Show();
        }

        private void DonateLink_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // >Implying anyone would ever give me money for this shit
            //Aren't I ever the dreamer
            if (FormHandler.Formopen(Donateform))
            {
                Donateform.Dispose();
            }
            Donateform = new DonateForm();
            Donateform.Show();
        }

        private void GithubLink_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/AWilliams17/Halo-CE-Mouse-Tool");
        }

        private void RedditLink_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.reddit.com/r/halospv3/comments/7fdrpr/just_released_halo_mouse_tool_v3/?st=jan506jz&sh=1bd4ebda");
        }

        private void HotkeyLabelTimer_Tick(object sender, EventArgs e)
        {
            string status;
            if (Settings.HotkeyEnabled == 1)
            {
                status = "Keybind is set to: " + Settings.Hotkey;
            }
            else
            {
                status = "Keybind is disabled/not set.";
            }
            HotkeyStatus.Text = status;
        }

        private void SensX_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Utils.Parse_Sensitivity(SensX, 'x', Settings); //Make sure the input is valid.
            }
            catch (FormatException)
            {
                SensX.Text = "0";
                MessageBox.Show("Error: Invalid input. Please check your input and try again.");
            }
        }

        private void SensY_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Utils.Parse_Sensitivity(SensY, 'y', Settings); //Same as above.
            }
            catch (FormatException)
            {
                SensY.Text = "0";
                MessageBox.Show("Error: Invalid input. Please check your input and try again.");
            }
        }

        public void OnProcessExit(object sender, EventArgs e)
        {
            Utils.SaveSettings(Settings, 1); //The exception generated if the user has no access to the file will be ignored. Nothing I can do about that.
        }

        private void HotkeyTimer_Tick(object sender, EventArgs e)
        {
            if (KeybindHandler.KeybindsEnabled && Settings.HotkeyEnabled == 1)
            {
                try
                {
                    if (KeybindHandler.IsKeyPushedDown((Keys)Enum.Parse(typeof(Keys), Settings.Hotkey)))
                    {
                        Utils.WriteHaloMemory(Settings);
                        SoundHandler.sound_success(Settings);
                        if (Settings.HideKeybindSuccessMsg == 0)
                        {
                            MessageBox.Show("Successfully wrote values to memory.", "Successfully wrote to memory!");
                        }
                    }
                    if (Settings.IncrementSens == 1 && KeybindHandler.KeybindsEnabled)
                    {
                        if (KeybindHandler.IsKeyPushedDown(Keys.Oemplus))
                        {
                            Settings.SensX = Settings.SensX += Settings.IncrementAmount;
                            Settings.SensY = Settings.SensY += Settings.IncrementAmount;
                            Utils.WriteHaloMemory(Settings);
                            SensX.Text = Settings.SensX.ToString();
                            SensY.Text = Settings.SensY.ToString();
                            SoundHandler.sound_success(Settings);
                        }
                        else if (KeybindHandler.IsKeyPushedDown(Keys.OemMinus) && Settings.SensX != 0 && Settings.SensY != 0)
                        {
                            if (Settings.SensX - Settings.IncrementAmount < 0.1 || Settings.SensY - Settings.IncrementAmount < 0.1)
                            {
                                SoundHandler.sound_error(Settings);
                            }
                            else
                            {
                                Settings.SensX = Settings.SensX -= Settings.IncrementAmount;
                                Settings.SensY = Settings.SensY -= Settings.IncrementAmount;
                                Utils.WriteHaloMemory(Settings);
                                SensX.Text = Settings.SensX.ToString();
                                SensY.Text = Settings.SensY.ToString();
                                SoundHandler.sound_success(Settings);
                            }
                        }
                    }
                }
                catch (UnauthorizedAccessException)
                {
                    SoundHandler.sound_error(Settings);
                    MessageBox.Show("Access Denied. Are you running the tool as Admin?", "Access Denied.");
                }
                catch (SystemException)
                {
                    SoundHandler.sound_error(Settings);
                    MessageBox.Show("An unspecified error occurred.", "Error.");
                }
            }
        }

        private void SensX_Leave(object sender, EventArgs e)
        {
            CheckIfBlank(SensX, Settings); //If the user tries to leave with the textbox being blank, then force them back to it.
        }

        private void SensY_Leave(object sender, EventArgs e)
        {
            CheckIfBlank(SensY, Settings); //Same as above.
        }

        private void DeployDllBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Utils.DeployDLL();
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Error - the selected folder did not have a controls.dll file.", "Invalid controls folder location");
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Error - You do not have access to this location. Are you running as admin?", "Unauthorized Access");
            }
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void CheckIfBlank(TextBox origin, SettingsHandler settings)
        { //Check if the sensitivity textbox is blank or not. Prevent user from leaving if it is.
            if (origin.Text == "")
            {
                origin.Focus();
                SoundHandler.sound_error(settings);
                MessageBox.Show("Error: You can't leave this field blank.", "Field can not be blank!");
            }
        }
    }
}