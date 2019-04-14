using ITManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ITManager.ViewModels.Base;
using Prism.Commands;
using ITManager.Helpers;
using Prism.Events;
using ITManager.Events;

namespace ITManager.ViewModels
{
    public class MenuViewModel : BaseViewModel
    {
        private readonly INavigationService _navigationService;
        private readonly IEventAggregator _eventAggregator;
        public ICommand NavigateTo { get; set; }
        public MenuViewModel(INavigationService navigationService, IEventAggregator eventAggregator) : base("Menu")
        {
            _navigationService = navigationService;
            _eventAggregator = eventAggregator;

            NavigateTo = new DelegateCommand<string>(NavigateToView);
        }     

        private void NavigateToView(string viewName)
        {
            if(viewName == Constants.LoginView)
                _eventAggregator.GetEvent<CloseMenuEvent>().Publish(true);
            _navigationService.NavigateTo(viewName);
        }
    }
}
