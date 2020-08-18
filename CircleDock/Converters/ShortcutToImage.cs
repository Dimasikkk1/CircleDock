using CircleDock.Extensions;
using CircleDock.Models;
using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace CircleDock.Converters
{
    class ShortcutToImage : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => ((string)value).IsDirectory() ? new BitmapImage(new Uri(((string)Config.Properties[typeof(ShortcutProperties)]["FolderImage"]).ToRelative())) : ((string)value).GetIcon();
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotSupportedException();
    }
}
