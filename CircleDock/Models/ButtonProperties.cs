using System.Windows.Media;

namespace CircleDock.Models
{
    class ButtonProperties : Property
    {
        public string Image
        {
            get => GetValue<string>();
            set => SetValue(value);
        }
        public double Diameter
        {
            get => GetValue<double>();
            set => SetValue(value);
        }
        public Color Background
        {
            get => GetValue<Color>();
            set => SetValue(value);
        }
    }
}