using CircleDock.Models;
using System;
using System.Windows.Input;

namespace CircleDock.ViewModels
{
    class SettingsViewModel : ViewModel
    {
        public WindowProperties Window { get; } = new WindowProperties();
        public DockProperties Dock { get; } = new DockProperties();
        public RingProperties Ring { get; } = new RingProperties();
        public ButtonProperties Button { get; } = new ButtonProperties();
        public ShortcutProperties Shortcut { get; } = new ShortcutProperties();

        public ICommand SaveConfigCommand { get; }

        public SettingsViewModel() => SaveConfigCommand = new DelegateCommand<EventArgs>(_ => XmlReader.SaveConfig());
    }
}
