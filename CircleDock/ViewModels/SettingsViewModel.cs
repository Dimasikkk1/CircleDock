using System;
using System.Windows.Input;

namespace CircleDock.ViewModels
{
    class SettingsViewModel : BaseViewModel
    {
        public ICommand SaveConfigCommand { get; }

        public SettingsViewModel() : base() => SaveConfigCommand = new DelegateCommand<EventArgs>(_ => config.Save());
    }
}
