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
        public static string XMLPath;

        public XMLHandler(string xmlpath)
        {
            XMLPath = xmlpath;
        }

        public static bool XMLExists()
        { //Check if the XML configuration file exists.
            return File.Exists(XMLPath);
        }
        public static int Serialize_Settings(SettingsHandler settings) //For context, if I am calling it in processexit, the context will be 0. Otherwise, it will be 1.
        {
            try
            {
                XmlSerializer SerializerObj = new XmlSerializer(typeof(SettingsHandler));
                TextWriter WriteFileStream = new StreamWriter(@XMLPath);
                SerializerObj.Serialize(WriteFileStream, settings);
                WriteFileStream.Close();
                return 1; //Success
            }
            catch (UnauthorizedAccessException)
            {
                return 0; //Exception occurred. Let the caller handle it.
            }
        }

        public static SettingsHandler DeSerialize_Settings()
        {
            if (XMLExists())
            {
                XmlSerializer SerializerObj = new XmlSerializer(typeof(SettingsHandler));
                SettingsHandler settings_loaded;
                FileStream ReadFileStream = new FileStream(@XMLPath, FileMode.Open, FileAccess.Read, FileShare.Read);
                try
                {
                    settings_loaded = (SettingsHandler)SerializerObj.Deserialize(ReadFileStream);
                }
                catch (System.InvalidOperationException)
                {
                    settings_loaded = null; //Failed to load it. return null. I will leave what to do with the corrupt config file up to the user.
                }
                finally //Always close the filestream no matter the outcome.
                {
                    ReadFileStream.Close();
                }
                return settings_loaded;
            }
            return null; //It doesn't exist. Return null.
        }
    }
}
