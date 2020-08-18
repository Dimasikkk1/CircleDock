using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CircleDock.Models
{
    abstract class Property : INotifyPropertyChanged
    {
        public Property() => Config.Properties[GetType()].CollectionChanged += (s, e) => NotifyView(e.NewItems[0].ToString());

        protected virtual object GetValue([CallerMemberName] string property = "") => Config.Properties[GetType()][property];
        protected virtual void SetValue(object value, [CallerMemberName] string property = "") => Config.Properties[GetType()][property] = value;
        protected virtual void NotifyView([CallerMemberName] string property = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
    }
}
