using ITManager.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ITManager.Interfaces;
using Prism.Commands;
using ITManager.Database;
using ITManager.Helpers;
using ITManager.Events;
using Prism.Events;
using Prism.Regions;

namespace ITManager.ViewModels
{
    public class ChangePasswordViewModel : BaseViewModel
    {
        private readonly INavigationService _navigationService;
        private readonly IEventAggregator _eventAggregator;

        public string NewPassword { get; set; }

        public string ConfirmNewPassword { get; set; }

        public ICommand ChangePassword { get; set; }

        public ICommand GoToLoginView { get; set; }

        public ChangePasswordViewModel(INavigationService navigationService, IEventAggregator eventAggregator) : base(
            "Change Password")
        {
            ChangePassword = new DelegateCommand(ChangePasswordMethod);
            GoToLoginView = new DelegateCommand(GoToLoginViewMethod);
            _navigationService = navigationService;
            _eventAggregator = eventAggregator;
        }

        private async void ChangePasswordMethod()
        {
            if (IsValid(ValidatesProperties, out var errors))
            {
                if (NewPassword == ConfirmNewPassword)
                {
                    Errors = string.Empty;
                    using (var _database = new ITManagerEntities())
                    {
                        var user = ShellViewModel.CurrentUser;
                        if (user != null)
                        {
                            var _user = _database.Users.Where(u => u.Id == user.Id).FirstOrDefault();
                            if (_user != null)
                            {
                                var salt = Convert.FromBase64String(user.Salt);
                                _user.Salt = Convert.ToBase64String(salt);
                                _user.IsInitial = false;
                                _user.Password = Convert.ToBase64String(PasswordHasher.ComputeHash(NewPassword, salt));
                                _user.DefaultPassword = null;
                                await _database.SaveChangesAsync();

                                if (user.UserRoles.Any(r => r.RoleId == Constants.AdministratorRole))
                                {
                                    _navigationService.NavigateTo(Constants.RolesManagementView);
                                }
                                else if (user.UserRoles.Any(r => r.RoleId == Constants.ManagerRole))
                                {
                                    _navigationService.NavigateTo(Constants.SearchView);
                                }
                                else if (user.UserRoles.Any(r => r.RoleId == Constants.UserRole))
                                {
                                    _navigationService.NavigateTo(Constants.MyPersonalPageView);
                                }

                                _eventAggregator.GetEvent<CloseMenuEvent>().Publish(false);
                            }
                        }
                    }
                }
                else
                {
                    Errors = "Passwords must match.";
                }
            }
            else
            {
                Errors = errors;
            }

            Errors = Errors.Trim();
        }

        private void GoToLoginViewMethod()
        {
            var parameters = new NavigationParameters();
            parameters.Add("IsFromChangingPassword", true);
            _navigationService.NavigateToWithParameters(Constants.LoginView, navigationParameters: parameters);
        }

        #region Data validation

        public readonly string[] ValidatesProperties =
        {
            nameof(NewPassword),
            nameof(ConfirmNewPassword)
        };

        public override string Validate(string propertyName)
        {
            if (!DoValidation)
                return null;

            switch (propertyName)
            {
                case nameof(NewPassword):
                    if (NewPassword.IsNullOrWhiteSpace())
                        return string.Format(Constants.FieldMustBeFilledMessageFormat, nameof(NewPassword));
                    else if (!NewPassword.IsLengthBetween(5, 32))
                        return string.Format(Constants.LengthErrorMessageFormat, nameof(NewPassword), 5, 32);
                    break;

                case nameof(ConfirmNewPassword):
                    if (ConfirmNewPassword.IsNullOrWhiteSpace())
                        return string.Format(Constants.FieldMustBeFilledMessageFormat, nameof(ConfirmNewPassword));
                    else if (!ConfirmNewPassword.IsLengthBetween(5, 32))
                        return string.Format(Constants.LengthErrorMessageFormat, nameof(ConfirmNewPassword), 5, 32);
                    break;
            }

            return null;
        }

        #endregion
    }
}