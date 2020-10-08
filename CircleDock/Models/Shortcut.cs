using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CircleDock.Models
{
    public class Shortcut : INotifyPropertyChanged
    {
        private int index;
        private string path;
        private string label;

        public int Index
        {
            get => index;
            set
            {
                if (value == index)
                    return;

                index = value;

                OnNotifyPropertyChanged();
            }
        }
        public string Path
        {
            get => path;
            private set
            {
                if (value == path)
                    return;

                path = value;

                OnNotifyPropertyChanged();
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

                OnNotifyPropertyChanged();
            }
        }

        public Shortcut(string path)
        {
            Path = path;
            Label = System.IO.Path.GetFileNameWithoutExtension(Path);
        }

        #region INotifyPropertyChanged
        public void OnNotifyPropertyChanged([CallerMemberName] string prop = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
    }
}
