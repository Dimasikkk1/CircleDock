using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml.Linq;
using System;
using System.Windows.Media;
using System.Xml.Serialization;

namespace CircleDock.Models
{
    // TODO: При использовании внешних конфигов получается сомнительная шляпа
    abstract class Property : INotifyPropertyChanged
    {
        protected const string Root = "Settings";
        protected const string Element = "Setting";
        protected const string AttributeKey = "Name";
        protected const string AttributeValue = "Value";

        protected string configPath;
        protected XDocument configFile;

        protected abstract XDocument Default { get; }

        protected virtual T GetValue<T>([CallerMemberName] string property = "")
        {
            if (configPath != null)
                configFile = XDocument.Load(configPath);

            XElement setting = GetSetting(property);
            string value = setting.Attribute(AttributeValue).Value;

            if (string.IsNullOrEmpty(value))
                throw new KeyNotFoundException();

            return (T)Parse(value);
        }
        protected virtual void SetValue(object value, [CallerMemberName] string property = "")
        {
            XElement setting = GetSetting(property);

            if (setting != null)
            {
                if (setting.Attribute(AttributeValue).Value == value.ToString())
                    return;

                setting.Attribute(AttributeValue).Value = value.ToString();
            }
            else
                configFile.Element(Root).Add(
                    new XElement(Element,
                        new XAttribute(AttributeKey, property),
                        new XAttribute(AttributeValue, value.ToString())));

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));

            if (string.IsNullOrEmpty(configPath))
                throw new NullReferenceException();

            configFile.Save(configPath);
        }

        protected static XDocument Serialize<T>(T obj)
        {
            XDocument result = new XDocument();

            using (var writer = result.CreateWriter())
            {
                XmlSerializer xmlSerializer = new XmlSerializer(obj.GetType());

                xmlSerializer.Serialize(writer, obj);
            }

            return result;
        }

        private XElement GetSetting(string name)
        {
            return configFile.Element(Root)
                             .Elements(Element)
                             .FirstOrDefault(element => element.Attribute(AttributeKey).Value == name);
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

            result ??= value;

            return result;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
    }
}
