using System.Windows.Forms;

/*
    -FormHandler Class-
    This class should check if a form exists and is open or not, and create and
    show them.
*/
namespace Halo_CE_Mouse_Tool
{
    public static class FormHandler
    {
        public static bool formopen(Form frm)
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
