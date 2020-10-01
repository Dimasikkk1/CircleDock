namespace CircleDock.Models
{
    class ShortcutProperties : Property
    {
        public string FolderImage
        {
            get => GetValue<string>();
            set => SetValue(value);
        }
        public bool ShowWindowsContextMenu
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
        public double Opacity
        {
            get => GetValue<double>();
            set => SetValue(value);
        }

        public ShortcutProperties(string configFile) : base(configFile) { }
    }
}