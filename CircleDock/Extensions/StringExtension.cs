using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace CircleDock.Extensions
{
    public static class StringExtension
    {
        public static string ToRelative(this string path) => Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), path);
        public static bool IsDirectory(this string path) => File.GetAttributes(path).HasFlag(FileAttributes.Directory);
        // Выглядит забавно
        public static ImageSource GetIcon(this string path)
        {
            Icon icon = Icon.ExtractAssociatedIcon(path);
            Int32Rect rect = new Int32Rect(0, 0, icon.Width, icon.Height);

            return Imaging.CreateBitmapSourceFromHIcon(icon.Handle, rect, BitmapSizeOptions.FromEmptyOptions());
        }
    }
}
