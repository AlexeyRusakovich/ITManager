using Prism.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ITManager.ViewModels.Base
{
    public class BaseViewModel : INotifyPropertyChanged, IDataErrorInfo
    {
        public Visibility ErrorsVisibility => string.IsNullOrWhiteSpace(Errors) ? Visibility.Collapsed : Visibility.Visible;
        public string Errors { get; set; }
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

        #region Data validation

        public virtual string Validate(string propertyName)
        {
            return null;
        }

        protected bool IsValid(string[] validatingStrings, out string Error)
        {
            Error = null;

            foreach (var str in validatingStrings)
            {
                var error = Validate(str);
                if (!string.IsNullOrWhiteSpace(error))
                    Error += $"{error}\r\n";
            }

            return Error is null;
        }

        string IDataErrorInfo.Error
        {
            get
            {
                return null;
            }
        }


        public string this[string columnName]
        {
            get
            {
                string error = null;
                return error = Validate(columnName);
            }
        }

        #endregion
    }
}
