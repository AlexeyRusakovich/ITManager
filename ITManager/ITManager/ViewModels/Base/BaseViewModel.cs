using Prism.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ITManager.ViewModels.Base
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public bool DoValidation { get; set; } = false;
        public string Title { get; private set; }
        public bool IsBusy { get; set; }

        public ICommand LoadedCommand { get; set;}

        public event PropertyChangedEventHandler PropertyChanged;

        public BaseViewModel(string _title)
        {
            Title = _title;
            LoadedCommand = new DelegateCommand(LoadedMethod);
        }

        private void LoadedMethod()
        {
            DoValidation = true;
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
