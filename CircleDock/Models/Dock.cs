using System;
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

        public Dock() : base()
        {
            try
            {
                ConfigManager.Load();
            }
            catch (FileNotFoundException)
            {
                ConfigManager.Save();
            }

            Shortcuts = new ObservableCollection<Shortcut>();
            Shortcuts.CollectionChanged += (s, e) => GiveIndexes();

            //Hook.GlobalEvents().MouseClick += (s, e) =>
            //{
            //    if (e.Button != System.Windows.Forms.MouseButtons.Middle)
            //        return;

            //    Window.ChangeVisibility();

            //    if (!Window.Visibility)
            //        return;

            //    Config.Properties["Window.Left"] = e.X - Window.Width / 2;
            //    Config.Properties["Window.Top"] = e.Y - Window.Height / 2;
            //};
        }

        public void Rotate(int delta)
        {
            if (!(bool)Config.Properties[typeof(DockProperties)]["EnableRotation"])
                return;

            Config.Properties[typeof(DockProperties)]["Rotation"] = (double)Config.Properties[typeof(DockProperties)]["Rotation"] + delta * (double)Config.Properties[typeof(DockProperties)]["RotationStep"];
        }
        public void DropFiles(IDataObject data)
        {
            string[] files = (string[])data.GetData(DataFormats.FileDrop);

            for (int i = 0; i < files.Length; i++)
                if (Shortcuts.FirstOrDefault(p => p.Path == files[i]) == null)
                    Shortcuts.Add(new Shortcut(files[i]));
        }
        public void Execute(Shortcut shortcut)
        {
            if (shortcut.IsDirectory)
                Process.Start("explorer.exe", $"/n, {shortcut.Path}");
            else
                Process.Start(shortcut.Path);
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
