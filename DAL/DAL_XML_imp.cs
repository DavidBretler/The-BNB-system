using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;
using BE;
namespace DAL
{
    class DAL_XML_imp
    {
        XElement configRoot;
        XElement OrderRoot;

        static readonly string ProjectPath = Directory.GetParent(Directory.GetParent(Environment.CurrentDirectory.ToString()).FullName).FullName;//path of xml files
        private readonly string configPath = ProjectPath + "/Data/config.xml";
        /// <summary>
        /// Save To XML tamplate
        /// </summary>
        /// <typeparam name="T"></typeparam>עעעעעעעעעעעעעע
        /// <param name="source"></param>
        /// <param name="path"></param>
        public static void SaveToXML<T>(T source, string path)
        {
            FileStream file = new FileStream(path, FileMode.Create);
            XmlSerializer xmlSerializer = new XmlSerializer(source.GetType());
            xmlSerializer.Serialize(file, source); file.Close();
        }

        /// <summary>
        /// Load From XML tamplate
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path"></param>
        /// <returns></returns>
        public static T LoadFromXML<T>(string path)
        {
            FileStream file = new FileStream(path, FileMode.Open);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            T result = (T)xmlSerializer.Deserialize(file);
            file.Close();
            return result;
        }

        //public static T AddNewObject<T>( object sourceToAdd, string path )
        //{

        //    List < T>  tempList = new List< T >() ; 
        //    tempList = LoadFromXML<T.GetType>(path);
        //    tempList.Add(temp);
        //    SaveToXML( source,  path);
        //}

        //private void SaveConfigToXml()
        //{
        //    configRoot = new XElement("config");
        //    try
        //    {
        //        configRoot.Add(new XElement("HostingUnitKey", BE.Configuration.HostingUnitKey),
        //                       new XElement("GuestRequestKey", BE.Configuration.GuestRequestKey),
        //                       new XElement("HostKey", BE.Configuration.HostKey),
        //                       new XElement("OrderKey", BE.Configuration.OrderKey),
        //                       new XElement("Commission", BE.Configuration.Commission),
        //                       new XElement("Password", BE.Configuration.Password),
        //                       new XElement("MangerPassword", BE.Configuration.MangerPassword);                           
        //        configRoot.Save(configPath);     
        //    }
        //    catch (Exception)
        //    { }
        //}
        internal DAL_XML_imp()
        {
            if (!File.Exists(configPath))
            {
               // SaveConfigToXml();
            }
            else
            {
                configRoot = XElement.Load(configPath);
                BE.Configuration.HostingUnitKey = Convert.ToInt32(configRoot.Element("HostingUnitKey").Value);
                BE.Configuration.GuestRequestKey = Convert.ToInt32(configRoot.Element("GuestRequestKey").Value);
                BE.Configuration.HostKey = Convert.ToInt32(configRoot.Element("HostKey").Value);
                BE.Configuration.Commission = Convert.ToInt32(configRoot.Element("Commission").Value);
                BE.Configuration.Password = Convert.ToInt32(configRoot.Element("Password").Value);
                BE.Configuration.MangerPassword = configRoot.Element("MangerPassword").Value;

            }
            //if (!File.Exists(configPath))
            //{
            //    configRoot = new XElement("trainees");
            //    configRoot.Save(configPath);
            //}
            //if (!File.Exists(configPath))
            //{
            //    SaveToXML(new List<Configuration>(), configPath);
            //}
            //if (!File.Exists(configPath))
            //{
            //    SaveToXML(new List<Configuration>(), configPath);
            //}
            //configRoot = XElement.Load(configPath);

            //configPath = LoadFromXML<List<Configuration>>(configPath);
            //tests = LoadFromXML<List<Configuration>>(configPath);
        }

    }

}
