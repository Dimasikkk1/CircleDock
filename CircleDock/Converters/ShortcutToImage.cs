using CircleDock.Extensions;
using CircleDock.Models;
using CircleDock.Properties;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace CircleDock.Converters
{
    class ShortcutToImage : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Config config = new Config(Settings.Default.ConfigPath);

            bool isDirectory = ((string)value).IsDirectory();

            return isDirectory
                ? new BitmapImage(new Uri(config.GetSetting<string>("FolderImage").ToRelative()))
                : ((string)value).GetIcon();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) =>
            DependencyProperty.UnsetValue;
    }
}
