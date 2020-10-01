using CircleDock.Extensions;
using CircleDock.Models;
using CircleDock.Properties;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace CircleDock.ViewModels
{
    class MainViewModel
    {
        public WindowProperties Window { get; } = new WindowProperties(Settings.Default.WindowConfig);
        public DockProperties Dock { get; } = new DockProperties(Settings.Default.DockConfig);
        public RingProperties Ring { get; } = new RingProperties(Settings.Default.RingConfig);
        public ButtonProperties Button { get; } = new ButtonProperties(Settings.Default.ButtonConfig);
        public ShortcutProperties Shortcut { get; } = new ShortcutProperties(Settings.Default.ShortcutConfig);
        public ObservableCollection<Shortcut> Shortcuts { get; }

        public ICommand ChangeVisibility { get; }
        public ICommand MouseWheel { get; }
        public ICommand DragEnter { get; }
        public ICommand Drop { get; }

        public MainViewModel()
        {
            try
            {
                Shortcuts = new ObservableCollection<Shortcut>(XmlReader.GetShortcuts());
            }
            catch (Exception)
            {
                Shortcuts = new ObservableCollection<Shortcut>();
            }

            Shortcuts.CollectionChanged += (s, _) => XmlReader.SaveShortcuts((IEnumerable<Shortcut>)s);

            ChangeVisibility = new DelegateCommand<EventArgs>(_ => Window.ChangeVisibility());
            MouseWheel = new DelegateCommand<MouseWheelEventArgs>(e => Dock.RotateShortcuts(-e.Delta / 120));
            DragEnter = new DelegateCommand<DragEventArgs>(e => e.Effects = e.Data.IsFile() ? DragDropEffects.Copy : DragDropEffects.None);
            Drop = new DelegateCommand<DragEventArgs>(e => Shortcuts.AddFiles(e.Data), e => e.Data.IsFile());

#if !DEBUG
            Hook.GlobalEvents().MouseClick += (s, e) =>
            {
                if (e.Button != System.Windows.Forms.MouseButtons.Middle)
                    return;

                Window.ChangeVisibility();

                if (!Window.Visibility)
                    return;

                Window.Left = e.X - Window.Width / 2;
                Window.Top = e.Y - Window.Height / 2;
            };
#endif
        }
    }
}
