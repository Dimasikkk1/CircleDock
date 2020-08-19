using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows;

namespace CircleDock.Models
{
    class Dock
    {
        public ObservableCollection<Shortcut> Shortcuts { get; private set; }

        public Dock()
        {
            Shortcuts = new ObservableCollection<Shortcut>();
            Shortcuts.CollectionChanged += (s, e) => GiveIndexes();

#if !DEBUG
            Hook.GlobalEvents().MouseClick += (s, e) =>
            {
                if (e.Button != System.Windows.Forms.MouseButtons.Middle)
                    return;

                Window.ChangeVisibility();

                if (!Window.Visibility)
                    return;

                Config.Properties["Window.Left"] = e.X - Window.Width / 2;
                Config.Properties["Window.Top"] = e.Y - Window.Height / 2;
            };
#endif
        }

        public void AddFolder()
        {
            throw new InvalidOperationException();
        }
        public void AddShortcut()
        {
            throw new InvalidOperationException();
        }
        private void GiveIndexes()
        {
            for (int i = 0; i < Shortcuts.Count; i++)
                Shortcuts[i].Index = i;
        }
    }
}
