using CircleDock.Extensions;
using CircleDock.Models;
using System;
using System.Globalization;
using System.Windows.Data;

namespace CircleDock.Converters
{
    class RotationToLeft : IMultiValueConverter, IPropertiesConverter
    {
        public ObservableDictionary<Type, ObservableDictionary<string, object>> Properties { get; set; }

        public object Convert(object[] value, Type targetType, object parameter, CultureInfo culture)
        {
            double radius = (double)Properties[typeof(DockProperties)]["MinimumRadius"],
                iconsPerCircle = (double)Properties[typeof(DockProperties)]["IconsPerCircle"],
                circleInterval = (double)Properties[typeof(DockProperties)]["CircleInterval"],
                shortcutWidth = (double)Properties[typeof(ShortcutProperties)]["Width"],
                centerX = (double)Properties[typeof(WindowProperties)]["Width"] / 2,
                actualRotation = (double)value[0];

            int index = (int)value[1];

            radius = radius + index / (int)iconsPerCircle * circleInterval;

            double angle = (360f / iconsPerCircle * (index + 1) + actualRotation).ToRadians();

            return (double)(centerX + radius * Math.Cos(angle) - shortcutWidth / 2);
        }

        public object[] ConvertBack(object value, Type[] targetType, object parameter, CultureInfo culture) =>
            throw new NotSupportedException();
    }
}
