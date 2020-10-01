namespace CircleDock.Models
{
    class DockProperties : Property
    {
        public bool EnableRotation
        {
            get => GetValue<bool>();
            set => SetValue(value);
        }
        public double MinimumRadius
        {
            get => GetValue<double>();
            set => SetValue(value);
        }

        public double IconsPerCircle
        {
            get => GetValue<double>();
            set => SetValue(value);
        }
        public double CircleInterval
        {
            get => GetValue<double>();
            set => SetValue(value);
        }
        public double RotationStep
        {
            get => GetValue<double>();
            set => SetValue(value);
        }
        public double Rotation
        {
            get => GetValue<double>();
            set => SetValue(value);
        }

        public DockProperties(string configFile) : base(configFile) { }

        public void RotateShortcuts(int delta) => Rotation += RotationStep * delta;
    }
}