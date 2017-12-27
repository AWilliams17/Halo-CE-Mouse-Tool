﻿using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

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
            Utils.LoadSettings(Settings, 2);
            SensX.Text = Settings.SensX.ToString();
            SensY.Text = Settings.SensY.ToString();
            string windowTitle = "Halo CE Mouse Tool v" + UpdateHandler.Version;
            if (!Utils.IsAdministrator())
            { //Gripe at the user if they're not an admin.
                windowTitle += " -NOT ADMIN-";
                const string adminWarning = "Warning - You must run this tool as an administrator in order for it to work properly.";
                SoundHandler.sound_notice(Settings);
                MessageBox.Show(adminWarning, "Warning - Run this tool as an admin!");
            }
            Text = windowTitle;

            if (Settings.CheckForUpdatesOnStart == 1)
            {
                Utils.CheckForUpdates(Settings);
            }
        }

        private void ActivateBtn_Click_1(object sender, EventArgs e)
        {
            Utils.WriteHaloMemory(Settings, 0);
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
            Utils.parse_sensitivity(SensX, 'x', Settings); //Make sure the input is valid.
        }

        private void SensY_TextChanged(object sender, EventArgs e)
        {
            Utils.parse_sensitivity(SensY, 'y', Settings); //Same as above.
        }

        public void OnProcessExit(object sender, EventArgs e)
        {
            Utils.SaveSettings(Settings, 1); //The exception generated if the user has no access to the file will be ignored. Nothing I can do about that.
        }

        private void HotkeyTimer_Tick(object sender, EventArgs e)
        {
            Utils.keybind_handle(Settings, SensX, SensY); //If the user presses their hotkey, then handle it.
            //Is there a better way of doing this?
        }

        private void SensX_Leave(object sender, EventArgs e)
        {
            Utils.check_if_blank(SensX, Settings); //If the user tries to leave with the textbox being blank, then force them back to it.
        }

        private void SensY_Leave(object sender, EventArgs e)
        {
            Utils.check_if_blank(SensY, Settings); //Same as above.
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void DeployDllBtn_Click(object sender, EventArgs e)
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
                        string dllsettings = Path.Combine(fbd.SelectedPath, "DLL Settings.exe");
                        string dll = Path.Combine(fbd.SelectedPath, "HaloMouseFix.dll");
                        File.WriteAllBytes(dllsettings, Properties.Resources.DLL_Settings);
                        File.WriteAllBytes(dll, Properties.Resources.DLL_Settings);
                        string successMsg =
                            "Successfully deployed DLL to controls folder." +
                            " You must now go to the controls folder, run DLL Settings.exe, set your desired settings, and from there " +
                            "all you have to do to use the dll is open Halo, and at any time, press F1 to apply your settings.";
                        MessageBox.Show(successMsg, "DLL Deployment successful");
                    }
                    else
                    {
                        MessageBox.Show("Error - the selected folder did not have a controls.dll file.", "Invalid controls folder location");
                    }

                }
            }

        }
    }
}
