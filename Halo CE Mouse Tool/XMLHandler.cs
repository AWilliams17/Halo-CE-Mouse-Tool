using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Runtime.Serialization;


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
                DataContractSerializer SerializerObj = new DataContractSerializer(typeof(SettingsHandler));
                XmlWriter WriteFileStream = XmlWriter.Create(XMLPath);
                SerializerObj.WriteObject(WriteFileStream, settings);
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
                DataContractSerializer SerializerObj = new DataContractSerializer(typeof(SettingsHandler));
                SettingsHandler settings_loaded;
                FileStream ReadFileStream = new FileStream(@XMLPath, FileMode.Open, FileAccess.Read, FileShare.Read);
                try
                {
                    settings_loaded = (SettingsHandler)SerializerObj.ReadObject(ReadFileStream);
                }
                catch (InvalidOperationException) //Seems to occur if the xml file for some reason has been screwed up.
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
