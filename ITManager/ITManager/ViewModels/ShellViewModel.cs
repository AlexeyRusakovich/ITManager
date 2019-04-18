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
using ITManager.Events;
using System.Windows;

namespace ITManager.ViewModels
{
    public class ShellViewModel : BaseViewModel
    {
        private static User currentUser { get; set; }

        public static User CurrentUser
        {
            get
            {
                return currentUser;
            }
            set
            {
                currentUser = value;
                CurrentUserId = currentUser.Id;
            }
        }

        public static int CurrentUserId { get; set; }
        public Visibility MenuVisibility { get; set;} 
        private readonly IEventAggregator _eventAggregator;
        private readonly IRegionManager _regionManager;

        public ShellViewModel(IEventAggregator eventAggregator, IRegionManager regionManager, INavigationService navigationService) : base("Shell")
        {
            _eventAggregator = eventAggregator;
            _regionManager = regionManager;

            _regionManager.RegisterViewWithRegion(Helpers.Constants.MainRegion, typeof(LoginView));
            _eventAggregator.GetEvent<CloseMenuEvent>().Subscribe(MenuStateChanged);
        }

        private void MenuStateChanged(bool value)
        {
            MenuVisibility = value ? Visibility.Collapsed : Visibility.Visible;
            RaisePropertyChanged(nameof(MenuVisibility));            
        }
    }
}
