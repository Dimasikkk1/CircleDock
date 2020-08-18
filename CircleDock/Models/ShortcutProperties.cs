namespace CircleDock.Models
{
    class ShortcutProperties : Property
    {
        public string FolderImage
        {
            get => (string)GetValue();
            set
            {
                if (value == FolderImage)
                    return;

                SetValue(value);
            }
        }
        public bool ShowWindowsContextMenu
        {
            get => (bool)GetValue();
            set
            {
                if (value == ShowWindowsContextMenu)
                    return;

                SetValue(value);
            }
        }
        public double Width
        {
            get => (double)GetValue();
            set
            {
                if (value == Width)
                    return;

                SetValue(value);
            }
        }
        public double Height
        {
            get => (double)GetValue();
            set
            {
                if (value == Height)
                    return;

                SetValue(value);
            }
        }
        public double Opacity
        {
            get => (double)GetValue();
            set
            {
                if (value == Opacity)
                    return;

                SetValue(value);
            }
        }
    }
}