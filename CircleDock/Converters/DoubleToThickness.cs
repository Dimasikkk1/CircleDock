using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace CircleDock.Converters
{
    class DoubleToThickness : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => new Thickness((double)value);
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => DependencyProperty.UnsetValue;
    }
}
