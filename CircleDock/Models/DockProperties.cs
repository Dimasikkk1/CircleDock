namespace CircleDock.Models
{
    class DockProperties : Property
    {
        public bool EnableRotation
        {
            get => (bool)GetValue();
            set
            {
                if (value == EnableRotation)
                    return;

                SetValue(value);
            }
        }
        public double MinimumRadius
        {
            get => (double)GetValue();
            set
            {
                if (value == MinimumRadius)
                    return;

                SetValue(value);
            }
        }

        public double IconsPerCircle
        {
            get => (double)GetValue();
            set
            {
                if (value == IconsPerCircle)
                    return;

                SetValue(value);
            }
        }
        public double CircleInterval
        {
            get => (double)GetValue();
            set
            {
                if (value == CircleInterval)
                    return;

                SetValue(value);
            }
        }
        public double RotationStep
        {
            get => (double)GetValue();
            set
            {
                if (value == RotationStep)
                    return;

                SetValue(value);
            }
        }
        public double Rotation
        {
            get => (double)GetValue();
            set
            {
                if (value == Rotation)
                    return;

                SetValue(value);
            }
        }

        public void RotateShortcuts(int delta) => Rotation += RotationStep * delta;
    }
}