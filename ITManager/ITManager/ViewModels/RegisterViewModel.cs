using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
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
                    PositionId = Position.Id
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
        }

        private void GoToLoginPageMethod()
        {
            _navigationService.NavigateTo(Constants.LoginView);
        }
    }
}
