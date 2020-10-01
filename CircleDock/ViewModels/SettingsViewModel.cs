using CircleDock.Models;
using CircleDock.Properties;
using System;
using System.Windows.Input;

namespace CircleDock.ViewModels
{
    class SettingsViewModel
    {
        public WindowProperties Window { get; } = new WindowProperties(Settings.Default.WindowConfig);
        public DockProperties Dock { get; } = new DockProperties(Settings.Default.DockConfig);
        public RingProperties Ring { get; } = new RingProperties(Settings.Default.RingConfig);
        public ButtonProperties Button { get; } = new ButtonProperties(Settings.Default.ButtonConfig);
        public ShortcutProperties Shortcut { get; } = new ShortcutProperties(Settings.Default.ShortcutConfig);

        public ICommand SaveConfigCommand { get; }

        //public SettingsViewModel() => SaveConfigCommand = new DelegateCommand<EventArgs>(_ => XmlReader.SaveConfig());
    }
}
