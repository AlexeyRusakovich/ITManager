using ITManager.Database;
using ITManager.Helpers;
using ITManager.Models;
using ITManager.ViewModels.Base;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ITManager.ViewModels
{
    public class RolesManagementViewModel : BaseViewModel
    {
        public ObservableCollection<UserRoleManagementModel> Users { get; set; } = new ObservableCollection<UserRoleManagementModel>();
        public ObservableCollection<Role> Roles { get; set; } = new ObservableCollection<Role>();

        private ITManagerEntities _database = new ITManagerEntities();

        public ICommand SaveUsers { get; set; }
        public ICommand GetUsers { get; set;}
        public RolesManagementViewModel() : base("Roles Management")
        {
            GetUsersMethod();
            SaveUsers = new DelegateCommand(SaveUsersMethod);
            GetUsers = new DelegateCommand(GetUsersMethod);
        }
        
        private async void GetUsersMethod()
        {
            Users.Clear();
            Users.AddRange(await _database.Users
            .Where(u => u.UserRoles.FirstOrDefault().RoleId != Constants.AdministratorRole)
            .Select(u => new UserRoleManagementModel {
                DefaultRoleId = u.UserRoles.FirstOrDefault().RoleId,
                Login = u.Login,
                UserId = u.Id,
                UserName = u.Name + " " + u.Surname,
                RoleId = u.UserRoles.FirstOrDefault().RoleId,
                HasChanges = false
                }).ToListAsync());
            Roles.Clear();
            Roles.AddRange(await _database.Roles.ToListAsync());
        }

        private void SaveUsersMethod()
        {
            Console.WriteLine("i'm in ass");
        }
    }
}
