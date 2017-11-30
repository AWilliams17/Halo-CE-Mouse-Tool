using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
    -FormHandler Class-
    This class should check if a form exists and is open or not, and create and
    show them.
*/
namespace Halo_CE_Mouse_Tool {
    public static class FormHandler {
        public static bool formopen(Form frm) {
            foreach (Form form in Application.OpenForms) {
                if (form == frm) {
                    return true;
                }
            }
            return false;
        }
        
        public static void formopen(SettingsForm frm, Mainform g) {
            foreach (Form form in Application.OpenForms) {
                if (form == frm) {
                    g.settingsform.Dispose();
                    break;
                }
            }
            g.settingsform = new SettingsForm();
            g.settingsform.Show();
        }

        public static void formopen(DonateForm frm, Mainform g) {
            foreach (Form form in Application.OpenForms) {
                if (form == frm) {
                    g.donateform.Dispose();
                    break;
                }
            }
            g.donateform = new DonateForm();
            g.donateform.Show();
        }
    }
}
