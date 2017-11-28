using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml;

/*
    -SettingsHandler Class-
    This class should call inihandler and set the settings in the application
*/
namespace Halo_CE_Mouse_Tool {
    class SettingsHandler {
        private float SensX;
        private float SensY = 1;
        private string XMLPath = Application.StartupPath + "/CEMT.xml";

        private bool XMLExists() {
            if (File.Exists(XMLPath)){
                return true;
            } else {
                return false;
            }
        }

        public bool CheckForUpdatesOnStart() {
            return false;
        }

        public bool HotkeyEnabled() {
            return false;
        }

        public bool PatchAcceleration() {
            return true;
        }

        public float GetSensX() {
            return SensX;
        }

        public float GetSensY() {
            return SensY;
        }

        public void SetSensX(float val) {
            SensX = val;
        }

        public void SetSensY(float val) {
            SensY = val;
        }

        public void WriteSettingsToIni() {

        }

        public int LoadSettingsFromXML() { //1 == successfully read & set XML
            if (XMLExists()) {
                //Load and set values
                XmlReader xmlReader = XmlReader.Create(XMLPath);
                while (xmlReader.Read()) {
                    if ((xmlReader.NodeType == XmlNodeType.Element) && (xmlReader.Name == "CEMTSensitivity")) {
                        if (xmlReader.HasAttributes) {
                            MessageBox.Show(xmlReader.GetAttribute("SensX"));
                            MessageBox.Show(xmlReader.GetAttribute("SensY"));
                        }
                    }
                }
                return 1;
            } else {
                return 0; //0 == didn't find an XML
            }
        }



    }
}
