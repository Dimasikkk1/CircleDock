using CircleDock.Extensions;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace CircleDock.Converters
{
    class StringToImage : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) =>
            new BitmapImage(new Uri(((string)value).ToRelative()));
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) =>
            DependencyProperty.UnsetValue;
    }
}
