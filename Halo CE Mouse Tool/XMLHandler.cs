using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml;

namespace Halo_CE_Mouse_Tool {
    public class XMLHandler {
        private string XMLPath = Application.StartupPath + "/CEMT.xml";

        private bool XMLExists() {
            if (File.Exists(XMLPath)) {
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
            xmlWriter.WriteAttributeString("SoundsEnabled", "1");
            xmlWriter.WriteAttributeString("Hotkey", "F1");
            xmlWriter.WriteAttributeString("HotkeyEnabled", "1");

            xmlWriter.WriteEndDocument();
            xmlWriter.Close();
        }

        public void WriteSettingsToXML(SettingsHandler s) {
            XmlDocument doc = new XmlDocument();
            try {
                doc.Load(XMLPath);
            } catch (XmlException) { //Root element missing
                XmlElement elem = doc.CreateElement("CEMT");
                doc.AppendChild(elem);
            }
            bool SensXWrote = true;
            bool SensYWrote = true;
            bool PatchAccelWrote = true;
            bool CheckForUpdatesWrote = true;
            bool SoundsEnabledWrote = true;
            bool HotkeyWrote = true;
            bool HotkeyEnabledWrote = true;

            XmlNode root = doc.DocumentElement["CEMTSensitivity"];
            try {
                foreach (XmlAttribute c in root.Attributes) {
                    if (c.Name == "SensX") {
                        c.Value = s.SensX.ToString();
                    } else {
                        SensXWrote = false;
                    }
                    if (c.Name == "SensY") {
                        c.Value = s.SensY.ToString();
                    } else {
                        SensYWrote = false;
                    }
                    if (c.Name == "PatchAccel") {
                        c.Value = s.PatchAcceleration.ToString();
                    } else {
                        PatchAccelWrote = false;
                    }
                }
            } catch (NullReferenceException) {
                XmlElement CEMTSensitivity = doc.CreateElement("CEMTSensitivity");
                doc.DocumentElement.AppendChild(CEMTSensitivity);
                SensXWrote = false;
                SensYWrote = false;
                PatchAccelWrote = false;
                root = doc.DocumentElement["CEMTSensitivity"];
            }

            XmlNode g = doc.DocumentElement["CEMTApplication"];
            try {
                foreach (XmlAttribute f in g.Attributes) {
                    if (f.Name == "CheckForUpdates") {
                        f.Value = s.CheckForUpdatesOnStart.ToString();
                    } else {
                        CheckForUpdatesWrote = false;
                    }
                    if (f.Name == "SoundsEnabled") {
                        f.Value = s.SoundsEnabled.ToString();
                    } else {
                        SoundsEnabledWrote = false;
                    }
                    if (f.Name == "Hotkey") {
                        f.Value = s.Hotkey;
                    } else {
                        HotkeyWrote = false;
                    }
                    if (f.Name == "HotkeyEnabled") {
                        f.Value = s.HotkeyEnabled.ToString();
                    } else {
                        HotkeyEnabledWrote = false;
                    }
                }
            } catch (NullReferenceException) {
                XmlElement CEMTApplication = doc.CreateElement("CEMTApplication");
                doc.DocumentElement.AppendChild(CEMTApplication);
                CheckForUpdatesWrote = false;
                SoundsEnabledWrote = false;
                HotkeyEnabledWrote = false;
                HotkeyWrote = false;
                g = doc.DocumentElement["CEMTApplication"];
            }

            if (!SensXWrote) {
                XmlAttribute SensX = doc.CreateAttribute("SensX");
                SensX.Value = s.SensX.ToString();
                root.Attributes.SetNamedItem(SensX);
            }
            if (!SensYWrote) {
                XmlAttribute SensY = doc.CreateAttribute("SensY");
                SensY.Value = s.SensY.ToString();
                root.Attributes.SetNamedItem(SensY);
            }
            if (!PatchAccelWrote) {
                XmlAttribute PatchAccel = doc.CreateAttribute("PatchAccel");
                PatchAccel.Value = s.PatchAcceleration.ToString();
                root.Attributes.SetNamedItem(PatchAccel);
            }

            if (!HotkeyWrote) {
                XmlAttribute Hotkey = doc.CreateAttribute("Hotkey");
                Hotkey.Value = s.Hotkey;
                g.Attributes.SetNamedItem(Hotkey);
            }
            if (!HotkeyEnabledWrote) {
                XmlAttribute HotkeyEnabled = doc.CreateAttribute("HotkeyEnabled");
                HotkeyEnabled.Value = s.HotkeyEnabled.ToString();
                g.Attributes.SetNamedItem(HotkeyEnabled);
            }
            if (!CheckForUpdatesWrote) {
                XmlAttribute CheckForUpdates = doc.CreateAttribute("CheckForUpdates");
                CheckForUpdates.Value = s.CheckForUpdatesOnStart.ToString();
                g.Attributes.SetNamedItem(CheckForUpdates);
            }
            if (!SoundsEnabledWrote) {
                XmlAttribute SoundsEnabled = doc.CreateAttribute("SoundsEnabled");
                SoundsEnabled.Value = s.SoundsEnabled.ToString();
                g.Attributes.SetNamedItem(SoundsEnabled);
            }
            doc.Save(XMLPath);
        }
        /*
            Rob say Code Monkey very dilligent - but his output stink.
            His code not functional or elegant.
            What do code monkey think?
            Code monkey think he get back to work on tool.
        */
        public int LoadSettingsFromXML(SettingsHandler s) {
            bool err = false;
            if (XMLExists()) {
                //Load and set values
                XmlReader xmlReader = XmlReader.Create(XMLPath);
                try {
                    while (xmlReader.Read()) {
                        if ((xmlReader.NodeType == XmlNodeType.Element) && (xmlReader.Name == "CEMTSensitivity")) {
                            if (xmlReader.HasAttributes) {
                                float sensX;
                                float sensY;
                                int patchaccel;
                                if (!float.TryParse(xmlReader.GetAttribute("SensX"), out sensX)) {
                                    err = true;
                                } else {
                                    s.SensX = sensX;
                                }
                                 if (!float.TryParse(xmlReader.GetAttribute("SensY"), out sensY)) {
                                    err = true;
                                } else {
                                    s.SensY = sensY;
                                }
                                if (!int.TryParse(xmlReader.GetAttribute("PatchAccel"), out patchaccel)) {
                                    err = true;
                                } else {
                                    s.PatchAcceleration = patchaccel;
                                }
                            }
                        }
                        if ((xmlReader.NodeType == XmlNodeType.Element) && (xmlReader.Name == "CEMTApplication")) {
                            if (xmlReader.HasAttributes) {
                                int checkforupdates;
                                int hotkeyenabled;
                                int soundsenabled;
                                string hotkey = xmlReader.GetAttribute("Hotkey");
                                if (hotkey == null) {
                                    err = true;
                                } else {
                                    s.Hotkey = hotkey;
                                }
                                if (!int.TryParse(xmlReader.GetAttribute("CheckForUpdates"), out checkforupdates)) {
                                    err = true;
                                } else {
                                    s.CheckForUpdatesOnStart = checkforupdates;
                                }
                                if (!int.TryParse(xmlReader.GetAttribute("HotkeyEnabled"), out hotkeyenabled)) {
                                    err = true;
                                } else {
                                    s.HotkeyEnabled = hotkeyenabled;
                                }
                                if (!int.TryParse(xmlReader.GetAttribute("SoundsEnabled"), out soundsenabled)) {
                                    err = true;
                                } else {
                                    s.SoundsEnabled = soundsenabled;
                                }
                            }
                        }
                    }
                } catch (XmlException){
                    return 2; //2 == Exception
                }
                if (err == true) {
                    return 3; //3 == One or more values not read properly; they are set to default values
                }
                return 1; //1 == Successfully read
            } else {
                return 0; //0 == didn't find an XML
            }
        }
    }
}
