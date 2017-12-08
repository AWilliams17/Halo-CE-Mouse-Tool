using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml;

namespace Halo_CE_Mouse_Tool
{
    /*
        -XMLHandler.cs-
        This class handles the applications XML file.
        prepare to feast your eyes upon some horrible bloat
    */
    public class XMLHandler
    {
        private static string XMLPath = Application.StartupPath + "/CEMT.xml";

        private static bool XMLExists()
        { //Check if the XML configuration file exists.
            if (File.Exists(XMLPath))
            {
                return true;
            }
            else {
                return false;
            }
        }

        public static void GenerateXML(SettingsHandler settings)
        { //Used for generating a new XML file with hardcoded default values.
            try
            {
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
            catch (System.UnauthorizedAccessException)
            {
                SoundHandler.sound_error(settings);
                MessageBox.Show("Error! I can not create an XML file at this location. You do not have access. Please re-run as Admin. I will continue without writing a config.");
            }
        }

        public static void WriteSettingsToXML(SettingsHandler settings)
        { //Called when program exits. Push current settings to the XML file.
            XmlDocument doc = new XmlDocument();
            try
            {
                doc.Load(XMLPath);
            }
            catch (XmlException)
            { //Root element missing
                XmlElement elem = doc.CreateElement("CEMT");
                doc.AppendChild(elem);
            }
            //These are to determine if the XML wrote everything correctly.
            bool SensXWrote = true;
            bool SensYWrote = true;
            bool PatchAccelWrote = true;
            bool CheckForUpdatesWrote = true;
            bool SoundsEnabledWrote = true;
            bool HotkeyWrote = true;
            bool HotkeyEnabledWrote = true;

            XmlNode root = doc.DocumentElement["CEMTSensitivity"];
            try
            {
                foreach (XmlAttribute c in root.Attributes)
                {
                    if (c.Name == "SensX")
                    {
                        c.Value = settings.SensX.ToString();
                    }
                    else {
                        SensXWrote = false;
                    }
                    if (c.Name == "SensY")
                    {
                        c.Value = settings.SensY.ToString();
                    }
                    else {
                        SensYWrote = false;
                    }
                    if (c.Name == "PatchAccel")
                    {
                        c.Value = settings.PatchAcceleration.ToString();
                    }
                    else {
                        PatchAccelWrote = false;
                    }
                }
            }
            catch (NullReferenceException)
            { //Occurs if CEMTSensitivity doesn't exist.
                XmlElement CEMTSensitivity = doc.CreateElement("CEMTSensitivity");
                doc.DocumentElement.AppendChild(CEMTSensitivity);
                SensXWrote = false; //If CEMTSensitivity doesn't exist, then obv the values didn't get written.
                SensYWrote = false;
                PatchAccelWrote = false;
                root = doc.DocumentElement["CEMTSensitivity"]; //Reset root to CEMTSensitivity. it will be written to later.
            }

            XmlNode g = doc.DocumentElement["CEMTApplication"]; //Same business as above.
            try
            {
                foreach (XmlAttribute f in g.Attributes)
                {
                    if (f.Name == "CheckForUpdates")
                    {
                        f.Value = settings.CheckForUpdatesOnStart.ToString();
                    }
                    else {
                        CheckForUpdatesWrote = false;
                    }
                    if (f.Name == "SoundsEnabled")
                    {
                        f.Value = settings.SoundsEnabled.ToString();
                    }
                    else {
                        SoundsEnabledWrote = false;
                    }
                    if (f.Name == "Hotkey")
                    {
                        f.Value = settings.Hotkey;
                    }
                    else {
                        HotkeyWrote = false;
                    }
                    if (f.Name == "HotkeyEnabled")
                    {
                        f.Value = settings.HotkeyEnabled.ToString();
                    }
                    else {
                        HotkeyEnabledWrote = false;
                    }
                }
            }
            catch (NullReferenceException)
            {
                XmlElement CEMTApplication = doc.CreateElement("CEMTApplication");
                doc.DocumentElement.AppendChild(CEMTApplication);
                CheckForUpdatesWrote = false;
                SoundsEnabledWrote = false;
                HotkeyEnabledWrote = false;
                HotkeyWrote = false;
                g = doc.DocumentElement["CEMTApplication"];
            }

            //Anakin Memewalker: This is where the fun begins
            //If any of the attributes failed to write, then remake them and try again.
            if (!SensXWrote)
            {
                XmlAttribute SensX = doc.CreateAttribute("SensX");
                SensX.Value = settings.SensX.ToString();
                root.Attributes.SetNamedItem(SensX);
            }
            if (!SensYWrote)
            {
                XmlAttribute SensY = doc.CreateAttribute("SensY");
                SensY.Value = settings.SensY.ToString();
                root.Attributes.SetNamedItem(SensY);
            }
            if (!PatchAccelWrote)
            {
                XmlAttribute PatchAccel = doc.CreateAttribute("PatchAccel");
                PatchAccel.Value = settings.PatchAcceleration.ToString();
                root.Attributes.SetNamedItem(PatchAccel);
            }

            if (!HotkeyWrote)
            {
                XmlAttribute Hotkey = doc.CreateAttribute("Hotkey");
                Hotkey.Value = settings.Hotkey;
                g.Attributes.SetNamedItem(Hotkey);
            }
            if (!HotkeyEnabledWrote)
            {
                XmlAttribute HotkeyEnabled = doc.CreateAttribute("HotkeyEnabled");
                HotkeyEnabled.Value = settings.HotkeyEnabled.ToString();
                g.Attributes.SetNamedItem(HotkeyEnabled);
            }
            if (!CheckForUpdatesWrote)
            {
                XmlAttribute CheckForUpdates = doc.CreateAttribute("CheckForUpdates");
                CheckForUpdates.Value = settings.CheckForUpdatesOnStart.ToString();
                g.Attributes.SetNamedItem(CheckForUpdates);
            }
            if (!SoundsEnabledWrote)
            {
                XmlAttribute SoundsEnabled = doc.CreateAttribute("SoundsEnabled");
                SoundsEnabled.Value = settings.SoundsEnabled.ToString();
                g.Attributes.SetNamedItem(SoundsEnabled);
            }
            doc.Save(XMLPath);
        }
        /*
            Rob say Code Monkey very dilligent - but his output stink.
            His code not functional or elegant.
            What do code monkey think?
        */
        public static int LoadSettingsFromXML(SettingsHandler s)
        {
            bool err = false; //If an error occurs during the loading, set this to true and leave the setting to its default value.
            if (XMLExists())
            {
                //Load and set values
                XmlReader xmlReader = XmlReader.Create(XMLPath);
                try
                {
                    while (xmlReader.Read())
                    {
                        if ((xmlReader.NodeType == XmlNodeType.Element) && (xmlReader.Name == "CEMTSensitivity"))
                        {
                            if (xmlReader.HasAttributes)
                            {
                                float sensX;
                                float sensY;
                                int patchaccel;
                                if (!float.TryParse(xmlReader.GetAttribute("SensX"), out sensX))
                                {
                                    err = true;
                                }
                                else {
                                    s.SensX = sensX;
                                }
                                if (!float.TryParse(xmlReader.GetAttribute("SensY"), out sensY))
                                {
                                    err = true;
                                }
                                else {
                                    s.SensY = sensY;
                                }
                                if (!int.TryParse(xmlReader.GetAttribute("PatchAccel"), out patchaccel))
                                {
                                    err = true;
                                }
                                else {
                                    s.PatchAcceleration = patchaccel;
                                }
                            }
                        }
                        if ((xmlReader.NodeType == XmlNodeType.Element) && (xmlReader.Name == "CEMTApplication"))
                        {
                            if (xmlReader.HasAttributes)
                            {
                                int checkforupdates;
                                int hotkeyenabled;
                                int soundsenabled;
                                string hotkey = xmlReader.GetAttribute("Hotkey");
                                if (hotkey == null)
                                {
                                    err = true;
                                }
                                else {
                                    s.Hotkey = hotkey;
                                }
                                if (!int.TryParse(xmlReader.GetAttribute("CheckForUpdates"), out checkforupdates))
                                {
                                    err = true;
                                }
                                else {
                                    s.CheckForUpdatesOnStart = checkforupdates;
                                }
                                if (!int.TryParse(xmlReader.GetAttribute("HotkeyEnabled"), out hotkeyenabled))
                                {
                                    err = true;
                                }
                                else {
                                    s.HotkeyEnabled = hotkeyenabled;
                                }
                                if (!int.TryParse(xmlReader.GetAttribute("SoundsEnabled"), out soundsenabled))
                                {
                                    err = true;
                                }
                                else {
                                    s.SoundsEnabled = soundsenabled;
                                }
                                xmlReader.Close();
                            }
                        }
                    }
                }
                catch (XmlException)
                {
                    return 2; //2 == Exception
                }
                if (err == true)
                {
                    return 3; //3 == One or more values not read properly; they are set to default values
                }
                return 1; //1 == Successfully read
            }
            else {
                return 0; //0 == didn't find an XML
            }
            //TODO: Make this class not shit.
        }
    }
}
