﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace ViewModel
{
    class Cell<T> : INotifyPropertyChanged
    {
        private T contents;

        public Cell(T initialContents = default(T))
        {
            this.contents = initialContents;
        }

        public T Value
        {
            get
            {
                return contents;
            }
            set
            {
                this.contents = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Value)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
