using System;
using System.Windows.Forms;
using Microsoft.Win32;

namespace DLLSettingsApp
{
    public partial class Mainform : Form
    {
        public Mainform()
        {
            InitializeComponent();
        }

        private void SetBtn_Click(object sender, EventArgs e)
        {
            float sensX, sensY = 0;
            string mouseAcceleration = "0";
            string dllSounds = "1";

            if (MouseAccelCheckbox.Checked)
            {
                mouseAcceleration = "1";
            }

            if (!DLLSoundsCheckbox.Checked)
            {
                dllSounds = "0";
            }

            if(!float.TryParse(SensXTextbox.Text, out sensX) || !float.TryParse(SensYTextbox.Text, out sensY))
            {
                MessageBox.Show("Error parsing one of the sensitivity values. Please make sure you have input a valid value. Settings not saved to registry.");
            }
            else
            {
                if (sensX < 0 || sensY < 0)
                {
                    MessageBox.Show("Error: Sensitivities can not be less than 0.");
                }
                else
                {
                    sensX *= 0.25F;
                    sensY *= 0.25F;
                    Registry.SetValue("HKEY_CURRENT_USER\\Software\\HaloFixDLL", "SensX", sensX.ToString(), RegistryValueKind.String);
                    Registry.SetValue("HKEY_CURRENT_USER\\Software\\HaloFixDLL", "SensY", sensY.ToString(), RegistryValueKind.String);
                    Registry.SetValue("HKEY_CURRENT_USER\\Software\\HaloFixDLL", "MouseAcceleration", mouseAcceleration, RegistryValueKind.String);
                    Registry.SetValue("HKEY_CURRENT_USER\\Software\\HaloFixDLL", "DLLSounds", dllSounds, RegistryValueKind.String);
                    MessageBox.Show("Successfully commited values to registry.");
                }
            }
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Mainform_Load(object sender, EventArgs e)
        {
            RegistryKey halofixdllRK = Registry.CurrentUser.OpenSubKey("Software\\HaloFixDLL", false);

            try
            {
                object sensX = halofixdllRK.GetValue("SensX");
                object sensY = halofixdllRK.GetValue("SensY");
                object mouseAcceleration = halofixdllRK.GetValue("MouseAcceleration");
                object dllSounds = halofixdllRK.GetValue("DLLSounds");

                if (halofixdllRK.GetValueKind("SensX") == RegistryValueKind.String)
                {
                    SensXTextbox.Text = sensX.ToString();
                }

                if (halofixdllRK.GetValueKind("SensY") == RegistryValueKind.String)
                {
                    SensYTextbox.Text = sensY.ToString();
                }

                if (halofixdllRK.GetValueKind("MouseAcceleration") == RegistryValueKind.String)
                {
                    if (mouseAcceleration.ToString() == "1")
                    {
                        MouseAccelCheckbox.Checked = true;
                    }
                }

                if (halofixdllRK.GetValueKind("DLLSounds") == RegistryValueKind.String)
                {
                    if (dllSounds.ToString() == "0")
                    {
                        DLLSoundsCheckbox.Checked = false;
                    }
                }
            }
            catch { } //Ignore any errors that occur; if an IOException occurs it just means they didn't run the tool/they messed with the registry manually.
            //in either case, both will be fixed when the set button is pressed anyhow.
        }
    }
}
