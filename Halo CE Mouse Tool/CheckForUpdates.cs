using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace Halo_CE_Mouse_Tool
{
    class CheckForUpdates
    {
        public static string UpdateAvailable()
        {
            int v = 1;
            WebClient wb = new WebClient();
            byte[] HTML;
            try
            {
                HTML = wb.DownloadData("https://pastebin.com/raw/KePbXmPk");
            }
            catch (System.Net.WebException)
            {
                return "error";
            }
            UTF8Encoding objUTF8 = new UTF8Encoding();
            string nv = objUTF8.GetString(HTML);
            int s = int.Parse(nv[10].ToString());
            if (s > v)
            {
                return "yes";
            }
            return "no";
        }
    }
}
