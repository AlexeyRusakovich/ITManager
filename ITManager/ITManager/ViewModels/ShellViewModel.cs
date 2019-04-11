using ITManager.Interfaces;
using ITManager.ViewModels.Base;
using Prism.Events;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlzEx.Native;
using ITManager.Database;
using ITManager.Views;

namespace ITManager.ViewModels
{
    public class ShellViewModel : BaseViewModel
    {
        public static User CurrentUser { get; set; }
        private readonly IEventAggregator _eventAggregator;
        private readonly IRegionManager _regionManager;

        public ShellViewModel(IEventAggregator eventAggregator, IRegionManager regionManager, INavigationService navigationService) : base("Shell")
        {
            _eventAggregator = eventAggregator;
            _regionManager = regionManager;

            _regionManager.RegisterViewWithRegion(Helpers.Constants.MenuRegion, typeof(MenuView));
            _regionManager.RegisterViewWithRegion(Helpers.Constants.MainRegion, typeof(LoginView));
        }
    }
}
