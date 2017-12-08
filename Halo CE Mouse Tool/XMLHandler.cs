using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Halo_CE_Mouse_Tool
{
    /*
        -XMLHandler.cs-
        This class handles the applications XML file.
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
        public static void Serialize_Settings(SettingsHandler settings)
        {
            XmlSerializer SerializerObj = new XmlSerializer(typeof(SettingsHandler));
            TextWriter WriteFileStream = new StreamWriter(@XMLPath);
            SerializerObj.Serialize(WriteFileStream, settings);
            WriteFileStream.Close();
        }

        public static void DeSerialize_Settings(SettingsHandler settings)
        {
            XmlSerializer SerializerObj = new XmlSerializer(typeof(SettingsHandler));
            FileStream ReadFileStream = new FileStream(@XMLPath, FileMode.Open, FileAccess.Read, FileShare.Read);
            settings = (SettingsHandler)SerializerObj.Deserialize(ReadFileStream);
            ReadFileStream.Close();
        }
    }
}
