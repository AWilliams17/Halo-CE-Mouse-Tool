using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading.Tasks;

/*
    -UpdateHandler Class-
    This class should check for updates and return a true/false value if one
    is available. It also should hold the current program version.
*/
namespace Halo_CE_Mouse_Tool {
    class UpdateHandler {
        private int version = 4;

        public int GetVersion() {
            return version;
        }

        public void CheckForUpdates() {
            WebClient wb = new WebClient();
            byte[] HTML;
            try {
                HTML = wb.DownloadData("https://pastebin.com/raw/UQpXvHBR");
                UTF8Encoding objUTF8 = new UTF8Encoding();
                string nv = objUTF8.GetString(HTML);
                int version_available = int.Parse(nv[0].ToString());
                if (version_available > version) {
                    DialogResult d = MessageBox.Show("An Update is Available. Would you like to visit the downloads page?", "Update Found", MessageBoxButtons.YesNo);
                    if (d == DialogResult.Yes) {
                        Process.Start("https://github.com/AWilliams17/Halo-CE-Mouse-Tool/releases");
                    }
                }
                MessageBox.Show("No updates were found.");
            } catch {
                MessageBox.Show("An error occurred while checking for updates.");
            }
        }
    }
}
