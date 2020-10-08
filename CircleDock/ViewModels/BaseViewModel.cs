using CircleDock.Models;
using CircleDock.Properties;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Media;

namespace CircleDock.ViewModels
{
    abstract class BaseViewModel : INotifyPropertyChanged
    {
        private readonly object defaultConfig = new
        {
            WindowSize = new Vector(SystemParameters.PrimaryScreenWidth, SystemParameters.PrimaryScreenHeight),
            WindowPosition = new Vector(0, 0),
            Visibility = true,
            Topmost = true,
            HideAfterOpen = false,
            Language = CultureInfo.CurrentCulture.Name,

            EnableRotation = true,
            ShortcutsPerCircle = 13,
            Radius = 130,
            CircleInterval = 50,
            RotationStep = 30,
            Rotation = 0,

            RingColor = Colors.LightGray,
            RingDiameter = 200,
            RingThickness = 50,

            ButtonImage = "Resources/Icons/Button.png",
            ButtonDiameter = 100,
            ButtonBackground = Colors.Azure,

            FolderImage = "Resources/Icons/Folder.png",
            ShowWindowsContextMenu = true,
            ShortcutSize = new Vector(74, 70),
            ShortcutOpacity = 1
        };
        private readonly Config config;

        #region Window Properties
        public Vector WindowSize
        {
            get => GetValue<Vector>();
            set => SetValue(value);
        }
        public Vector WindowPosition
        {
            get => GetValue<Vector>();
            set => SetValue(value);
        }
        public bool Visibility
        {
            get => GetValue<bool>();
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
        #endregion

        #region Dock Properties
        public bool EnableRotation
        {
            get => GetValue<bool>();
            set => SetValue(value);
        }
        public double ShortcutsPerCircle
        {
            get => GetValue<double>();
            set => SetValue(value);
        }
        public double Radius
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
        #endregion

        #region Ring Properties
        public Color RingColor
        {
            get => GetValue<Color>();
            set => SetValue(value);
        }
        public double RingDiameter
        {
            get => GetValue<double>();
            set => SetValue(value);
        }
        public double RingThickness
        {
            get => GetValue<double>();
            set => SetValue(value);
        }
        #endregion

        #region ButtonProperties
        public string ButtonImage
        {
            get => GetValue<string>();
            set => SetValue(value);
        }
        public double ButtonDiameter
        {
            get => GetValue<double>();
            set => SetValue(value);
        }
        public Color ButtonBackground
        {
            get => GetValue<Color>();
            set => SetValue(value);
        }
        #endregion

        #region Shortcuts Properties
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
        public Vector ShortcutSize
        {
            get => GetValue<Vector>();
            set => SetValue(value);
        }
        public double ShortcutOpacity
        {
            get => GetValue<double>();
            set => SetValue(value);
        }
        #endregion

        protected BaseViewModel()
        {
            config = new Config(Settings.Default.ConfigPath);

            try
            {
                config.Load();
            }
            catch (FileNotFoundException)
            {
                SaveDefaultConfig();

                config.Load();
            }

            Config.SettingChanged += (s, e) =>
            {
                if (string.IsNullOrEmpty(e))
                {
                    var properties = GetType().GetProperties();

                    foreach (var property in properties)
                        OnPropertyChanged(property.Name);

                    return;
                }

                OnPropertyChanged(e);
            };
        }

        protected virtual T GetValue<T>([CallerMemberName] string property = "") =>
            config.GetSetting<T>(property);
        protected virtual void SetValue(object value, [CallerMemberName] string property = "") =>
            config.SetSetting(property, value);

        private void SaveDefaultConfig()
        {
            if (!Directory.Exists(config.Path))
                Directory.CreateDirectory(Path.GetDirectoryName(config.Path));

            config.SaveObject(defaultConfig);
        }

        #region INotifyPropertyChanged
        private void OnPropertyChanged([CallerMemberName] string property = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));

        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
    }
}
