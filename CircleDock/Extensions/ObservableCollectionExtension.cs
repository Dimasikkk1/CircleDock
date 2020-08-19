using CircleDock.Models;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace CircleDock.Extensions
{
    static class ObservableCollectionExtension
    {
        public static void AddFiles(this ObservableCollection<Shortcut> collection, IDataObject data)
        {
            string[] files = (string[])data.GetData(DataFormats.FileDrop);

            for (int i = 0; i < files.Length; i++)
                if (collection.FirstOrDefault(p => p.Path == files[i]) == null)
                    collection.Add(new Shortcut(files[i]));
        }
    }
}
