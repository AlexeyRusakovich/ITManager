using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ITManager.Database;
using ITManager.Events;
using ITManager.Helpers;
using ITManager.Interfaces;
using ITManager.ViewModels.Base;
using ITManager.Views;
using Prism.Commands;
using Prism.Events;
using Prism.Regions;

namespace ITManager.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private ManagerEntities _database = new ManagerEntities();
        private readonly INavigationService _navigationService;
        private readonly IEventAggregator _eventAggregator;
        private readonly IRegionManager _regionManager;

        public string Login { get; set; }
        public string Password { get; set; }

        public ICommand LoginCommand { get; set; }
        public ICommand GoToRegisterPageCommand { get; set; }

        public LoginViewModel(INavigationService navigationService, IRegionManager regionManager, IEventAggregator eventAggregator) : base("Log In")
        {
            LoginCommand = new DelegateCommand(LoginApplicationMethod);
            GoToRegisterPageCommand = new DelegateCommand(GoToRegisterPageMethod);
            _navigationService = navigationService;
            _eventAggregator = eventAggregator;
            _regionManager = regionManager;
            _eventAggregator.GetEvent<CloseMenuEvent>().Publish(true);
            ShellViewModel.CurrentUser = null;
        }

        private async void LoginApplicationMethod()
        {
            var user = await _database.Users.Where(u => u.Login == Login).FirstOrDefaultAsync();
            if (user == null)
                return; // TODO return validation error;

            var salt = user.Salt;
            if (PasswordHasher.VerifyPassword(Password, Convert.FromBase64String(salt),
                Convert.FromBase64String(user.Password)))
            {
                ShellViewModel.CurrentUser = user;

                if (user.UserRoles.Any(r => r.RoleId == Constants.AdministratorRole))
                {
                    _navigationService.NavigateTo(Constants.RolesManagementView);
                }
                else if (user.UserRoles.Any(r => r.RoleId == Constants.ManagerRole))
                {
                    _navigationService.NavigateTo(Constants.SearchView);
                }
                else if(user.UserRoles.Any(r => r.RoleId == Constants.UserRole))
                {
                    _navigationService.NavigateTo(Constants.MyPageView);
                }

                _regionManager.RegisterViewWithRegion(Helpers.Constants.MenuRegion, typeof(MenuView));
                _eventAggregator.GetEvent<CloseMenuEvent>().Publish(false);
            }
        }

        private void GoToRegisterPageMethod()
        {
            _navigationService.NavigateTo(Constants.RegisterView);
        }
    }
}
