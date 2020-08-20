using CircleDock.Controls;
using System.Windows;

namespace CircleDock.Commands
{
    class ChangePropertiesCommand : DelegateCommand<DependencyObject>
    {
        public ChangePropertiesCommand() : base(e =>
        {
            App app = (App)Application.Current;
            CircleDockControl circleDockControl = (CircleDockControl)e;

            ((IPropertiesConverter)app.Resources["RotationToLeftConverter"]).Properties = circleDockControl.Properties;
            ((IPropertiesConverter)app.Resources["RotationToTopConverter"]).Properties = circleDockControl.Properties;
        })
        { }
    }
}
