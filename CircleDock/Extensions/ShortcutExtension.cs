using CircleDock.Models;
using System.Diagnostics;

namespace CircleDock.Extensions
{
    static class ShortcutExtension
    {
        public static bool IsDirectory(this Shortcut shortcut) => shortcut.Path.IsDirectory();
        public static void Execute(this Shortcut shortcut)
        {
            if (shortcut.IsDirectory())
                Process.Start("explorer.exe", $"/n, {shortcut.Path}");
            else
                Process.Start(shortcut.Path);
        }
    }
}
