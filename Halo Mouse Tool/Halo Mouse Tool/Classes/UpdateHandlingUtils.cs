using System;
using System.Text;
using System.Net;
using System.Reflection;


namespace Halo_Mouse_Tool
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
    public static class UpdateHandlingUtils
    {
        public static bool UpdateAvailable(int timeout, string currVersionLink)
        {
            int current_version = int.Parse(Assembly.GetExecutingAssembly().GetName().Version.ToString()[0].ToString());
            WebClientWithTimeout wb = new WebClientWithTimeout(timeout);
            byte[] HTML;
            HTML = wb.DownloadData(currVersionLink); //The number downloaded from the link is the currently released version
            UTF8Encoding objUTF8 = new UTF8Encoding();
            string nv = objUTF8.GetString(HTML);
            int versionAvailable = int.Parse(nv[0].ToString());
            if (versionAvailable > current_version)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
