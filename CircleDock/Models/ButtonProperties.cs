using System.Windows.Media;

namespace CircleDock.Models
{
    class ButtonProperties : Property
    {
        public string Image
        {
            get => (string)GetValue();
            set
            {
                if (value == Image)
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
        public Color Background
        {
            get => (Color)GetValue();
            set
            {
                if (value == Background)
                    return;

                SetValue(value);
            }
        }
    }
}