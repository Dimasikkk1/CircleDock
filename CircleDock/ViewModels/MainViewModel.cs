using CircleDock.Extensions;
using CircleDock.Models;
using Gma.System.MouseKeyHook;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace CircleDock.ViewModels
{
    // TODO: Наверно лучше отказаться от переноса свойств в отдельные классы
    class MainViewModel
    {
        public ObservableDictionary<Type, ObservableDictionary<string, object>> Properties { get; }
        public WindowProperties Window { get; } = new WindowProperties();
        public DockProperties Dock { get; } = new DockProperties();
        public RingProperties Ring { get; } = new RingProperties();
        public ButtonProperties Button { get; } = new ButtonProperties();
        public ShortcutProperties Shortcut { get; } = new ShortcutProperties();
        public ObservableCollection<Shortcut> Shortcuts { get; }

        public ICommand ChangeVisibility { get; }
        public ICommand MouseWheel { get; }
        public ICommand DragEnter { get; }
        public ICommand Drop { get; }

        public MainViewModel()
        {
            Config.Initialize();

            Properties = Config.Properties;

            try
            {
                Shortcuts = new ObservableCollection<Shortcut>(XmlReader.GetShortcuts());
                Shortcuts.GiveIndexes();
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

                ChangeVisibility.Execute(null);

                if (!Window.Visibility)
                    return;

                Window.Left = e.X - Window.Width / 2;
                Window.Top = e.Y - Window.Height / 2;
            };
#endif
        }
    }
}
