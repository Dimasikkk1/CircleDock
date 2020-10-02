namespace CircleDock.Models
{
    class WindowProperties : Property
    {
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

        public void ChangeVisibility() => Visibility = !Visibility;
    }
}
