using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CircleDock.Models
{
    public class Shortcut : INotifyPropertyChanged
    {
        private string path;
        private string label;

        public int Index { get; set; }
        public string Path
        {
            get => path;
            private set
            {
                if (value == path)
                    return;

                path = value;

                OnPropertyChanged();
            }
        }
        public string Label
        {
            get => label;
            private set
            {
                if (value == label)
                    return;

                label = value;

                OnPropertyChanged();
            }
        }

        public Shortcut(string path)
        {
            Path = path;
            Label = System.IO.Path.GetFileNameWithoutExtension(Path);
        }

        #region INotifyPropertyChanged
        public void OnPropertyChanged([CallerMemberName] string prop = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
    }
}
