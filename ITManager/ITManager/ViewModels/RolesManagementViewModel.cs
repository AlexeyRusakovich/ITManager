﻿using ITManager.Database;
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
        private readonly EventAggregator _eventAggregator;

        public ICommand SaveUsers { get; set; }
        public ICommand GetUsers { get; set;}
        public RolesManagementViewModel(EventAggregator eventAggregator) : base("Roles Management")
        {
            GetUsersMethod();
            SaveUsers = new DelegateCommand(SaveUsersMethod);
            GetUsers = new DelegateCommand(GetUsersMethod);
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<UpdateUserEvent>().Subscribe(GetUsersMethod);
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

        private async void SaveUsersMethod()
        {
            using (var _database = new ITManagerEntities())
            {
                var users = await _database.Users.ToListAsync();
                foreach (var user in users)
                {
                    var _user = Users.Where(u => u.UserId == user.Id).FirstOrDefault();
                    if(_user == null)
                        continue;
                    user.UserRoles.FirstOrDefault().RoleId = _user.RoleId;
                }
                
                await _database.SaveChangesAsync();
                GetUsersMethod();
            }
        }
    }
}
