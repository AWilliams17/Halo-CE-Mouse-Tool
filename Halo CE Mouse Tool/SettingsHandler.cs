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
        private float _SensX { get; set; }
        private float _SensY { get; set; }
        private int _PatchAcceleration { get; set; }
        private int _CheckForUpdatesOnStart { get; set; }
        private int _HotkeyEnabled { get; set; }
        private string _Hotkey { get; set; }


        public float SensX {
            get { return _SensX; }
            set { _SensX = value; }
        }

        public float SensY {
            get { return _SensY; }
            set { _SensY = value; }
        }

        public int PatchAcceleration {
            get { return _PatchAcceleration; }
            set { _PatchAcceleration = value; }
        }

        public int CheckForUpdatesOnStart {
            get { return _CheckForUpdatesOnStart; }
            set { _CheckForUpdatesOnStart = value; }
        }

        public int HotkeyEnabled {
            get { return _HotkeyEnabled; }
            set { _HotkeyEnabled = value; }
        }
        public string Hotkey {
            get { return _Hotkey; }
            set { _Hotkey = value; }
        }


        private string XMLPath = Application.StartupPath + "/CEMT.xml";

        private bool XMLExists() {
            if (File.Exists(XMLPath)){
                return true;
            } else {
                return false;
            }
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
                    c.Value = SensX.ToString();
                }
                if (c.Name == "SensY") {
                    c.Value = SensY.ToString();
                }
                if (c.Name == "PatchAccel") {
                    c.Value = PatchAcceleration.ToString();
                }
            }

            XmlNode g = doc.DocumentElement["CEMTApplication"];
            foreach (XmlAttribute f in g.Attributes) {
                if (f.Name == "CheckForUpdates") {
                    f.Value = CheckForUpdatesOnStart.ToString();
                }
                if (f.Name == "Hotkey") {
                    f.Value = Hotkey;
                }
                if (f.Name == "HotkeyEnabled") {
                    f.Value = HotkeyEnabled.ToString();
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

                            SensX = sensX;
                            SensY = sensY;
                            PatchAcceleration = patchaccel;
                        }
                    }
                    if ((xmlReader.NodeType == XmlNodeType.Element) && (xmlReader.Name == "CEMTApplication")) {
                        if (xmlReader.HasAttributes) {
                            int checkforupdates;
                            int hotkeyenabled;
                            string hotkey = xmlReader.GetAttribute("Hotkey");
                            int.TryParse(xmlReader.GetAttribute("CheckForUpdates"), out checkforupdates);
                            int.TryParse(xmlReader.GetAttribute("HotkeyEnabled"), out hotkeyenabled);

                            CheckForUpdatesOnStart = checkforupdates;
                            Hotkey = hotkey;
                            HotkeyEnabled = hotkeyenabled;
                            
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
