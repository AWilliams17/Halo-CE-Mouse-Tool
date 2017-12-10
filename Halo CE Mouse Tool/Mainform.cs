using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.IO;
using System.Media;

namespace Halo_CE_Mouse_Tool
{
    public partial class Mainform : Form
    { //And here we go...
        public XMLHandler xmlhandler = new XMLHandler(Application.StartupPath + "/CEMT.xml");
        public SettingsHandler settings = new SettingsHandler();
        public SettingsForm settingsform;
        public DonateForm donateform;

        public Mainform()
        {
            InitializeComponent();
            AppDomain.CurrentDomain.ProcessExit += new EventHandler(OnProcessExit);
        }

        private void Mainform_Load(object sender, EventArgs e)
        {
            utils.LoadSettings(settings, 2);
            SensX.Text = settings.SensX.ToString();
            SensY.Text = settings.SensY.ToString();
            if (settings.CheckForUpdatesOnStart == 1)
            {
                utils.CheckForUpdates(settings);
            }
            string window_title = "Halo CE Mouse Tool v" + UpdateHandler.version.ToString();
            if (!utils.IsAdministrator())
            { //Gripe at the user if they're not an admin.
                window_title += " -NOT ADMIN-";
                SoundHandler.sound_notice(settings);
                MessageBox.Show("Warning - You must run this tool as an administrator in order for it to work properly.");
            }
            this.Text = window_title;
        }

        private void ActivateBtn_Click_1(object sender, EventArgs e)
        {
            utils.WriteHaloMemory(this.settings, 0);
        }

        private void StatusLabelTimer_Tick(object sender, EventArgs e)
        {
            if (ProcessHandler.ProcessIsRunning("haloce"))
            {
                StatusLabel.Text = "Halo CE Process found.";
                StatusLabel.ForeColor = Color.Green;
                ActivateBtn.Enabled = true;
                KeybindHandler.KeybindsEnabled = true;
            }
            else {
                StatusLabel.Text = "Halo CE Process not found.";
                StatusLabel.ForeColor = Color.Red;
                ActivateBtn.Enabled = false;
                KeybindHandler.KeybindsEnabled = false;
            }
        }

        private void SettingsBtn_Click(object sender, EventArgs e)
        {
            if (FormHandler.formopen(settingsform))
            {
                settingsform.Dispose();
            }
            settingsform = new SettingsForm(settings);
            settingsform.Show();
        }

        private void DonateLink_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // >Implying anyone would ever give me money for this shit
            //Aren't I ever the dreamer
            if (FormHandler.formopen(donateform))
            {
                donateform.Dispose();
            }
            donateform = new DonateForm();
            donateform.Show();
        }

        private void GithubLink_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/AWilliams17/Halo-CE-Mouse-Tool");
        }

        private void RedditLink_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //TODO: Maybe I can not hardcode this?
            Process.Start("https://www.reddit.com/r/halospv3/comments/7fdrpr/just_released_halo_mouse_tool_v3/?st=jan506jz&sh=1bd4ebda");
        }

        private void HotkeyLabelTimer_Tick(object sender, EventArgs e)
        {
            if (settings.HotkeyEnabled == 1)
            {
                HotkeyStatus.Text = "Keybind is set to: " + settings.Hotkey;
            }
            else {
                HotkeyStatus.Text = "Keybind is disabled/not set.";
            }
        }

        private void SensX_TextChanged(object sender, EventArgs e)
        {
            utils.parse_sensitivity(this.SensX, 'x', settings); //Make sure the input is valid.
        }

        private void SensY_TextChanged(object sender, EventArgs e)
        {
            utils.parse_sensitivity(this.SensY, 'y', settings); //Same as above.
        }

        public void OnProcessExit(object sender, EventArgs e)
        {
            utils.SaveSettings(settings, 1); //The exception generated if the user has no access to the file will be ignored. Nothing I can do about that.
        }

        private void HotkeyTimer_Tick(object sender, EventArgs e)
        {
            utils.keybind_handle(settings); //If the user presses their hotkey, then handle it.
            //Is there a better way of doing this?
        }

        private void SensX_Leave(object sender, EventArgs e)
        {
            utils.check_if_blank(this.SensX, settings); //If the user tries to leave with the textbox being blank, then force them back to it.
        }

        private void SensY_Leave(object sender, EventArgs e)
        {
            utils.check_if_blank(this.SensY, settings); //Same as above.
        }
    }
}
