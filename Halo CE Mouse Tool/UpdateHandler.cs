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
    public class UpdateHandler {
        public int version { get; } = 4;

        public int CheckForUpdates() {
            WebClient wb = new WebClient();
            byte[] HTML;
            try {
                HTML = wb.DownloadData("https://pastebin.com/raw/UQpXvHBR");
                UTF8Encoding objUTF8 = new UTF8Encoding();
                string nv = objUTF8.GetString(HTML);
                int version_available = int.Parse(nv[0].ToString());
                if (version_available > version) {
                    return 1;
                }
                return 0;
            } catch {
                return 2;
            }
        }
    }
}
