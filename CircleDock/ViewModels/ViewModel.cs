﻿using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CircleDock.ViewModels
{
    abstract class ViewModel : INotifyPropertyChanged
    {
        protected virtual void NotifyView([CallerMemberName] string property = "") => PropertyChanged?.Invoke(null, new PropertyChangedEventArgs(property));

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
    }
}
