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
    This class handles all settings related stuff. It's also terrible.
*/
namespace Halo_CE_Mouse_Tool {
    public class SettingsHandler {
        private float SensX;
        private float SensY;
        private int PatchAcceleration;
        private int CheckForUpdates;
        private int HotkeyEnabled;
        private string Hotkey;

        private string XMLPath = Application.StartupPath + "/CEMT.xml";

        private bool XMLExists() {
            if (File.Exists(XMLPath)){
                return true;
            } else {
                return false;
            }
        }

        public int CheckForUpdatesOnStart() {
            return CheckForUpdates;
        }

        public int GetHotkeyEnabled() {
            return HotkeyEnabled;
        }

        public string GetHotkey() {
            return Hotkey;
        }

        public int GetPatchAcceleration() {
            return PatchAcceleration;
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

        public void SetHotkey(string hotkey) {
            Hotkey = hotkey;
        }

        public void SetHotkeyEnabled(int hotkeyon) {
            HotkeyEnabled = hotkeyon;
        }

        public void SetPatchAcceleration(int accel) {
            PatchAcceleration = accel;
        }

        public void SetCheckForUpdates(int updates) {
            CheckForUpdates = updates;
        }

        public void GenerateXML() {
            XmlWriter xmlWriter = XmlWriter.Create("CEMT.xml");

            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("CEMT");

            xmlWriter.WriteStartElement("CEMTSensitivity");
            xmlWriter.WriteAttributeString("SensX", "1");
            xmlWriter.WriteAttributeString("SensY", "1");
            xmlWriter.WriteAttributeString("PatchAccel", "1");
            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("CEMTApplication");
            xmlWriter.WriteAttributeString("CheckForUpdates", "1");
            xmlWriter.WriteAttributeString("Hotkey", "F1");
            xmlWriter.WriteAttributeString("HotkeyEnabled", "1");

            xmlWriter.WriteEndDocument();
            xmlWriter.Close();
        }

        public void WriteXML() {
            XmlDocument doc = new XmlDocument();
            doc.Load(XMLPath);

            XmlNode root = doc.DocumentElement["CEMTSensitivity"];
            foreach (XmlAttribute c in root.Attributes) {
                if (c.Name == "SensX") {
                    c.Value = GetSensX().ToString();
                }
                if (c.Name == "SensY") {
                    c.Value = GetSensY().ToString();
                }
                if (c.Name == "PatchAccel") {
                    c.Value = GetPatchAcceleration().ToString();
                }
            }

            XmlNode g = doc.DocumentElement["CEMTApplication"];
            foreach (XmlAttribute f in g.Attributes) {
                if (f.Name == "CheckForUpdates") {
                    f.Value = CheckForUpdatesOnStart().ToString();
                }
                if (f.Name == "Hotkey") {
                    f.Value = GetHotkey();
                }
                if (f.Name == "HotkeyEnabled") {
                    f.Value = GetHotkeyEnabled().ToString();
                }
            }
            doc.Save(XMLPath);
        }
        /*
            Rob say Code Monkey very dilligent - but his output stink.
            His code not functional or elegant.
            What do code monkey think?
            Code monkey think he get back to work on tool.
        */
        public int LoadSettingsFromXML() { //1 == successfully read & set XML
            if (XMLExists()) {
                //Load and set values
                XmlReader xmlReader = XmlReader.Create(XMLPath);
                while (xmlReader.Read()) {
                    if ((xmlReader.NodeType == XmlNodeType.Element) && (xmlReader.Name == "CEMTSensitivity")) {
                        if (xmlReader.HasAttributes) {
                            float sensX;
                            float sensY;
                            int patchaccel;
                            float.TryParse(xmlReader.GetAttribute("SensX"), out sensX);
                            float.TryParse(xmlReader.GetAttribute("SensY"), out sensY);
                            int.TryParse(xmlReader.GetAttribute("PatchAccel"), out patchaccel);

                            SetSensX(sensX);
                            SetSensY(sensY);
                            SetPatchAcceleration(patchaccel);
                        }
                    }
                    if ((xmlReader.NodeType == XmlNodeType.Element) && (xmlReader.Name == "CEMTApplication")) {
                        if (xmlReader.HasAttributes) {
                            int checkforupdates;
                            int hotkeyenabled;
                            string hotkey = xmlReader.GetAttribute("Hotkey");
                            int.TryParse(xmlReader.GetAttribute("CheckForUpdates"), out checkforupdates);
                            int.TryParse(xmlReader.GetAttribute("HotkeyEnabled"), out hotkeyenabled);

                            SetCheckForUpdates(checkforupdates);
                            SetHotkey(hotkey);
                            SetHotkeyEnabled(hotkeyenabled);
                            
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
