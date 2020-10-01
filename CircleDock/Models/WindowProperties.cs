using System.Globalization;
using System.Windows;
using System.Xml.Linq;

namespace CircleDock.Models
{
    class WindowProperties : Property
    {
        protected override XDocument Default => new XDocument(
            new XElement(Root,
                new XElement(Element,
                    new XAttribute(AttributeKey, nameof(Visibility)),
                    new XAttribute(AttributeValue, true)),
                new XElement(Element,
                    new XAttribute(AttributeKey, nameof(Width)),
                    new XAttribute(AttributeValue, SystemParameters.PrimaryScreenWidth)),
                new XElement(Element,
                    new XAttribute(AttributeKey, nameof(Height)),
                    new XAttribute(AttributeValue, SystemParameters.PrimaryScreenHeight)),
                new XElement(Element,
                    new XAttribute(AttributeKey, nameof(Left)),
                    new XAttribute(AttributeValue, 0)),
                new XElement(Element,
                    new XAttribute(AttributeKey, nameof(Top)),
                    new XAttribute(AttributeValue, 0)),
                new XElement(Element,
                    new XAttribute(AttributeKey, nameof(Topmost)),
                    new XAttribute(AttributeValue, true)),
                new XElement(Element,
                    new XAttribute(AttributeKey, nameof(HideAfterOpen)),
                    new XAttribute(AttributeValue, false)),
                new XElement(Element,
                    new XAttribute(AttributeKey, nameof(Language)),
                    new XAttribute(AttributeValue, CultureInfo.CurrentCulture.Name))));

        public bool Visibility
        {
            get => GetValue<bool>();
            set => SetValue(value);
        }
        public double Width
        {
            get => GetValue<double>();
            set => SetValue(value);
        }
        public double Height
        {
            get => GetValue<double>();
            set => SetValue(value);
        }
        public double Left
        {
            get => GetValue<double>();
            set => SetValue(value);
        }
        public double Top
        {
            get => GetValue<double>();
            set => SetValue(value);
        }
        public bool Topmost
        {
            get => GetValue<bool>();
            set => SetValue(value);
        }
        public bool HideAfterOpen
        {
            get => GetValue<bool>();
            set => SetValue(value);
        }
        public string Language
        {
            get => GetValue<string>();
            set => SetValue(value);
        }

        public WindowProperties(string configPath)
        {
            this.configPath = configPath;
            configFile = Default;
        }

        public void ChangeVisibility() => Visibility = !Visibility;
    }
}
