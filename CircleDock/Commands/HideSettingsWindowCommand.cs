using CircleDock.ViewModels;
using System;
using System.Windows;

namespace CircleDock.Commands
{
    class HideSettingsWindowCommand : DelegateCommand<EventArgs>
    {
        public HideSettingsWindowCommand() : base(_ =>
        {
            App app = (App)Application.Current;

            try
            {
                SettingsViewModel settingsViewModel = (SettingsViewModel)app.DisplayRootRegistry.GetVmByType<SettingsViewModel>();

                app.DisplayRootRegistry.HidePresentation(settingsViewModel);
            }
            catch (Exception) { }
        })
        { }
    }
}
