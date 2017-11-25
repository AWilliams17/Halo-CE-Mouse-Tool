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
            int v = 3; //use this to set the version #... very shitty. need to make this better.
            WebClient wb = new WebClient();
            byte[] HTML;
            try
            {
                HTML = wb.DownloadData("https://pastebin.com/raw/UQpXvHBR");
            }
            catch //blanket catch exception. bad for business. good for me being lazy.
            {
                return "error";
            }
            UTF8Encoding objUTF8 = new UTF8Encoding();
            string nv = objUTF8.GetString(HTML);
            int s = int.Parse(nv[0].ToString());
            if (s > v) //If the current version is less than the one that is currently released...
            {
                return "yes"; //i mean obv that means theres an update
            }
            return "no";
        }
    }
}
