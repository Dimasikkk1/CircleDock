using System;
using System.IO;
using System.Reflection;
using System.Windows.Media;
using System.Xml;

namespace CircleDock.Models
{
    static class ConfigManager
    {
        public const string ConfigPath = "Resources/Config.xml";
        public const string RootElement = "Config";

        public static void Load(string configPath = ConfigPath)
        {
            XmlDocument configFile = new XmlDocument();
            configFile.Load(configPath);

            XmlNode rootNode = configFile.DocumentElement;

            string assemblyName = Assembly.GetExecutingAssembly().GetName().Name;

            foreach (XmlNode rootProperty in rootNode)
            {
                foreach (XmlNode property in rootProperty)
                {
                    object value = null;

                    if (double.TryParse(property.InnerText, out double doubleResult))
                        value = doubleResult;

                    if (bool.TryParse(property.InnerText, out bool boolResult))
                        value = boolResult;

                    if (property.InnerText[0] == '#')
                        value = (Color)ColorConverter.ConvertFromString(property.InnerText);

                    value = value ?? property.InnerText;

                    Config.Properties[Type.GetType($"{assemblyName}.Models.{rootProperty.Name}")][property.Name] = value;
                }
            }
        }

        public static void Save(string configPath = ConfigPath)
        {
            XmlDocument configFile = new XmlDocument();
            XmlNode rootNode = configFile.CreateElement(RootElement);

            foreach (var rootProperty in Config.Properties.Keys)
            {
                XmlNode rootPropertyNode = configFile.CreateElement(rootProperty.Name);

                foreach (var property in Config.Properties[rootProperty].Keys)
                {
                    XmlNode propertyNode = configFile.CreateElement(property);
                    propertyNode.AppendChild(configFile.CreateTextNode(Config.Properties[rootProperty][property].ToString()));

                    rootPropertyNode.AppendChild(propertyNode);
                }

                rootNode.AppendChild(rootPropertyNode);
            }

            configFile.AppendChild(rootNode);

            if (!Directory.Exists(configPath))
                Directory.CreateDirectory(Path.GetDirectoryName(configPath));

            using (FileStream fileStream = File.Create(configPath))
                configFile.Save(fileStream);
        }
    }
}
