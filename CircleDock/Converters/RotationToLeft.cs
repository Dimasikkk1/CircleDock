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

            //return (double)(centerX + (radius + index / iconsPerCircle * circleInterval) * Math.Cos((360f / iconsPerCircle * (index + 1) + actualRotation).ToRadians()) - shortcutWidth / 2);
            return (double)(centerX - shortcutWidth / 2 + radius * Math.Cos(actualRotation.ToRadians()));
        }

        public object[] ConvertBack(object value, Type[] targetType, object parameter, CultureInfo culture) =>
            throw new NotSupportedException();
    }
}
