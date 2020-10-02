using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows.Media;
using System.Xml;

namespace CircleDock.Models
{
    // TODO: Нужно упростить этот класс.
    static class XmlReader
    {
        public const string ConfigPath = "Resources/Config.xml";
        public const string ConfigRootElement = "Config";

        public const string ShortcutsPath = "Resources/Shortcuts.xml";
        public const string ShortcutsRootElement = "Shortcuts";

        public static void LoadConfig(string configPath = ConfigPath)
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

                    // Это как-то тупо выглядит (не надёжно)
                    Config.Properties[Type.GetType($"{assemblyName}.Models.{rootProperty.Name}")][property.Name] = value;
                }
            }
        }

        public static void SaveConfig(string configPath = ConfigPath)
        {
            XmlDocument configFile = new XmlDocument();
            XmlNode rootNode = configFile.CreateElement(ConfigRootElement);

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

            SaveXml(configFile, configPath);
        }

        public static IEnumerable<Shortcut> GetShortcuts(string shortcutsPath = ShortcutsPath)
        {
            XmlDocument shortcutsFile = new XmlDocument();
            shortcutsFile.Load(shortcutsPath);

            XmlNode rootElement = shortcutsFile.DocumentElement;

            List<Shortcut> result = new List<Shortcut>();

            foreach (XmlNode shortcut in rootElement)
            {
                string path = shortcut.Attributes["Path"].InnerText;
                result.Add(new Shortcut(path));
            }

            return result;
        }

        public static void SaveShortcuts(IEnumerable<Shortcut> shortcuts, string shortcutsPath = ShortcutsPath)
        {
            XmlDocument shortcutsFile = new XmlDocument();
            XmlNode rootElement = shortcutsFile.CreateElement(ShortcutsRootElement);

            foreach (Shortcut shortcut in shortcuts)
            {
                XmlElement shortcutElement = shortcutsFile.CreateElement(nameof(Shortcut));
                shortcutElement.SetAttribute(nameof(shortcut.Path), shortcut.Path);

                rootElement.AppendChild(shortcutElement);
            }

            SaveXml(shortcutsFile, shortcutsPath);
        }

        private static void SaveXml(XmlDocument document, string path)
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(Path.GetDirectoryName(path));

            using (FileStream fileStream = File.Create(path))
                document.Save(fileStream);
        }
    }
}
