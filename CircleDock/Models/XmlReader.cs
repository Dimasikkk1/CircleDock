using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace CircleDock.Models
{
    // TODO: Нужно удалить этот класс.
    static class XmlReader
    {
        public const string ShortcutsPath = "Resources/Shortcuts.xml";
        public const string ShortcutsRootElement = "Shortcuts";

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

            shortcutsFile.AppendChild(rootElement);

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
