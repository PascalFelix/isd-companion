﻿using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ISDCompanion
{
    public abstract class ViewModel : INotifyPropertyChanged
    {
        public ViewModel()
        {
        }

        #region INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "") =>
          PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        #endregion

    }
}

