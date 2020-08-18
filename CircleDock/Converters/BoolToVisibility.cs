﻿using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace CircleDock.Converters
{
    class BoolToVisibility : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => (bool)value ? Visibility.Visible : Visibility.Hidden;
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => DependencyProperty.UnsetValue;
    }
}
