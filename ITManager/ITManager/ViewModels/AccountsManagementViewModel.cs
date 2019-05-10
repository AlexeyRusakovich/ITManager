using ITManager.Database;
using ITManager.Events;
using ITManager.Helpers;
using ITManager.Models;
using ITManager.ViewModels.Base;
using Prism.Commands;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ITManager.ViewModels
{
    public class AccountsManagementViewModel : BaseViewModel
    {
        public string Login { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Birthday { get; set; }
        public Position Position { get; set; }
        public IList<Position> Positions { get; set; }
        public ICommand RegisterCommand { get; set; }
        public ICommand ResetPassword  { get; set; }
        public ICommand CopyToClipboard { get; set; }
        public ICommand BlockUser { get; set;}
        public ICommand UnblockUser { get; set;}

        public Role Role { get; set;}

        public ObservableCollection<UserAccountManagementModel> Users { get; set; } = new ObservableCollection<UserAccountManagementModel>();
        public ObservableCollection<Role> Roles { get; set; } = new ObservableCollection<Role>();
        private readonly ITManagerEntities _database = new ITManagerEntities();
        private readonly EventAggregator _eventAggregator;

        public AccountsManagementViewModel(EventAggregator eventAggregator) : base("Accounts Management")
        {
            Init();
            RegisterCommand = new DelegateCommand(RegisterMethod);
            ResetPassword = new DelegateCommand<UserAccountManagementModel>(ResetPasswordMethod);
            CopyToClipboard = new DelegateCommand<UserAccountManagementModel>(CopyToClipboardMethod);
            BlockUser = new DelegateCommand<UserAccountManagementModel>(BlockUserMethod);
            UnblockUser = new DelegateCommand<UserAccountManagementModel>(UnblockUserMethod);
            _eventAggregator = eventAggregator;
        }

        private async void BlockUserMethod(UserAccountManagementModel user)
        {
            using (var _database = new ITManagerEntities())
            {
                var _user = await _database.Users.Where(u => u.Id == user.UserId).FirstOrDefaultAsync();
                if(_user == null)
                    return;
                user.IsActive = false;
                _user.IsActive = false;
                await _database.SaveChangesAsync();
            }
        }

        private async void UnblockUserMethod(UserAccountManagementModel user)
        {
            using (var _database = new ITManagerEntities())
            {
                var _user = await _database.Users.Where(u => u.Id == user.UserId).FirstOrDefaultAsync();
                if(_user == null)
                    return;
                user.IsActive = true;
                _user.IsActive = true;
                await _database.SaveChangesAsync();
            }
        }

        private void CopyToClipboardMethod(UserAccountManagementModel user)
        {
            Clipboard.SetText($"Login: {user.Login}\r\nPassword: {user.DefaultPassword}");
        }

        public async void Init()
        {
            Roles.Clear();
            Roles.AddRange(await _database.Roles.ToListAsync());
            await GetUsersMethod();
            Positions = await _database.Positions.ToListAsync();
        }

        private async Task GetUsersMethod()
        {
            Users.Clear();
            Users.AddRange(await _database.Users
            .Where(u => u.UserRoles.FirstOrDefault().RoleId != Constants.AdministratorRole)
            .Select(u => new UserAccountManagementModel {
                Login = u.Login,
                UserId = u.Id,
                UserName = u.Name + " " + u.Surname,
                DefaultPassword = u.DefaultPassword,
                IsInitial = u.IsInitial,
                IsActive = u.IsActive
            }).ToListAsync());
        }

        private async void RegisterMethod()
        {
            string errors = null;
            if(IsValid(ValidatesProperties, out errors))
            {
                Errors = errors;
                var salt = PasswordHasher.GenerateSalt();
                var password = RandomStringGenerator.GenerateRandomString(20, false);
                var hashedPassword = PasswordHasher.ComputeHash(password, salt);
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
                        IsInitial = true,
                        DefaultPassword = password,
                        IsActive = true
                    });

                    await _database.SaveChangesAsync();

                    user.UserRoles.Add(new UserRole
                    {
                        RoleId = Role.Id,
                        UserId = user.Id
                    });
                
                    await _database.SaveChangesAsync();
                }
                else
                {
                    Errors = "User with same login is already exists.\r\n";
                }

                await GetUsersMethod();
                _eventAggregator.GetEvent<UpdateUserEvent>().Publish();
            }
            else
            {
                Errors = errors;
            }

            Errors = Errors?.Trim();
        }

        private async void ResetPasswordMethod(UserAccountManagementModel user)
        {
            var _user = await _database.Users.Where(u => u.Id == user.UserId).FirstOrDefaultAsync();
            if(_user != null)
            {
                var salt = Convert.FromBase64String(_user.Salt);
                var password = RandomStringGenerator.GenerateRandomString(20, false);
                var hashedPassword = PasswordHasher.ComputeHash(password, salt);
                _user.DefaultPassword = password;
                _user.Password = Convert.ToBase64String(hashedPassword);
                _user.Salt = Convert.ToBase64String(salt);
                _user.IsInitial = true;
                await _database.SaveChangesAsync();
                user.DefaultPassword = password;
                user.IsInitial = true;
            } 
        }

        #region Data validation

        public readonly string[] ValidatesProperties =
        {
            nameof(Login),
            nameof(FirstName),
            nameof(LastName),
            nameof(Birthday),
            nameof(Position),
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
                    else if(DateTime.Parse(Birthday) < new DateTime(1900, 1, 1) || DateTime.Parse(Birthday) > new DateTime(2005, 1, 1))
                        return Constants.DateMustBeCorrectMessage;
                    break;
            }
            return null;
        }
        
        #endregion
    }
}
