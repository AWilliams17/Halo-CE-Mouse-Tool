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
            if (MouseAccelCheckbox.Checked)
            {
                mouseAcceleration = "1";
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
                    MessageBox.Show("Successfully commited values to registry.");
                }
            }
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
