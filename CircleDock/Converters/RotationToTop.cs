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

            radius = radius + index / (int)iconsPerCircle * circleInterval;
            
            double angle = (360f / iconsPerCircle * (index + 1) + actualRotation).ToRadians();

            return (double)(centerY + radius * Math.Sin(angle) - shortcutHeight / 2);
        }

        public object[] ConvertBack(object value, Type[] targetType, object parameter, CultureInfo culture) =>
            throw new NotSupportedException();
    }
}
