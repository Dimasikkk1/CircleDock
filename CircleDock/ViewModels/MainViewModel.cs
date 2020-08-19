using CircleDock.Extensions;
using CircleDock.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace CircleDock.ViewModels
{
    class MainViewModel : ViewModel
    {
        private readonly Dock dock;

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
        public ICommand AddFolder { get; }
        public ICommand AddShortcut { get; }

        public MainViewModel()
        {
            Config.Initialize();

            dock = new Dock();

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
            Drop = new DelegateCommand<DragEventArgs>(e => dock.DropFiles(e.Data), e => e.Data.IsFile());
            AddFolder = new DelegateCommand<EventArgs>(_ => dock.AddFolder());
            AddShortcut = new DelegateCommand<EventArgs>(_ => dock.AddShortcut());
        }
    }
}
