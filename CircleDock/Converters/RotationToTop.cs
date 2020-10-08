using CircleDock.Extensions;
using CircleDock.Models;
using CircleDock.Properties;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace CircleDock.Converters
{
    class RotationToTop : IMultiValueConverter
    {
        public object Convert(object[] value, Type targetType, object parameter, CultureInfo culture)
        {
            Config config = new Config(Settings.Default.ConfigPath);

            double radius = config.GetSetting<double>("Radius"),
                iconsPerCircle = config.GetSetting<double>("ShortcutsPerCircle"),
                circleInterval = config.GetSetting<double>("CircleInterval"),
                shortcutHeight = config.GetSetting<Vector>("ShortcutSize").Y,
                centerY = config.GetSetting<Vector>("WindowSize").Y / 2,
                actualRotation = (double)value[0];

            int index = (int)value[1];

            radius += index / (int)iconsPerCircle * circleInterval;
            
            double angle = (360f / iconsPerCircle * (index + 1) + actualRotation).ToRadians();

            return (double)(centerY + radius * Math.Sin(angle) - shortcutHeight / 2);
        }

        public object[] ConvertBack(object value, Type[] targetType, object parameter, CultureInfo culture) =>
            throw new NotSupportedException();
    }
}
