namespace CircleDock.Models
{
    class WindowProperties : Property
    {
        public bool Visibility
        {
            get => (bool)GetValue();
            set
            {
                if (value == Visibility)
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
        public double Left
        {
            get => (double)GetValue();
            set
            {
                if (value == Left)
                    return;

                SetValue(value);
            }
        }
        public double Top
        {
            get => (double)GetValue();
            set
            {
                if (value == Top)
                    return;

                SetValue(value);
            }
        }
        public bool Topmost
        {
            get => (bool)GetValue();
            set
            {
                if (value == Topmost)
                    return;

                SetValue(value);
            }
        }
        public bool HideAfterOpen
        {
            get => (bool)GetValue();
            set
            {
                if (value == HideAfterOpen)
                    return;

                SetValue(value);
            }
        }

        public string Language
        {
            get => (string)GetValue();
            set
            {
                if (value == Language)
                    return;

                SetValue(value);
            }
        }

        public void ChangeVisibility() => Visibility = !Visibility;
    }
}
