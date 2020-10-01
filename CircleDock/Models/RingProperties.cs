using System.Windows.Media;

namespace CircleDock.Models
{
    class RingProperties : Property
    {
        public Color Color
        {
            get => GetValue<Color>();
            set => SetValue(value);
        }
        public double Diameter
        {
            get => GetValue<double>();
            set => SetValue(value);
        }
        public double Thickness
        {
            get => GetValue<double>();
            set => SetValue(value);
        }

        public RingProperties(string configFile) : base(configFile) { }
    }
}