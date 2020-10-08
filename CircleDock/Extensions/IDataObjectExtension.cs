using System.Linq;
using System.Windows;

namespace CircleDock.Extensions
{
    static class IDataObjectExtension
    {
        public static bool IsFile(this IDataObject data) =>
            data.GetFormats()
                .FirstOrDefault(s => s == DataFormats.FileDrop) != null;
    }
}
