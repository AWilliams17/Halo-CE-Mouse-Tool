using System.Windows.Forms;

namespace Halo_Mouse_Tool
{
    public static class FormHandlingUtils
    {
        public static bool Formopen(Form frm)
        { //General formopen func, return true if the form is found, false otherwise.
            foreach (Form form in Application.OpenForms)
            {
                if (form == frm)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
