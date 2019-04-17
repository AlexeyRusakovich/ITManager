﻿using ITManager.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITManager.Database;
using Prism.Regions;
using System.Data.Entity;
using System.Collections.ObjectModel;

namespace ITManager.ViewModels
{
    public class MyPersonalPageViewModel : BaseViewModel, INavigationAware
    {
        public User User { get; set; }
        private readonly ManagerEntities _database = new ManagerEntities();

        #region User properties

        public string UserName { get; set; }

        public Position Position { get; set; }

        public ProfessionalSummary ProfessionalSummary { get; set; }

        public ObservableCollection<UserSkill> Skills { get; set; }

        public ObservableCollection<Project> Projects { get; set; }

        public ObservableCollection<Education> Educations { get; set; }

        public ObservableCollection<Sertificate> Sertificates { get; set; }

        public ObservableCollection<Language> Languages { get; set; }

        #endregion

        public MyPersonalPageViewModel() : base("My page")
        {
        }

        public async void OnNavigatedTo(NavigationContext navigationContext)
        {
            var parameters = navigationContext.Parameters;
            if (parameters["UserId"] != null)
            {
                var user = await _database.Users.Where(u => u.Id == (int)parameters["UserId"]).FirstOrDefaultAsync();
                if (user != null)
                    User = user;
            }
            else
            {
                User = ShellViewModel.CurrentUser;
            }
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            return;
        }
    }
}
