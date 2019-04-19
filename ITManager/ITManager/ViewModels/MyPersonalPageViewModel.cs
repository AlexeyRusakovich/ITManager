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
using System.Windows.Input;
using AutoMapper;
using Prism.Commands;

namespace ITManager.ViewModels
{
    public class MyPersonalPageViewModel : BaseViewModel, INavigationAware
    {
        public User User { get; set; }

        #region Commands

        public ICommand SaveProfessionalSummary { get; set; }
        public ICommand ResetProfessionalSummary { get; set; }

        public ICommand SaveSkills { get; set; }
        public ICommand ResetSkills { get; set; }
        public ICommand AddSkill { get; set; }
        public ICommand RemoveSkill { get; set; }

        public ICommand SaveProjects { get; set; }
        public ICommand ResetProjects { get; set; }
        public ICommand AddProject { get; set; }
        public ICommand RemoveProject{ get; set; }
        
        public ICommand SaveEducations { get; set; }
        public ICommand ResetEducations { get; set; }
        public ICommand AddEducation { get; set; }
        public ICommand RemoveEducation { get; set; }

        public ICommand SaveSertificates { get; set; }
        public ICommand ResetSertificates { get; set; }
        public ICommand AddSertificate { get; set; }
        public ICommand RemoveSertificate { get; set; }

        public ICommand SaveLanguages { get; set; }
        public ICommand ResetLanguages { get; set; }
        public ICommand AddLanguage { get; set; }
        public ICommand RemoveLanguage { get; set; }

        #endregion

        #region Constants collections

        public IList<LanguageLevel> LanguageLevels { get; set; }
        public IList<SkillLevel> SkillLevels { get; set; }
        public IList<Position> Positions { get; set; }

        #endregion

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

            ResetEducations = new DelegateCommand(MapEducations);

            ResetLanguages = new DelegateCommand(MapLanguages);
            SaveLanguages = new DelegateCommand(SaveLanguagesMethod);
            AddLanguage = new DelegateCommand(AddLanguageMethod);
            RemoveLanguage = new DelegateCommand<Models.UserPageModel.Language>(RemoveLanguageMethod);

            ResetProfessionalSummary = new DelegateCommand(MapProfessionalSummary);
            ResetProjects = new DelegateCommand(MapProjects);
            ResetSertificates = new DelegateCommand(MapSertificates);
            ResetSkills = new DelegateCommand(MapSkills);
        }

        #region User saving

        private async void SaveLanguagesMethod()
        {
            using (var _database = new ManagerEntities())
            {
                var userLanguages = (await _database.Users.Where(u => u.Id == User.Id)
                    .Include(u => u.Languages)
                    .FirstOrDefaultAsync()).Languages;

                // Removing and changing languages
                foreach (var userLanguage in userLanguages)
                {
                    var _userLanguage = Languages.FirstOrDefault(l => l.Id == userLanguage.Id);
                    // If exists in local collection, change data
                    if (_userLanguage != null)
                    {
                        _userLanguage.Name = userLanguage.Name;
                        _userLanguage.LanguageLevelId = userLanguage.LanguageLevelId;
                    }
                    // If not exists in local collection - remove.
                    else
                    {
                        userLanguages.Remove(userLanguage);
                    }
                }

                // Adding new languages
                foreach (var newLanguage in Languages.Where(l => l.Id == 0))
                {
                    userLanguages.Add(new Language
                    {
                        Name = newLanguage.Name,
                        LanguageLevelId = newLanguage.LanguageLevelId
                    });
                }
            }
        }
        private void AddLanguageMethod()
        {
            Languages.Add(new Models.UserPageModel.Language
            {
                Id = 0,
                LanguageLevelId = 0,
                Name = null,
                UserId =  User.Id
            });
        }
        private void RemoveLanguageMethod(Models.UserPageModel.Language language)
        {
            Languages.Remove(language);
        }

        #endregion

        #region Navigation management

        public async void OnNavigatedTo(NavigationContext navigationContext)
        {
            using (var _database = new ManagerEntities())
            {
                LanguageLevels = await _database.LanguageLevels.ToListAsync();
                SkillLevels = await _database.SkillLevels.ToListAsync();
                Positions = await _database.Positions.ToListAsync();

                var parameters = navigationContext.Parameters;
                if (parameters["UserId"] != null)
                {
                    var user = await _database.Users.Where(u => u.Id == (int)parameters["UserId"])
                        .Include(u => u.Position)
                        .Include(u => u.ProfessionalSummaries)
                        .Include(u => u.UserSkills)
                        .Include(u => u.Projects)
                        .Include(u => u.Educations)
                        .Include(u => u.Sertificates)
                        .Include(u => u.Languages)
                        .FirstOrDefaultAsync();
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

                MapUser();
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

        #endregion

        #region User mapping

        private void MapUser()
        {
            MapUserName();
            MapPosition();
            MapProfessionalSummary();
            MapSkills();
            MapProjects();
            MapEducations();
            MapSertificates();
            MapLanguages();
        }
        private void MapUserName()
        {
            UserName = $"{User.Name} {User.Surname}";
        }
        private void MapPosition()
        {
            Position = Mapper.Map<Position, Models.UserPageModel.Position>(User.Position);
        }
        private void MapProfessionalSummary()
        {
            ProfessionalSummary = Mapper.Map<ProfessionalSummary, Models.UserPageModel.ProfessionalSummary>(User.ProfessionalSummaries.FirstOrDefault() ?? new ProfessionalSummary() { UserId = User.Id});
        }
        private void MapSkills()
        {
            Skills = Mapper.Map<ICollection<UserSkill>, ObservableCollection<Models.UserPageModel.UserSkill>>(User.UserSkills);
        }
        private void MapProjects()
        {
            Projects = Mapper.Map<ICollection<Project>, ObservableCollection<Models.UserPageModel.Project>>(User.Projects);
        }
        private void MapEducations()
        {
            Educations = Mapper.Map<ICollection<Education>, ObservableCollection<Models.UserPageModel.Education>>(User.Educations);
        }
        private void MapSertificates()
        {
            Sertificates = Mapper.Map<ICollection<Sertificate>, ObservableCollection<Models.UserPageModel.Sertificate>>(User.Sertificates);
        }
        private void MapLanguages()
        {
            Languages = Mapper.Map<ICollection<Language>, ObservableCollection<Models.UserPageModel.Language>>(User.Languages);
        }

        #endregion
    }
}
