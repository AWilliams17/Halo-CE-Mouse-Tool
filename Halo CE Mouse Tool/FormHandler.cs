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
    class FormHandler {
        public bool formopen(Form frm) {
            foreach (Form form in Application.OpenForms) {
                if (form == frm) {
                    return true;
                }
            }
            return false;
        }
    }
}
