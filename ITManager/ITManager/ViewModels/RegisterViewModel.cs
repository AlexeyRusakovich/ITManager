﻿using System;
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
    public class RegisterViewModel : BaseViewModel
    {
        public string Login { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? Birthday { get; set; }
        public string Position { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public ICommand RegisterCommand { get; set; }
        public ICommand GoToLoginPageCommand { get; set; }

        private ManagerEntities _database = new ManagerEntities();
        private readonly INavigationService _navigationService;

        public RegisterViewModel(INavigationService navigationService) : base("Registration")
        {
            _navigationService = navigationService;
            RegisterCommand = new DelegateCommand(RegisterMethod);
            GoToLoginPageCommand = new DelegateCommand(GoToLoginPageMethod);
        }

        private async void RegisterMethod()
        {
            // validate
            var salt = PasswordHasher.GenerateSalt();
            var hashedPassword = PasswordHasher.ComputeHash(Password, salt);
            if (!_database.User.Any(u => u.Login == Login))
            {
                var user = _database.User.Add(new User
                {
                    Login = Login,
                    Password = Encoding.ASCII.GetString(hashedPassword),
                    Salt = Encoding.ASCII.GetString(salt)
                });

                await _database.SaveChangesAsync();

                user.UserRoles.Add(new UserRoles
                {
                    RoleId = Constants.UserRole,
                    UserId = user.Id
                });
                
                await _database.SaveChangesAsync();
            }
        }

        private void GoToLoginPageMethod()
        {
            _navigationService.NavigateTo(Constants.LoginView);
        }
    }
}
