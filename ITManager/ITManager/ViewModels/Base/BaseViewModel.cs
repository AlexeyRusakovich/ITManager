using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ITManager.ViewModels.Base
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public string Title { get; private set; }
        public bool IsBusy { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public BaseViewModel(string _title)
        {
            Title = _title;
        }

        protected void Set<T>(ref T target, T value, [CallerMemberName] string propertyName = "")
        {
            target = value;
            RaisePropertyChanged(propertyName);
        }
        protected void RaisePropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
