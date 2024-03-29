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
using System.Windows.Input;
using AutoMapper;
using Prism.Commands;
using System.Windows;
using ITManager.Helpers;

namespace ITManager.ViewModels
{
    public class MyPersonalPageViewModel : BaseViewModel, INavigationAware
    {
        // Current user, taken from database
        public User User { get; set; }

        #region Data validation properties

        public string SkillsErrors { get; set;}

        public Visibility SkillsErrorsVisibility => string.IsNullOrWhiteSpace(SkillsErrors) ? Visibility.Collapsed : Visibility.Visible;

        public string ProjectsErrors { get; set;}

        public Visibility ProjectsErrorsVisibility => string.IsNullOrWhiteSpace(ProjectsErrors) ? Visibility.Collapsed : Visibility.Visible;

        public string EducationErrors { get; set;}

        public Visibility EducationErrorsVisibility => string.IsNullOrWhiteSpace(EducationErrors) ? Visibility.Collapsed : Visibility.Visible;

        public string CertificatesErrors { get; set;}

        public Visibility CertificatesErrorsVisibility => string.IsNullOrWhiteSpace(CertificatesErrors) ? Visibility.Collapsed : Visibility.Visible;
        public string LanguagesErrors { get; set;}

        public Visibility LanguagesErrorsVisibility => string.IsNullOrWhiteSpace(LanguagesErrors) ? Visibility.Collapsed : Visibility.Visible;

        #endregion

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

        public IList<Project> ProjectsList {get; set; }
        public IList<LanguagesList> LanguagesList { get; set;}
        public IList<LanguageLevel> LanguageLevels { get; set; }
        public IList<SkillLevel> SkillLevels { get; set; }
        public IList<Position> Positions { get; set; }
        public IList<ProfessionalSkill> ProfessionalSkills { get; set;}

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

        #region Toggle buttons properties

        public bool IsProfessionalSummaryChecked { get; set; }

        public bool IsSkillsChecked { get; set; }

        public bool IsProjectsChecked { get; set; }

        public bool IsEducationsChecked { get; set; }

        public bool IsSertificatesChecked { get; set; }

        public bool IsLanguagesChecked { get; set; }

        #endregion

        #region Ctor

        public MyPersonalPageViewModel() : base("My page")
        {
            ResetEducations = new DelegateCommand(MapEducations);
            SaveEducations = new DelegateCommand(SaveEducationsMethod);
            AddEducation = new DelegateCommand(AddEducationMethod);
            RemoveEducation = new DelegateCommand<Models.UserPageModel.Education>(RemoveEducationMethod);

            ResetSertificates = new DelegateCommand(MapSertificates);
            SaveSertificates = new DelegateCommand(SaveSertificatesMethod);
            AddSertificate = new DelegateCommand(AddSertificateMethod);
            RemoveSertificate = new DelegateCommand<Models.UserPageModel.Sertificate>(RemoveSertificateMethod);

            ResetLanguages = new DelegateCommand(MapLanguages);
            SaveLanguages = new DelegateCommand(SaveLanguagesMethod);
            AddLanguage = new DelegateCommand(AddLanguageMethod);
            RemoveLanguage = new DelegateCommand<Models.UserPageModel.Language>(RemoveLanguageMethod);

            ResetProjects = new DelegateCommand(MapProjects);
            SaveProjects = new DelegateCommand(SaveProjectsMethod);
            AddProject = new DelegateCommand(AddProjectMethod);
            RemoveProject = new DelegateCommand<Models.UserPageModel.Project>(RemoveProjectMethod);

            ResetProfessionalSummary = new DelegateCommand(MapProfessionalSummary);     
            SaveProfessionalSummary = new DelegateCommand(SaveProfessionalSummaryMethod);
            
            ResetSkills = new DelegateCommand(MapSkills);
            SaveSkills = new DelegateCommand(SaveSkillsMethod);
            AddSkill = new DelegateCommand(AddSkillMethod);
            RemoveSkill = new DelegateCommand<Models.UserPageModel.UserSkill>(RemoveSkillMethod);
        }

        #endregion

        #region User saving

        private bool IsSkillsValid()
        {
            SkillsErrors = null;

            if(Skills.Any(s => s.SkillId == 0 || s.SkillLevelId == 0))
                SkillsErrors += "Fill all the fields of your skills.\r\n";
            if(Skills.GroupBy(x => x.SkillId).Any(group => group.Count() > 1))
                SkillsErrors += "Remove identical skills.\r\n";

            SkillsErrors = SkillsErrors?.Trim();

            return SkillsErrors == null;
        }

        private async void SaveSkillsMethod()
        {
            if(IsSkillsValid())
            {
                using (var _database = new ITManagerEntities())
                {
                    var userSkills = (await _database.Users.Where(u => u.Id == User.Id)
                        .Include(u => u.UserSkills)
                        .FirstOrDefaultAsync()).UserSkills;

                    // Removing and changing skills
                    foreach (var userSkill in userSkills.ToList())
                    {
                        var _userSkill = Skills.FirstOrDefault(l => l.Id == userSkill.Id);
                        // If exists in local collection, change data
                        if (_userSkill != null)
                        {
                            userSkill.SkillId = _userSkill.SkillId;
                            userSkill.SkillLevelId = _userSkill.SkillLevelId;
                            userSkill.UserId = User.Id;
                        }
                        // If not exists in local collection - remove.
                        else
                        {
                            _database.UserSkills.Remove(userSkill);
                        }
                    }

                    // Adding new skill
                    foreach (var newSkill in Skills.Where(l => l.Id == 0))
                    {
                        userSkills.Add(new UserSkill
                        {
                            SkillId = newSkill.SkillId,
                            SkillLevelId = newSkill.SkillLevelId,
                            UserId = User.Id
                        });
                    }

                    IsSkillsChecked = false;
                    User.UserSkills = (await _database.Users.Where(u => u.Id == User.Id).FirstOrDefaultAsync())?.UserSkills;

                    await _database.SaveChangesAsync();
                }
            }            
        }
        private void AddSkillMethod()
        {
            Skills.Add(new Models.UserPageModel.UserSkill());
        }
        private void RemoveSkillMethod(Models.UserPageModel.UserSkill userSkill)
        {
            Skills.Remove(userSkill);
        }


        private async void SaveProfessionalSummaryMethod()
        {
            using (var _database = new ITManagerEntities())
            {
                var _professionalSummary =  (await _database.ProfessionalSummaries.Where(p => p.Id == ProfessionalSummary.Id).FirstOrDefaultAsync());
                if (_professionalSummary != null)
                {
                    _professionalSummary.ProfessionalSummary1 = ProfessionalSummary.ProfessionalSummary1;
                    User.ProfessionalSummaries = await _database.ProfessionalSummaries.Where(u => u.UserId == User.Id).ToListAsync();
                }
                else
                {
                    _database.ProfessionalSummaries.Add(new ProfessionalSummary
                    {
                        UserId = User.Id,
                        ProfessionalSummary1 = ProfessionalSummary.ProfessionalSummary1
                    });
                }

                IsProfessionalSummaryChecked = false;

                await _database.SaveChangesAsync();
            }
        }

        private bool IsProjectsValid()
        {
            ProjectsErrors = null;

            if(Projects.Any(p => p.PositionId == 0) || Projects.Any(x => x.ProjectId == 0))
                ProjectsErrors += "Fill all the fields of your proejects.\r\n";
            if(Projects.GroupBy(x => x.ProjectId).Any(group => group.Count() > 1))
                ProjectsErrors += "Remove identical projects.\r\n";

            ProjectsErrors = ProjectsErrors?.Trim();

            return ProjectsErrors == null;
        }
        private async void SaveProjectsMethod()
        {
            if(IsProjectsValid())
            {
                using (var _database = new ITManagerEntities())
                {
                var userProjects = (await _database.Users.Where(u => u.Id == User.Id)
                    .Include(u => u.UserProjects)
                    .FirstOrDefaultAsync()).UserProjects;

                // Removing and changing projects
                foreach (var userProject in userProjects.ToList())
                {
                    var _userProject = Projects.FirstOrDefault(l => l.Id == userProject.Id);
                    // If exists in local collection, change data
                    if (_userProject != null)
                    {
                        userProject.ProjectId = _userProject.ProjectId;
                        userProject.PositionId = _userProject.PositionId;
                    }
                    // If not exists in local collection - remove.
                    else
                    {
                        _database.UserProjects.Remove(userProject);
                    }
                }

                // Adding new project
                foreach (var newProject in Projects.Where(l => l.Id == 0))
                {
                    userProjects.Add(new UserProject
                    {
                        ProjectId = newProject.ProjectId,
                        PositionId = newProject.PositionId,
                        UserId = User.Id
                    });
                }

                IsProjectsChecked = false;
                User.UserProjects = (await _database.Users.Where(u => u.Id == User.Id).FirstOrDefaultAsync())?.UserProjects;
                MapProjects();

                await _database.SaveChangesAsync();
            }
            }            
        }
        private void AddProjectMethod()
        {
            Projects.Add(new Models.UserPageModel.Project());
        }
        private void RemoveProjectMethod(Models.UserPageModel.Project project)
        {
            Projects.Remove(project);
        }

        private bool IsEducationValid()
        {
            EducationErrors = null;

            if(Educations.Any(p => p.Faculty.IsNullOrWhiteSpace()))
                EducationErrors += "Faculty field must be filled.\r\n";
            if(Educations.Any(p => p.Speciality.IsNullOrWhiteSpace()))
                EducationErrors += "Speciality field must be filled.\r\n";
            if(Educations.Any(p => p.University.IsNullOrWhiteSpace()))
                EducationErrors += "University field must be filled.\r\n";
            if(Educations.Any(p => p.StartDate == default(DateTime)))
                EducationErrors += "StartDate field must be filled.\r\n";
            if(Educations.Any(p => p.EndDate == null))
                EducationErrors += "EndDate field must be filled.\r\n";
            if(Educations.Any(p => p.StartDate != default(DateTime) && p.EndDate !=null && p.StartDate > p.EndDate))
                EducationErrors += "Start date must be less than end date field.\r\n";
            if(Projects.GroupBy(x => x.ProjectId).Any(group => group.Count() > 1))
                EducationErrors += "Remove identical projects.\r\n";

            EducationErrors = EducationErrors?.Trim();

            return EducationErrors == null;
        }
        private async void SaveEducationsMethod()
        {
            if(IsEducationValid())
            {
                 using (var _database = new ITManagerEntities())
                {
                    var userEducations = (await _database.Users.Where(u => u.Id == User.Id)
                        .Include(u => u.Educations)
                        .FirstOrDefaultAsync()).Educations;

                    // Removing and changing educations
                    foreach (var userEducation in userEducations.ToList())
                    {
                        var _userEducation = Educations.FirstOrDefault(l => l.Id == userEducation.Id);
                        // If exists in local collection, change data
                        if (_userEducation != null)
                        {
                            userEducation.StartDate = _userEducation.StartDate;
                            userEducation.EndDate = _userEducation.EndDate;
                            userEducation.Faculty = _userEducation.Faculty;
                            userEducation.Speciality = _userEducation.Speciality;
                            userEducation.University = _userEducation.University;
                        }
                        // If not exists in local collection - remove.
                        else
                        {
                            _database.Educations.Remove(userEducation);
                        }
                    }

                    // Adding new education
                    foreach (var newEducation in Educations.Where(l => l.Id == 0))
                    {
                        userEducations.Add(new Education
                        {
                            StartDate = newEducation.StartDate,
                            EndDate = newEducation.EndDate,
                            Faculty = newEducation.Faculty,
                            Speciality = newEducation.Speciality,
                            University = newEducation.University,
                            UserId = User.Id
                        });
                    }

                    IsEducationsChecked = false;
                    User.Educations = (await _database.Users.Where(u => u.Id == User.Id).FirstOrDefaultAsync())?.Educations;

                    await _database.SaveChangesAsync();
                }
            }           
        }
        private void AddEducationMethod()
        {
            Educations.Add(new Models.UserPageModel.Education());
        }
        private void RemoveEducationMethod(Models.UserPageModel.Education education)
        {
            Educations.Remove(education);
        }

        private bool IsCertificatesValid()
        {
            CertificatesErrors = null;

            if(Sertificates.Any(s => s.Date == default(DateTime)))
                CertificatesErrors += "Date field must be filled.\r\n";
            if(Sertificates.Any(s => s.Name.IsNullOrWhiteSpace()))
                CertificatesErrors += "Area field must be filled.\r\n";

            CertificatesErrors = CertificatesErrors?.Trim();

            return CertificatesErrors == null;
        }
        private async void SaveSertificatesMethod()
        {
            if(IsCertificatesValid())
            {
                using (var _database = new ITManagerEntities())
                {
                    var userSertificates = (await _database.Users.Where(u => u.Id == User.Id)
                        .Include(u => u.Sertificates)
                        .FirstOrDefaultAsync()).Sertificates;

                    // Removing and changing sertificates
                    foreach (var userSertificate in userSertificates.ToList())
                    {
                        var _userSertificate = Sertificates.FirstOrDefault(l => l.Id == userSertificate.Id);
                        // If exists in local collection, change data
                        if (_userSertificate != null)
                        {
                             userSertificate.Name = _userSertificate.Name;
                            userSertificate.Date = _userSertificate.Date;
                        }
                        // If not exists in local collection - remove.
                        else
                        {
                            _database.Sertificates.Remove(userSertificate);
                        }
                    }

                    // Adding new sertificates
                    foreach (var newSertificate in Sertificates.Where(l => l.Id == 0))
                    {
                        userSertificates.Add(new Sertificate
                        {
                            Name = newSertificate.Name,
                            Date = newSertificate.Date,
                            UserId = User.Id
                        });
                    }

                    IsSertificatesChecked = false;
                    User.Sertificates = (await _database.Users.Where(u => u.Id == User.Id).FirstOrDefaultAsync())?.Sertificates;

                    await _database.SaveChangesAsync();
                }
            }            
        }
        private void AddSertificateMethod()
        {
            Sertificates.Add(new Models.UserPageModel.Sertificate());
        }
        private void RemoveSertificateMethod(Models.UserPageModel.Sertificate sertificate)
        {
            Sertificates.Remove(sertificate);
        }
        
        private bool IsLanguagesValid()
        {
            LanguagesErrors = null;

            if(Languages.Any(s => s.LanguageId == 0))
                LanguagesErrors += "Language field must be filled.\r\n";
            if(Languages.Any(s => s.LanguageLevelId == 0))
                LanguagesErrors += "Language level field must be filled.\r\n";
            if(Languages.GroupBy(l => l.LanguageId).Any(l => l.Count() > 1))
                LanguagesErrors += "Remove identical languages.\r\n";
                
            LanguagesErrors = LanguagesErrors?.Trim();

            return LanguagesErrors == null;
        }
        private async void SaveLanguagesMethod()
        {
            if(IsLanguagesValid())
            {
                using (var _database = new ITManagerEntities())
                {
                    var userLanguages = (await _database.Users.Where(u => u.Id == User.Id)
                        .Include(u => u.Languages)
                        .FirstOrDefaultAsync()).Languages;

                    // Removing and changing languages
                    foreach (var userLanguage in userLanguages.ToList())
                    {
                        var _userLanguage = Languages.FirstOrDefault(l => l.Id == userLanguage.Id);
                        // If exists in local collection, change data
                        if (_userLanguage != null)
                        {
                            userLanguage.LanguageId = _userLanguage.LanguageId;
                            userLanguage.LanguageLevelId = _userLanguage.LanguageLevelId;
                        }
                        // If not exists in local collection - remove.
                        else
                        {
                            _database.Languages.Remove(userLanguage);
                        }
                    }

                    // Adding new languages
                    foreach (var newLanguage in Languages.Where(l => l.Id == 0))
                    {
                        _database.Languages.Add(new Language
                        {
                            LanguageId = newLanguage.LanguageId,
                            LanguageLevelId = newLanguage.LanguageLevelId,
                            UserId = User.Id
                        });
                    }

                    IsLanguagesChecked = false;
                    User.Languages = (await _database.Users.Where(u => u.Id == User.Id).FirstOrDefaultAsync())?.Languages;
                    MapLanguages();

                    await _database.SaveChangesAsync();
                }
            }            
        }
        private void AddLanguageMethod()
        {
            Languages.Add(new Models.UserPageModel.Language());
        }
        private void RemoveLanguageMethod(Models.UserPageModel.Language language)
        {
            Languages.Remove(language);
        }

        #endregion

        #region Navigation management

        public async void OnNavigatedTo(NavigationContext navigationContext)
        {
            using (var _database = new ITManagerEntities())
            {
                LanguageLevels = await _database.LanguageLevels.ToListAsync();
                SkillLevels = await _database.SkillLevels.ToListAsync();
                Positions = await _database.Positions.ToListAsync();
                ProfessionalSkills = await _database.ProfessionalSkills.ToListAsync();
                LanguagesList = await _database.LanguagesLists.ToListAsync();
                ProjectsList = await _database.Projects.ToListAsync();

                var parameters = navigationContext.Parameters;
                if (parameters["UserId"] != null)
                {
                    var userId = int.Parse(parameters["UserId"].ToString());
                    var user = await _database.Users.Where(u => u.Id == userId)
                        .Include(u => u.Position)
                        .Include(u => u.ProfessionalSummaries)
                        .Include(u => u.UserSkills)
                        .Include(u => u.UserProjects)
                        .Include(u => u.Educations)
                        .Include(u => u.Sertificates)
                        .Include(u => u.Languages)
                        .FirstOrDefaultAsync();
                    if (user != null)
                    {
                        User = user;
                        if (ShellViewModel.CurrentUser.UserRoles.FirstOrDefault().RoleId == Helpers.Constants.ManagerRole ||
                            User.Id == ShellViewModel.CurrentUserId)
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
        private async void MapProjects()
        {
            Projects = Mapper.Map<ICollection<UserProject>, ObservableCollection<Models.UserPageModel.Project>>(User.UserProjects);
            using (var _database = new ITManagerEntities())
            {
                foreach (var project in Projects)
                {
                    project.RelatedProject = await _database.Projects.Where(p => p.Id == project.ProjectId).FirstOrDefaultAsync();
                }
            }
        }
        private void MapEducations()
        {
            Educations = Mapper.Map<ICollection<Education>, ObservableCollection<Models.UserPageModel.Education>>(User.Educations);
        }
        private void MapSertificates()
        {
            Sertificates = Mapper.Map<ICollection<Sertificate>, ObservableCollection<Models.UserPageModel.Sertificate>>(User.Sertificates);
        }
        private async void MapLanguages()
        {
            Languages = Mapper.Map<ICollection<Language>, ObservableCollection<Models.UserPageModel.Language>>(User.Languages);
            using (var _database = new ITManagerEntities())
            {
                foreach (var language in Languages)
                {
                    language.RelatedLanguage = await _database.LanguagesLists.Where(l => l.Id == language.LanguageId).FirstOrDefaultAsync();
                }
            }
        }

        #endregion
    }
}
