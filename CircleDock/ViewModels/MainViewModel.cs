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
    class MainViewModel : BaseViewModel
    {
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
                Shortcuts.GiveIndexes();
            }
            catch (Exception)
            {
                Shortcuts = new ObservableCollection<Shortcut>();
            }

            Shortcuts.CollectionChanged += (s, _) => XmlReader.SaveShortcuts((IEnumerable<Shortcut>)s);

            ChangeVisibility = new DelegateCommand<EventArgs>(_ => Visibility = !Visibility);
            MouseWheel = new DelegateCommand<MouseWheelEventArgs>(e => RotateShortcuts(-e.Delta / 120));
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

        private void RotateShortcuts(int delta)
        {
            if (!config.GetSetting<bool>("EnableRotation"))
                return;

            Rotation += RotationStep * delta;
        }
    }
}
