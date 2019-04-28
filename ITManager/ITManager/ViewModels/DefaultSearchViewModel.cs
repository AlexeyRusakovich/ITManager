using ITManager.Database;
using ITManager.Helpers;
using ITManager.Interfaces;
using ITManager.ViewModels.Base;
using Prism.Commands;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace ITManager.ViewModels
{
    public class DefaultSearchViewModel : BaseViewModel, INavigationAware
    {
        private readonly INavigationService _navigationService;

        #region Properties

        public ObservableCollection<User> Users { get; set; }

        public ObservableCollection<User> SearchedUsers { get; set; } = new ObservableCollection<User>();

        public string SearchedString { get; set; }

        #endregion

        #region Commands

        public ICommand Search { get; set; }

        public ICommand GoToUser { get; set; }

        public AutoCompleteFilterPredicate<object> PersonFilter
        {
            get
            {
                return (searchText, obj) =>
                    (obj as User).Name.Contains(searchText)
                    || (obj as User).Surname.Contains(searchText);
            }
        }

        #endregion

        public DefaultSearchViewModel(INavigationService navigationService) : base("Search")
        {
            _navigationService = navigationService;

            GoToUser = new DelegateCommand<object>(GoToUserMethod);
            Search = new DelegateCommand(SearchMethod);
        }

        private void GoToUserMethod(object userId)
        {
            var navigationParameters = new NavigationParameters();
            navigationParameters.Add("UserId", userId);
            _navigationService.NavigateToWithParameters(Constants.MyPersonalPageView, navigationParameters: navigationParameters);
        }

        private async void Init()
        {
            using (var _database = new ITManagerEntities())
            {
                Users = new ObservableCollection<User>(_database.Users.Where(u =>    u.UserRoles.FirstOrDefault().RoleId != Constants.AdministratorRole && 
                                                        u.UserRoles.FirstOrDefault().RoleId != Constants.ManagerRole &&
                                                        u.IsActive));
            }
        }

        private void SearchMethod()
        {
            SearchedUsers = new ObservableCollection<User>(Users.Where(u => $"{u.Name} {u.Surname}".Contains(SearchedString)));
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            Init();
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
