using ITManager.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITManager.Database;
using Prism.Regions;
using System.Data.Entity;
using System.Collections.ObjectModel;
using AutoMapper;

namespace ITManager.ViewModels
{
    public class MyPersonalPageViewModel : BaseViewModel, INavigationAware
    {
        public User User { get; set; }
        private readonly ManagerEntities _database = new ManagerEntities();

        #region User properties

        public bool CanUserChangeData { get; set; }

        public string UserName { get; set; }

        public Models.UserPageModel.Position Position { get; set; }

        public Models.UserPageModel.ProfessionalSummary ProfessionalSummary { get; set; }

        public ObservableCollection<Models.UserPageModel.UserSkill> Skills { get; set; }

        public ObservableCollection<Models.UserPageModel.Project> Projects { get; set; }

        public ObservableCollection<Models.UserPageModel.Education> Educations { get; set; }

        public ObservableCollection<Models.UserPageModel.Sertificate> Sertificates { get; set; }

        public ObservableCollection<Models.UserPageModel.Language> Languages { get; set; }

        #endregion

        public MyPersonalPageViewModel() : base("My page")
        {
            Mapper.Initialize(cfg=>
            {
                cfg.CreateMap<Position, Models.UserPageModel.Position>();
                cfg.CreateMap<ProfessionalSummary, Models.UserPageModel.ProfessionalSummary>();
                cfg.CreateMap<UserSkill, Models.UserPageModel.UserSkill>();
                cfg.CreateMap<Project, Models.UserPageModel.Project>();
                cfg.CreateMap<Education, Models.UserPageModel.Education>();
                cfg.CreateMap<Sertificate, Models.UserPageModel.Sertificate>();
                cfg.CreateMap<Language, Models.UserPageModel.Language>();
            });
        }

        public async void OnNavigatedTo(NavigationContext navigationContext)
        {
            var parameters = navigationContext.Parameters;
            if (parameters["UserId"] != null)
            {
                var user = await _database.Users.Where(u => u.Id == (int)parameters["UserId"]).FirstOrDefaultAsync();
                if (user != null)
                {
                    User = user;
                    if (User.UserRoles.FirstOrDefault().RoleId == Helpers.Constants.ManagerRole)
                    {
                        CanUserChangeData = true;
                    }
                    else
                    {
                        CanUserChangeData = false;
                    }
                }
            }
            else
            {
                User = ShellViewModel.CurrentUser;
                CanUserChangeData = true;
            }

            MapUser(User);
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            return;
        }

        private void MapUser(User user)
        {
            UserName = $"{user.Name} {user.Surname}";
            Position = Mapper.Map<Position, Models.UserPageModel.Position>(user.Position);
            ProfessionalSummary = Mapper.Map<ProfessionalSummary, Models.UserPageModel.ProfessionalSummary>(user.ProfessionalSummaries.FirstOrDefault() ?? new ProfessionalSummary() { UserId = user.Id});
            Skills = Mapper.Map<ICollection<UserSkill>, ObservableCollection<Models.UserPageModel.UserSkill>>(user.UserSkills);
            Projects = Mapper.Map<ICollection<Project>, ObservableCollection<Models.UserPageModel.Project>>(user.Projects);
            Educations = Mapper.Map<ICollection<Education>, ObservableCollection<Models.UserPageModel.Education>>(user.Educations);
            Sertificates = Mapper.Map<ICollection<Sertificate>, ObservableCollection<Models.UserPageModel.Sertificate>>(user.Sertificates);
            Languages = Mapper.Map<ICollection<Language>, ObservableCollection<Models.UserPageModel.Language>>(user.Languages);
        }
    }
}
