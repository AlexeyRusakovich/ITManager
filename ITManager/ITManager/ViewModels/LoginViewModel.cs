using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
    public class LoginViewModel : BaseViewModel, INavigationAware
    {
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
        }

        private async void LoginApplicationMethod()
        {
            string errors = null;
            if(IsValid(ValidatesProperties, out errors))
            {
                using (var _database = new ITManagerEntities())
                { 
                    var user = await _database.Users.Where(u => u.Login == Login)
                        .Include(u => u.Position)
                        .Include(u => u.ProfessionalSummaries)
                        .Include(u => u.UserSkills)
                        .Include(u => u.UserProjects)
                        .Include(u => u.Educations)
                        .Include(u => u.Sertificates)
                        .Include(u => u.Languages)
                        .FirstOrDefaultAsync();

                    if (user == null)
                    {
                        Errors = "Invalid login.\r\n";
                        return;
                    }

                    var salt = user.Salt;
                    if (PasswordHasher.VerifyPassword(Password, Convert.FromBase64String(salt), Convert.FromBase64String(user.Password)))
                    {
                        ShellViewModel.CurrentUser = user;
                        _regionManager.RegisterViewWithRegion(Helpers.Constants.MenuRegion, typeof(MenuView));

                        if(!user.IsActive)
                        {
                            Errors = "Sorry, but your account has been deactivated.\r\n";
                            return;
                        }

                        if (user.IsInitial)
                        {
                            _navigationService.NavigateTo(Constants.ChangePasswordView);
                            return;
                        }

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
                            _navigationService.NavigateTo(Constants.MyPersonalPageView);
                        }

                        _eventAggregator.GetEvent<CloseMenuEvent>().Publish(false);
                    }
                    else
                        Errors = "Invalid password.\r\n";
                }
            }    
            else
            {
                Errors = errors;
            }

            Errors = Errors?.Trim();
        }

        #region Navigation

        private void GoToRegisterPageMethod()
        {
            _navigationService.NavigateTo(Constants.RegisterView);
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            var parameters = navigationContext.Parameters;
            if (parameters["IsLogout"] != null || parameters["IsFromChangingPassword"] != null)  
            {
                var view = _regionManager.Regions[Constants.MenuRegion].ActiveViews.FirstOrDefault();
                _regionManager.Regions[Constants.MenuRegion].Remove(view);
            }

            ShellViewModel.CurrentUser = null;
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            return;
        }

        #endregion

        #region Data validation

        public readonly string[] ValidatesProperties =
        {
            nameof(Login),
            nameof(Password)
        };

        public override string Validate(string propertyName)
        {
            if(!DoValidation)
                return null;

            switch (propertyName)
            {
                case nameof(Login):
                    if(Login.IsNullOrWhiteSpace())
                        return string.Format(Constants.FieldMustBeFilledMessageFormat, nameof(Login));
                    else if(!Login.IsLengthBetween(3, 20))
                        return string.Format(Constants.LengthErrorMessageFormat, nameof(Login), 3, 20);
                    break;
                case nameof(Password):
                    if(Password.IsNullOrWhiteSpace())
                        return string.Format(Constants.FieldMustBeFilledMessageFormat, nameof(Password));
                    else if(!Password.IsLengthBetween(5, 32))
                        return string.Format(Constants.LengthErrorMessageFormat, nameof(Password), 5, 32);
                    break;
            }
            return null;
        }

        #endregion

    }
}
