using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using ITManager.Database;
using ITManager.Helpers;
using ITManager.Interfaces;
using ITManager.ViewModels.Base;
using Prism.Commands;

namespace ITManager.ViewModels
{
    public class RegisterViewModel : BaseViewModel, IDataErrorInfo
    {
        public string Login { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Birthday { get; set; }
        public Position Position { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public ICommand RegisterCommand { get; set; }
        public ICommand GoToLoginPageCommand { get; set; }

        public ObservableCollection<Position> Positions { get; set; } = new ObservableCollection<Position>();
        

        private ITManagerEntities _database = new ITManagerEntities();
        private readonly INavigationService _navigationService;

        public RegisterViewModel(INavigationService navigationService) : base("Registration")
        {
            _navigationService = navigationService;
            RegisterCommand = new DelegateCommand(RegisterMethod);
            GoToLoginPageCommand = new DelegateCommand(GoToLoginPageMethod);
            Init();
        }

        private async void Init()
        {
            Positions.AddRange(await _database.Positions.ToListAsync());
        }

        private async void RegisterMethod()
        {
            // validate
            var salt = PasswordHasher.GenerateSalt();
            var hashedPassword = PasswordHasher.ComputeHash(Password, salt);

            if(Password != ConfirmPassword)
                MessageBox.Show("Password and Confirm password fields must match!", "Error");

            if (!_database.Users.Any(u => u.Login == Login))
            {
                var user = _database.Users.Add(new User
                {
                    Login = Login,
                    Password = Convert.ToBase64String(hashedPassword),
                    Salt = Convert.ToBase64String(salt),
                    Name = FirstName,
                    Surname = LastName,
                    Birthday = DateTime.Parse(Birthday),
                    PositionId = Position.Id,
                    IsActive = true
                });

                await _database.SaveChangesAsync();

                user.UserRoles.Add(new UserRole
                {
                    RoleId = Constants.UserRole,
                    UserId = user.Id
                });
                
                await _database.SaveChangesAsync();
                GoToLoginPageMethod();
            }
            else
                MessageBox.Show("User with same login is already exists!", "Register error");
        }

        private void GoToLoginPageMethod()
        {
            _navigationService.NavigateTo(Constants.LoginView);
        }

        #region Data validation
        

        private string Validate(string propertyName)
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
                    else if(!Password.IsLengthBetween(8, 32))
                        return string.Format(Constants.LengthErrorMessageFormat, nameof(Password), 8, 32);
                    break;

                case nameof(ConfirmPassword):
                    if(ConfirmPassword.IsNullOrWhiteSpace())
                        return string.Format(Constants.FieldMustBeFilledMessageFormat, nameof(ConfirmPassword));
                    else if(!ConfirmPassword.IsLengthBetween(8, 32))
                        return string.Format(Constants.LengthErrorMessageFormat, nameof(ConfirmPassword), 8, 32);
                    break;

                case nameof(FirstName):
                    if(FirstName.IsNullOrWhiteSpace())
                        return string.Format(Constants.FieldMustBeFilledMessageFormat, nameof(FirstName));
                    else if(!FirstName.IsLengthBetween(3, 20))
                        return string.Format(Constants.LengthErrorMessageFormat, nameof(FirstName), 3, 20);
                    break;

                case nameof(LastName):
                    if(LastName.IsNullOrWhiteSpace())
                        return string.Format(Constants.FieldMustBeFilledMessageFormat, nameof(LastName));
                    else if(!LastName.IsLengthBetween(3, 20))
                        return string.Format(Constants.LengthErrorMessageFormat, nameof(LastName), 3, 20);
                    break;

                case nameof(Position):
                    if(Position == null)
                        return string.Format(Constants.FieldMustBeFilledMessageFormat, nameof(Position));
                    break;

                case nameof(Birthday):
                    if(Birthday.IsNullOrWhiteSpace())
                        return string.Format(Constants.FieldMustBeFilledMessageFormat, nameof(Birthday));
                    else if(DateTime.Parse(Birthday) < new DateTime(1900, 1, 1) && DateTime.Parse(Birthday) > new DateTime(2005, 1, 1))
                        return Constants.DateMustBeCorrectMessage;
                    break;
            }
            return null;
        }

        private bool IsValid(string[] validatingStrings, out string Error)
        {
            Error = null;
            foreach (var str in validatingStrings)
                Error += Validate(str);
            return Error.Equals("");
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
