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
        private static string XMLPath;

        public XMLHandler(string xmlpath)
        {
            XMLPath = xmlpath;
        }

        private static bool XMLExists()
        { //Check if the XML configuration file exists.
            return File.Exists(XMLPath);
        }
        public static void Serialize_Settings(SettingsHandler settings)
        {
            XmlSerializer SerializerObj = new XmlSerializer(typeof(SettingsHandler));
            TextWriter WriteFileStream = new StreamWriter(@XMLPath);
            SerializerObj.Serialize(WriteFileStream, settings);
            WriteFileStream.Close();
        }

        public static SettingsHandler DeSerialize_Settings()
        {
            if (XMLExists())
            {
                XmlSerializer SerializerObj = new XmlSerializer(typeof(SettingsHandler));
                FileStream ReadFileStream = new FileStream(@XMLPath, FileMode.Open, FileAccess.Read, FileShare.Read);
                SettingsHandler settings_loaded = (SettingsHandler)SerializerObj.Deserialize(ReadFileStream);
                ReadFileStream.Close();
                return settings_loaded;
            }
            return null;
        }
    }
}
