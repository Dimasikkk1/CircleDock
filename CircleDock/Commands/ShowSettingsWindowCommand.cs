using CircleDock.ViewModels;
using System;
using System.Windows;

namespace CircleDock.Commands
{
    class ShowSettingsWindowCommand : DelegateCommand<EventArgs>
    {
        private static readonly SettingsViewModel settingsViewModel = new SettingsViewModel();

        public ShowSettingsWindowCommand() : base(_ =>
        {
            App app = (App)Application.Current;

            try
            {
                app.DisplayRootRegistry.ShowPresentation(settingsViewModel);
            }
            catch (Exception) { }
        })
        { }
    }
}
