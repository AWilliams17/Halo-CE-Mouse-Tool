using System;
using System.Text;
using System.Net;

/*
    -UpdateHandler Class-
    This class should check for updates and return a true/false value if one
    is available. It also should hold the current program version.
*/
namespace Halo_CE_Mouse_Tool
{
    [System.ComponentModel.DesignerCategory("Code")]
    public class WebClientWithTimeout : WebClient
    { //Custom webclient implementation to allow for custom timeout
        private readonly int _t;
        public WebClientWithTimeout(int timeout)
        {
            _t = timeout;
        }
        protected override WebRequest GetWebRequest(Uri address)
        {
            WebRequest wr = base.GetWebRequest(address);
            wr.Timeout = _t; //in ms
            return wr;
        }
    }

    [System.ComponentModel.DesignerCategory("Code")]
    public static class UpdateHandler
    {
        public const int Version = 5; //Current program version
        public static int CheckForUpdates(int timeout)
        { //Download a url, in this case pastebin, which has a single number in it.
            WebClientWithTimeout wb = new WebClientWithTimeout(timeout);
            byte[] HTML;
            try
            {
                HTML = wb.DownloadData("https://pastebin.com/raw/UQpXvHBR"); //The number in the pastebin is the currently released version of the tool.
            }
            catch (WebException)
            {
                return 2;
            }
            UTF8Encoding objUTF8 = new UTF8Encoding();
            string nv = objUTF8.GetString(HTML);
            int versionAvailable = int.Parse(nv[0].ToString());
            if (versionAvailable > Version)
            { //Compare the version available to the current version of the application.
                return 1; //There is an update available. Return true.
            }
            else
            {
                return 0; //No update. return false.
            }
        }
    }
}
