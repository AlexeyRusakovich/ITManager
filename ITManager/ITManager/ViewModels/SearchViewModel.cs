using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using AutoMapper;
using ITManager.Database;
using ITManager.Events;
using ITManager.Helpers;
using ITManager.Interfaces;
using ITManager.Models.SearchPageModels;
using ITManager.ViewModels.Base;
using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using WindowsInput;

namespace ITManager.ViewModels
{
    public class SearchViewModel : BaseViewModel, INavigationAware
    {
        private readonly INavigationService _navigationService;
        private readonly IEventAggregator _eventAggregator;

        #region Properties
        
        public bool Options1Open { get; set; }
        public bool Options2Open { get; set; }

        public ObservableCollection<SkillCondition> SkillsConditions { get; set; } = new ObservableCollection<SkillCondition>();
        public ObservableCollection<LanguageCondition> LanguagesConditions { get; set; } = new ObservableCollection<LanguageCondition>();     

        public IList<SkillLevel> SkillLevels { get; set; }
        public IList<LanguageLevel> LanguageLevels { get; set; }

        public IList<Models.UserPageModel.ProfessionalSkill> Skills { get; set; } = new List<Models.UserPageModel.ProfessionalSkill>();
        public ObservableCollection<Models.UserPageModel.ProfessionalSkill> SelectedSkills { get; set; }  = new ObservableCollection<Models.UserPageModel.ProfessionalSkill>();

        public IList<Models.ProjectsManagementPageModels.Project> Projects { get; set; } = new List<Models.ProjectsManagementPageModels.Project>();
        public ObservableCollection<Models.ProjectsManagementPageModels.Project> SelectedProjects { get; set; } = new ObservableCollection<Models.ProjectsManagementPageModels.Project>();

        public IList<Models.UserPageModel.LanguagesList> Languages { get; set; } = new List<Models.UserPageModel.LanguagesList>();
        public ObservableCollection<Models.UserPageModel.LanguagesList> SelectedLanguages { get; set; } = new ObservableCollection<Models.UserPageModel.LanguagesList>();

        public List<User> Users { get; set;}

        public ObservableCollection<SearchedUserModel> SearchedUsers { get; set; }

        public string QueryDescription { get; set; } = string.Empty;

        public string QueryErrors { get; set; }

        #endregion

        #region Commands

        public ICommand SkillsSelectionChanged { get; set; }
        public ICommand LanguagesSelectionChanged { get; set; }

        public ICommand SearchCommand { get; set; }

        public ICommand NavigateToUserCommand { get; set; }

        public ICommand SaveQueryCommand { get; set; }

        public ICommand OpenCloseOptions1 { get; set; }

        public ICommand OpenCloseOptions2 { get; set; }

        #endregion

        public SearchViewModel(INavigationService navigationService, IEventAggregator eventAggregator) : base("Search")
        {
            (new InputSimulator()).Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.RETURN);
            _navigationService = navigationService;
            _eventAggregator = eventAggregator;
            SearchCommand = new DelegateCommand(SearchMethod);
            NavigateToUserCommand = new DelegateCommand<object>(NavigateToUserMethod);
            SaveQueryCommand = new DelegateCommand(SaveQueryMethod);
            OpenCloseOptions1 = new DelegateCommand(OpenCloseOptions1Method);
            OpenCloseOptions2 = new DelegateCommand(OpenCloseOptions2Method);
            SkillsSelectionChanged = new DelegateCommand(SkillsSelectionChangedMethod);
            LanguagesSelectionChanged = new DelegateCommand(LanguagesSelectionChangedMethod);
        }

        private void SkillsSelectionChangedMethod()
        {
            if(SelectedSkills == null)
                SelectedSkills = new ObservableCollection<Models.UserPageModel.ProfessionalSkill>();
            if (SelectedSkills.Count > SkillsConditions.Count)
            {
                foreach (var selectedSkill in SelectedSkills)
                {
                    if(SkillsConditions.Where(s => s.Skill.Id == selectedSkill.Id).FirstOrDefault() == null)
                    {
                        SkillsConditions.Add(new SkillCondition
                        {
                            Skill = selectedSkill,
                            From = SkillLevels.First(),
                            To = SkillLevels.Last()
                        });
                        return;
                    }   
                }
            }

            if(SelectedSkills.Count < SkillsConditions.Count)
            {
                foreach (var skillCondition in SkillsConditions)
                {
                    if(SelectedSkills.Where(s => s.Id == skillCondition.Skill.Id).FirstOrDefault() == null)
                    {
                        var skill = SkillsConditions.Where(s => s.Skill.Id == skillCondition.Skill.Id).FirstOrDefault();
                        if(skill == null)
                            return;
                        SkillsConditions.Remove(skill);
                        return;
                    }   
                }
            }
        }

        private void LanguagesSelectionChangedMethod()
        {
             if(SelectedLanguages == null)
                SelectedLanguages = new ObservableCollection<Models.UserPageModel.LanguagesList>();
            if (SelectedLanguages.Count > LanguagesConditions.Count)
            {
                foreach (var selectedLanguage in SelectedLanguages)
                {
                    if(LanguagesConditions.Where(s => s.Language.Id == selectedLanguage.Id).FirstOrDefault() == null)
                    {
                        LanguagesConditions.Add(new LanguageCondition
                        {
                            Language = selectedLanguage,
                            From = LanguageLevels.First(),
                            To = LanguageLevels.Last()
                        });
                        return;
                    }   
                }
            }

            if(SelectedLanguages.Count < LanguagesConditions.Count)
            {
                foreach (var languageCondition in LanguagesConditions)
                {
                    if(SelectedLanguages.Where(s => s.Id == languageCondition.Language.Id).FirstOrDefault() == null)
                    {
                        var language = LanguagesConditions.Where(s => s.Language.Id == languageCondition.Language.Id).FirstOrDefault();
                        if(language == null)
                            return;
                        LanguagesConditions.Remove(language);
                        return;
                    }   
                }
            }
        }

        private void OpenCloseOptions1Method()
        {
            Options1Open  = Options1Open ? false : true;
            SkillsSelectionChangedMethod();
            if (SelectedProjects == null)
                SelectedProjects = new ObservableCollection<Models.ProjectsManagementPageModels.Project>();
        }

        private void OpenCloseOptions2Method()
        {
            Options2Open  = Options2Open ? false : true;
            LanguagesSelectionChangedMethod();
            if (SelectedProjects == null)
                SelectedProjects = new ObservableCollection<Models.ProjectsManagementPageModels.Project>();
        }

        private async void SaveQueryMethod()
        {
            if (QueryDescription.Length > 1 && QueryDescription.Length < 100)
            {
                var skillsQuery = string.Join(",", SkillsConditions?.Select(s => $"{s.Skill.Id}:{s.From.Id}-{s.To.Id}"));
                var languagesQuery = string.Join(",", LanguagesConditions?.Select(l => $"{l.Language.Id}:{l.From.Id}-{l.To.Id}"));
                var projectsQuery = string.Join(",", SelectedProjects?.Select(p => p.Id));

                var query = $"{skillsQuery}&{languagesQuery}&{projectsQuery}";

                using (var _database = new ITManagerEntities())
                {
                    var user = await _database.Users.Where(u => u.Id == ShellViewModel.CurrentUserId)
                        .Include(u => u.Queries).FirstOrDefaultAsync();
                    user.Queries.Add(new Query()
                    {
                        Description = QueryDescription,
                        QueryString = query,
                        UserId = ShellViewModel.CurrentUserId
                    });
                    await _database.SaveChangesAsync();
                }
                _eventAggregator.GetEvent<UpdateQueriesEvent>().Publish();
                QueryErrors = string.Empty;
            }
            else
            {
                QueryErrors = "Query description length must be from 1 to 100 sybmols.";
            }
        }

        private void NavigateToUserMethod(object user)
        {
            var navigationParameters = new NavigationParameters();
            navigationParameters.Add("UserId", ((SearchedUserModel)user).Id.ToString());
            _navigationService.NavigateToWithParameters(Constants.MyPersonalPageView, navigationParameters: navigationParameters);
        }

        private void SearchMethod()
        {
            if(SelectedProjects == null)
                SelectedProjects = new ObservableCollection<Models.ProjectsManagementPageModels.Project>();
            var conditionsCount = SkillsConditions.Count + SelectedProjects.Count + LanguagesConditions.Count;

            SearchedUsers = new ObservableCollection<SearchedUserModel>(Users.Select(u => 
            {
                IDictionary<LanguageCondition, bool> languagesConditions = new Dictionary<LanguageCondition, bool>();
                IDictionary<SkillCondition, bool> skillsConditions = new Dictionary<SkillCondition, bool>();
                IDictionary<Models.ProjectsManagementPageModels.Project, bool> projectsConditions = new Dictionary<Models.ProjectsManagementPageModels.Project, bool>();

                foreach (var languageCondition in LanguagesConditions)
                {
                    if(u.Languages.Any(l => l.LanguageId == languageCondition.Language.Id && l.LanguageLevelId.IsBetween(languageCondition.From.Id, languageCondition.To.Id)))
                        languagesConditions.Add(languageCondition, true);
                    else
                        languagesConditions.Add(languageCondition, false);
                }

                foreach (var skillCondition in SkillsConditions)
                {
                    if(u.UserSkills.Any(l => l.SkillId == skillCondition.Skill.Id && l.SkillLevelId.IsBetween(skillCondition.From.Id, skillCondition.To.Id)))
                        skillsConditions.Add(skillCondition, true);
                    else
                        skillsConditions.Add(skillCondition, false);
                }

                foreach (var projectCondition in SelectedProjects)
                {
                    if(u.UserProjects.Any(l => l.ProjectId == projectCondition.Id))
                        projectsConditions.Add(projectCondition, true);
                    else
                        projectsConditions.Add(projectCondition, false);
                }

                var successfulConditionsCount = languagesConditions.Where(c => c.Value).Count() +
                                            skillsConditions.Where(c => c.Value).Count() +
                                            projectsConditions.Where(c => c.Value).Count();

                var persent = conditionsCount ==  0 ? 100 : (successfulConditionsCount * 100) / conditionsCount;

                return new SearchedUserModel
                {
                    Id = u.Id,
                    Name = u.Name,
                    Surname = u.Surname,
                    Persent = persent,
                    LanguagesConditions = languagesConditions,
                    SkillsConditions = skillsConditions,
                    ProjectsConditions = projectsConditions                     
                };
            }).OrderByDescending(u => u.Persent));
        }

        private async void Init()
        {
            using (var _database = new ITManagerEntities())
            {
                Languages = Mapper.Map<IList<LanguagesList>, IList<Models.UserPageModel.LanguagesList>>(await _database.LanguagesLists.ToListAsync());
                Skills = Mapper.Map<IList<ProfessionalSkill>, IList<Models.UserPageModel.ProfessionalSkill>>(await _database.ProfessionalSkills.ToListAsync());
                Projects = Mapper.Map<IList<Project>, IList<Models.ProjectsManagementPageModels.Project>>(await _database.Projects.ToListAsync());
                SkillLevels = await _database.SkillLevels.ToListAsync();
                LanguageLevels = await _database.LanguageLevels.ToListAsync();
            }
        }

        private async void InitUsers()
        {
            using (var _database = new ITManagerEntities())
            {
                Users = await _database.Users.Where(u =>    u.UserRoles.FirstOrDefault().RoleId != Constants.AdministratorRole && 
                                                            u.UserRoles.FirstOrDefault().RoleId != Constants.ManagerRole &&
                                                            u.IsActive)
                                                            .Include(u => u.UserSkills)
                                                            .Include(u => u.UserProjects)
                                                            .Include(u => u.UserSkills)
                                                            .Include(u => u.Languages)
                                                            .ToListAsync();
            }
        }

        public async void OnNavigatedTo(NavigationContext navigationContext)
        {
            if(Skills?.Count == 0)
                Init();
            InitUsers();
            var parameters = navigationContext.Parameters;
            if (parameters["QueryId"] != null)
            {
                using (var _database = new ITManagerEntities())
                {
                    var queryId = int.Parse((string)parameters["QueryId"]);
                    var queryString = (await _database.Queries.Where(q => q.Id == queryId).FirstOrDefaultAsync()).QueryString;
                    var splittedQuery = queryString.Split('&');
                    var skillsQuery = splittedQuery[0];
                    var languagesQuery = splittedQuery[1];
                    var projectsQuery = splittedQuery[2];

                    SkillsConditions = new ObservableCollection<SkillCondition>(skillsQuery.Split(',').Select(q => new SkillCondition
                    {
                        Skill = Skills.Where(s => s.Id == int.Parse(q.Split(':')[0])).FirstOrDefault(),
                         From = SkillLevels.Where(s => s.Id == int.Parse(q.Split(':')[1].Split('-')[0])).FirstOrDefault(),
                         To = SkillLevels.Where(s => s.Id == int.Parse(q.Split(':')[1].Split('-')[1])).FirstOrDefault()
                    }));

                    SelectedSkills = new ObservableCollection<Models.UserPageModel.ProfessionalSkill>(Skills.Where(s => SkillsConditions.Any(sc => sc.Skill.Id == s.Id)));
                    
                    LanguagesConditions = new ObservableCollection<LanguageCondition>(languagesQuery.Split(',').Select(q => new LanguageCondition
                    {
                         Language = Languages.Where(l => l.Id == int.Parse(q.Split(':')[0])).FirstOrDefault(),
                         From = LanguageLevels.Where(l => l.Id == int.Parse(q.Split(':')[1].Split('-')[0])).FirstOrDefault(),
                         To = LanguageLevels.Where(l => l.Id == int.Parse(q.Split(':')[1].Split('-')[1])).FirstOrDefault()
                    }));

                    SelectedLanguages = new ObservableCollection<Models.UserPageModel.LanguagesList>(Languages.Where(l => LanguagesConditions.Any(lc => lc.Language.Id == l.Id)));

                    var projectsIds = projectsQuery.Split(',').Select(pId => int.Parse(pId));
                    SelectedProjects = new ObservableCollection<Models.ProjectsManagementPageModels.Project>(Projects.Where(p => projectsIds.Contains(p.Id)));
                }

                SearchMethod();
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
