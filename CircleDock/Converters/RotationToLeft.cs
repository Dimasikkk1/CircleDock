using CircleDock.Extensions;
using CircleDock.Models;
using System;
using System.Globalization;
using System.Windows.Data;

namespace CircleDock.Converters
{
    class RotationToLeft : IMultiValueConverter
    {
        public object Convert(object[] value, Type targetType, object parameter, CultureInfo culture)
        {
            double radius = (double)Config.Properties[typeof(DockProperties)]["MinimumRadius"],
                iconsPerCircle = (double)Config.Properties[typeof(DockProperties)]["IconsPerCircle"],
                circleInterval = (double)Config.Properties[typeof(DockProperties)]["CircleInterval"],
                shortcutWidth = (double)Config.Properties[typeof(ShortcutProperties)]["Width"],
                centerX = (double)Config.Properties[typeof(WindowProperties)]["Width"] / 2,
                actualRotation = (double)value[0];

            int index = (int)value[1];

            return (double)(centerX + (radius + index / iconsPerCircle * circleInterval) * Math.Cos((360f / iconsPerCircle * (index + 1) + actualRotation).ToRadians()) - shortcutWidth / 2);
        }

        public object[] ConvertBack(object value, Type[] targetType, object parameter, CultureInfo culture) =>
            throw new NotSupportedException();
    }
}
