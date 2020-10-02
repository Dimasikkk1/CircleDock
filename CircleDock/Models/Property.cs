﻿using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CircleDock.Models
{
    // TODO: Возможно нужно отказаться от этого и дочерних классов.
    abstract class Property : INotifyPropertyChanged
    {
        public Property() => Config.Properties[GetType()].CollectionChanged += (s, e) => NotifyPropertyChanged(e.NewItems[0].ToString());

        protected virtual T GetValue<T>([CallerMemberName] string property = "") => (T)Config.Properties[GetType()][property];
        protected virtual void SetValue(object value, [CallerMemberName] string property = "") => Config.Properties[GetType()][property] = value;

        #region INotifyPropertyChanged
        protected virtual void NotifyPropertyChanged([CallerMemberName] string property = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
    }
}
