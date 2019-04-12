using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ITManager.Database;
using ITManager.Helpers;
using ITManager.Interfaces;
using ITManager.ViewModels.Base;
using Prism.Commands;

namespace ITManager.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private ManagerEntities _database = new ManagerEntities();
        private readonly INavigationService _navigationService;

        public string Login { get; set; }
        public string Password { get; set; }

        public ICommand LoginCommand { get; set; }
        public ICommand GoToRegisterPageCommand { get; set; }

        public LoginViewModel(INavigationService navigationService) : base("Log In")
        {
            LoginCommand = new DelegateCommand(LoginApplicationMethod);
            GoToRegisterPageCommand = new DelegateCommand(GoToRegisterPageMethod);
            _navigationService = navigationService;
        }

        private void LoginApplicationMethod()
        {
            var user = _database.User.Where(u => u.Login == Login).FirstOrDefault();
            if (user == null)
                return; // TODO return validation error;

            var salt = user.Salt;
            if (PasswordHasher.VerifyPassword(Password, Convert.FromBase64String(salt),
                Convert.FromBase64String(user.Password)))
            {
                ShellViewModel.CurrentUser = user;

                if (user.UserRoles.Any(r => r.Id == Constants.AdministratorRole))
                {
                    _navigationService.NavigateTo(Constants.RightsManagementView);
                }
                else if (user.UserRoles.Any(r => r.Id == Constants.ManagerRole))
                {
                    _navigationService.NavigateTo(Constants.SearchView);
                }
                else if(user.UserRoles.Any(r => r.Id == Constants.UserRole))
                {
                    _navigationService.NavigateTo(Constants.MyPageView);
                }
            }
        }

        private void GoToRegisterPageMethod()
        {
            _navigationService.NavigateTo(Constants.RegisterView);
        }
    }
}
