using System.Windows.Media;

namespace CircleDock.Models
{
    class RingProperties : Property
    {
        public Color Color
        {
            get => (Color)GetValue();
            set
            {
                if (value == Color)
                    return;

                SetValue(value);
            }
        }
        public double Diameter
        {
            get => (double)GetValue();
            set
            {
                if (value == Diameter)
                    return;

                SetValue(value);
            }
        }
        public double Thickness
        {
            get => (double)GetValue();
            set
            {
                if (value == Thickness)
                    return;

                SetValue(value);
            }
        }
    }
}