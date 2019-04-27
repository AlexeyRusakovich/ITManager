using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
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

        public IList<Models.UserPageModel.ProfessionalSkill> Skills { get; set; }
        public ObservableCollection<Models.UserPageModel.ProfessionalSkill> SelectedSkills { get; set; } = new ObservableCollection<Models.UserPageModel.ProfessionalSkill>();

        public IList<Models.ProjectsManagementPageModels.Project> Projects { get; set; }
        public ObservableCollection<Models.ProjectsManagementPageModels.Project> SelectedProjects { get; set; } = new ObservableCollection<Models.ProjectsManagementPageModels.Project>();

        public IList<Models.UserPageModel.LanguagesList> Languages { get; set; }
        public ObservableCollection<Models.UserPageModel.LanguagesList> SelectedLanguages { get; set; } = new ObservableCollection<Models.UserPageModel.LanguagesList>();

        public List<User> Users { get; set;}

        public ObservableCollection<SearchedUserModel> SearchedUsers { get; set; }

        public string SelectedItemsText { get; set; }

        public string QueryDescription { get; set; }

        #endregion

        #region Commands
        
        public ICommand CheckedCommand { get; set; }

        public ICommand UncheckedCommand { get; set; }

        public ICommand SearchCommand { get; set; }

        public ICommand NavigateToUserCommand { get; set; }

        public ICommand SaveQueryCommand { get; set; }

        public ICommand OpenCloseOptions1 { get; set; }

        public ICommand OpenCloseOptions2 { get; set; }

        #endregion

        public SearchViewModel(INavigationService navigationService, IEventAggregator eventAggregator) : base("Search")
        {
            Init();
            CheckedCommand = new DelegateCommand<object>(CheckedMethod);
            UncheckedCommand = new DelegateCommand<object>(UncheckedMethod);
            SearchCommand = new DelegateCommand(SearchMethod);
            NavigateToUserCommand = new DelegateCommand<object>(NavigateToUserMethod);
            SaveQueryCommand = new DelegateCommand(SaveQueryMethod);
            OpenCloseOptions1 = new DelegateCommand(OpenCloseOptions1Method);
            OpenCloseOptions2 = new DelegateCommand(OpenCloseOptions2Method);
            _navigationService = navigationService;
            _eventAggregator = eventAggregator;
            (new InputSimulator()).Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.RETURN);
            SelectedSkills.CollectionChanged += SelectedSkills_CollectionChanged;
        }

        private void SelectedSkills_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            return;
        }

        private void OpenCloseOptions1Method()
        {
            Options1Open  = Options1Open ? false : true;
        }

        private void OpenCloseOptions2Method()
        {
            Options2Open  = Options2Open ? false : true;
        }

        private async void SaveQueryMethod()
        {
            if (SelectedSkills.Count == 0)
                return;

            using (var _database = new ITManagerEntities())
            {
                var user = await _database.Users.Where(u => u.Id == ShellViewModel.CurrentUserId)
                    .Include(u => u.Queries).FirstOrDefaultAsync();
                user.Queries.Add(new Query()
                {
                    Description = QueryDescription,
                    QueryString = string.Join(", ", SelectedSkills.Select(s => s.Id)),
                    UserId = ShellViewModel.CurrentUserId
                });
                await _database.SaveChangesAsync();
            }
            _eventAggregator.GetEvent<UpdateQueriesEvent>().Publish();
        }

        private void NavigateToUserMethod(object user)
        {
            var navigationParameters = new NavigationParameters();
            navigationParameters.Add("UserId", ((SearchedUserModel)user).Id.ToString());
            _navigationService.NavigateToWithParameters(Constants.MyPersonalPageView, navigationParameters: navigationParameters);
        }

        private void SearchMethod()
        {
            SearchedUsers = new ObservableCollection<SearchedUserModel>(Users.Select(u => 
            {
                var searchedSkillCount = u.UserSkills.Where(s => SelectedSkills.Any(ss => ss.Id == s.SkillId)).Count();
                var persent = SelectedSkills.Count == 0 ? 100 : (searchedSkillCount * 100) / SelectedSkills.Count;
                return new SearchedUserModel
                {
                    Id = u.Id,
                    Name = u.Name,
                    Surname = u.Surname,
                    Persent = persent
                };
            }).OrderByDescending(u => u.Persent));
        }

        private void CheckedMethod(object sender)
        {
            SelectedSkills.Add((Models.UserPageModel.ProfessionalSkill)sender);
            UpdateSelectedItemsText();
        }

        private void UncheckedMethod(object sender)
        {
            SelectedSkills.Remove((Models.UserPageModel.ProfessionalSkill)sender);
            UpdateSelectedItemsText();
        }

        private void UpdateSelectedItemsText()
        {
            SelectedItemsText =  string.Join(", ", SelectedSkills.Select(s => s.Name));
        }

        private async void Init()
        {
            using (var _database = new ITManagerEntities())
            {
                Users = await _database.Users.Where(u => u.UserRoles.FirstOrDefault().RoleId != Constants.AdministratorRole && 
                                                         u.UserRoles.FirstOrDefault().RoleId != Constants.ManagerRole).Include(u => u.UserSkills).ToListAsync();
                Skills = Mapper.Map<IList<ProfessionalSkill>, IList<Models.UserPageModel.ProfessionalSkill>>(await _database.ProfessionalSkills.ToListAsync());
                Projects = Mapper.Map<IList<Project>, IList<Models.ProjectsManagementPageModels.Project>>(await _database.Projects.ToListAsync());
                Languages = Mapper.Map<IList<LanguagesList>, IList<Models.UserPageModel.LanguagesList>>(await _database.LanguagesLists.ToListAsync());
            }
        }

        public async void OnNavigatedTo(NavigationContext navigationContext)
        {
            var parameters = navigationContext.Parameters;
            if (parameters["QueryId"] != null)
            {
                using (var _database = new ITManagerEntities())
                {
                    var queryId = int.Parse((string)parameters["QueryId"]);
                    var query = await _database.Queries.Where(q => q.Id == queryId).FirstOrDefaultAsync();
                    var queryIds = query.QueryString.Split(',').Select(q => int.Parse(q.Trim()));
                    SelectedSkills = new ObservableCollection<Models.UserPageModel.ProfessionalSkill>(Skills.Where(s => queryIds.Contains(s.Id)));
                    UpdateSelectedItemsText();
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
