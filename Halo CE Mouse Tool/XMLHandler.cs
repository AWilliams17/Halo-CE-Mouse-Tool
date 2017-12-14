using System;
using System.IO;
using System.Xml;
using System.Runtime.Serialization;


namespace Halo_CE_Mouse_Tool
{
    /*
        -XMLHandler.cs-
        This class handles the applications XML file.
    */
    public class XmlHandler
    {
        public static string XmlPath;

        public XmlHandler(string xmlpath)
        {
            XmlPath = xmlpath;
        }

        public static bool XmlExists()
        { //Check if the XML configuration file exists.
            return File.Exists(XmlPath);
        }
        public static int Serialize_Settings(SettingsHandler settings) //For context, if I am calling it in processexit, the context will be 0. Otherwise, it will be 1.
        {
            try
            {
                DataContractSerializer serializerObj = new DataContractSerializer(typeof(SettingsHandler));
                XmlWriter writeFileStream = XmlWriter.Create(XmlPath);
                serializerObj.WriteObject(writeFileStream, settings);
                writeFileStream.Close();
                return 1; //Success
            }
            catch (UnauthorizedAccessException)
            {
                return 0; //Exception occurred. Let the caller handle it.
            }
        }

        public static SettingsHandler DeSerialize_Settings()
        {
            if (XmlExists())
            {
                DataContractSerializer serializerObj = new DataContractSerializer(typeof(SettingsHandler));
                SettingsHandler settingsLoaded;
                FileStream readFileStream = new FileStream(XmlPath, FileMode.Open, FileAccess.Read, FileShare.Read);
                try
                {
                    settingsLoaded = (SettingsHandler)serializerObj.ReadObject(readFileStream);
                }
                catch (InvalidOperationException) //Seems to occur if the xml file for some reason has been screwed up.
                {
                    settingsLoaded = null; //Failed to load it. return null. I will leave what to do with the corrupt config file up to the user.
                }
                finally //Always close the filestream no matter the outcome.
                {
                    readFileStream.Close();
                }
                return settingsLoaded;
            }
            return null; //It doesn't exist. Return null.
        }
    }
}
