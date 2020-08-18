using CircleDock.Extensions;
using CircleDock.Models;
using System;
using System.Globalization;
using System.Windows.Data;

namespace CircleDock.Converters
{
    class RotationToTop : IMultiValueConverter
    {
        public object Convert(object[] value, Type targetType, object parameter, CultureInfo culture)
        {
            double radius = (double)Config.Properties[typeof(DockProperties)]["MinimumRadius"],
                iconsPerCircle = (double)Config.Properties[typeof(DockProperties)]["IconsPerCircle"],
                circleInterval = (double)Config.Properties[typeof(DockProperties)]["CircleInterval"],
                shortcutHeight = (double)Config.Properties[typeof(ShortcutProperties)]["Height"],
                centerY = (double)Config.Properties[typeof(WindowProperties)]["Height"] / 2,
                actualRotation = (double)value[0];

            int index = (int)value[1];

            return (double)(centerY + (radius + index / iconsPerCircle * circleInterval) * Math.Sin((360f / iconsPerCircle * (index + 1) + actualRotation).ToRadians()) - shortcutHeight / 2);
        }

        public object[] ConvertBack(object value, Type[] targetType, object parameter, CultureInfo culture) =>
            throw new NotSupportedException();
    }
}
