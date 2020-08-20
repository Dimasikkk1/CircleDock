using CircleDock.Extensions;
using CircleDock.Models;
using System;
using System.Globalization;
using System.Windows.Data;

namespace CircleDock.Converters
{
    class RotationToTop : IMultiValueConverter, IPropertiesConverter
    {
        public ObservableDictionary<Type, ObservableDictionary<string, object>> Properties { get; set; }

        public object Convert(object[] value, Type targetType, object parameter, CultureInfo culture)
        {
            double radius = (double)Properties[typeof(DockProperties)]["MinimumRadius"],
                iconsPerCircle = (double)Properties[typeof(DockProperties)]["IconsPerCircle"],
                circleInterval = (double)Properties[typeof(DockProperties)]["CircleInterval"],
                shortcutHeight = (double)Properties[typeof(ShortcutProperties)]["Height"],
                centerY = (double)Properties[typeof(WindowProperties)]["Height"] / 2,
                actualRotation = (double)value[0];

            int index = (int)value[1];

            //return (double)(centerY + (radius + index / iconsPerCircle * circleInterval) * Math.Sin((360f / iconsPerCircle * (index + 1) + actualRotation).ToRadians()) - shortcutHeight / 2);
            return (double)(centerY - shortcutHeight / 3 + radius * Math.Sin(actualRotation.ToRadians()));
        }

        public object[] ConvertBack(object value, Type[] targetType, object parameter, CultureInfo culture) =>
            throw new NotSupportedException();
    }
}
