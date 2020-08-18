using CircleDock.Models;
using CircleDock.ViewModels;
using CircleDock.Views;
using System.Globalization;
using System.Threading;
using System.Windows;

namespace CircleDock
{
    public partial class App : Application
    {
        public readonly DisplayRootRegistry DisplayRootRegistry = new DisplayRootRegistry();

        public App()
        {
            DisplayRootRegistry.RegisterWindowType<MainViewModel, MainWindow>();
            DisplayRootRegistry.RegisterWindowType<SettingsViewModel, SettingsWindow>();

            Config.Properties[typeof(WindowProperties)].CollectionChanged += (s, e) =>
            {
                if (e.NewItems[0].ToString() != "Language")
                    return;

                CultureInfo cultureInfo = new CultureInfo((string)Config.Properties[typeof(WindowProperties)][e.NewItems[0].ToString()]);
                Thread.CurrentThread.CurrentCulture = cultureInfo;
                Thread.CurrentThread.CurrentUICulture = cultureInfo;
            };
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            DisplayRootRegistry.ShowPresentation(new MainViewModel());
        }
    }
}
