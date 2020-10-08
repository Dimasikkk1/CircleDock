using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using System.Xml.Linq;

namespace CircleDock.Models
{
    class Config
    {
        private const string Root = "Settings";
        private const string Element = "Setting";
        private const string Key = "Key";
        private const string Value = "Value";

        private static XDocument configFile;

        public string Path { get; }
        
        public Config(string configPath)
        {
            Path = configPath;
        }

        public void Load() => configFile = XDocument.Load(Path);
        public void Save() => configFile.Save(Path);
        public void SaveObject(object configObject)
        {
            XDocument configFile = new XDocument();
            XElement configFileRoot = new XElement(Root);

            var properties = configObject.GetType().GetProperties();

            foreach (var property in properties)
            {
                configFileRoot.Add(new XElement(Element,
                    new XAttribute(Key, property.Name),
                    new XAttribute(Value, property.GetValue(configObject).ToString())));
            }

            configFile.Add(configFileRoot);
            configFile.Save(Path);

            SettingChanged?.Invoke(this, string.Empty);
        }
        public T GetSetting<T>(string key)
        {
            XAttribute setting = FindAttribute(configFile, key);

            if (string.IsNullOrEmpty(setting.Value))
                throw new KeyNotFoundException();

            return (T)Parse(setting.Value);
        }
        public void SetSetting(string key, object value)
        {
            XAttribute setting = FindAttribute(configFile, key);

            if (setting.Value == value.ToString())
                return;

            setting.Value = value.ToString();

            SettingChanged?.Invoke(this, key);
        }

        private static XAttribute FindAttribute(XDocument configFile, string key)
        {
            return configFile.Element(Root)
                             .Elements(Element)
                             .FirstOrDefault(element => element.Attribute(Key).Value == key)
                             .Attribute(Value);
        }
        private static object Parse(string value)
        {
            object result = null;

            if (double.TryParse(value, out double doubleResult))
                result = doubleResult;

            if (bool.TryParse(value, out bool boolResult))
                result = boolResult;

            if (value[0] == '#')
                result = (Color)ColorConverter.ConvertFromString(value);

            // TODO: Почему-то Vector.ToString() не подходит для парсинга (истоки в методе SaveObject)
            if (value.IndexOf(';') != -1)
                result = Vector.Parse(value.Replace(';', ','));

            result = result ?? value;

            return result;
        }

        public static event EventHandler<string> SettingChanged;
    }
}
