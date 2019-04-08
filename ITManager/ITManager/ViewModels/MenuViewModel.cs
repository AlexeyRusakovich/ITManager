using ITManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ITManager.ViewModels.Base;
using Prism.Commands;

namespace ITManager.ViewModels
{
    public class MenuViewModel : BaseViewModel
    {
        private readonly INavigationService _navigationService;
        public ICommand NavigateTo { get; set; }
        public MenuViewModel(INavigationService navigationService) : base("Menu")
        {
            _navigationService = navigationService;

            NavigateTo = new DelegateCommand<string>(NavigateToView);
        }     

        private void NavigateToView(string viewName)
        {
            _navigationService.NavigateTo(viewName);
        }
    }
}
