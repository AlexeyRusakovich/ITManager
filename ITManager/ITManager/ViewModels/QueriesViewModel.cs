using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ITManager.Database;
using ITManager.Events;
using ITManager.Helpers;
using ITManager.ViewModels.Base;
using Prism.Commands;
using Prism.Events;
using Prism.Regions;

namespace ITManager.ViewModels
{
    public class QueriesViewModel : BaseViewModel
    {
        private readonly NavigationService _navigationService;

        public ICommand GoToQuery { get; set; }

        public ICommand RemoveQuery { get; set; }

        public ObservableCollection<Query> Queries { get; set; } = new ObservableCollection<Query>();

        public QueriesViewModel(NavigationService navigationService, IEventAggregator eventAggregator) : base("Queries")
        {
            Init();
            GoToQuery = new DelegateCommand<object>(GoToQueryMethod);
            RemoveQuery = new DelegateCommand<object>(RemoveQueryMethod);
            _navigationService = navigationService;
            eventAggregator.GetEvent<UpdateQueriesEvent>().Subscribe(Init);
        }

        private async void Init()
        {
            using (var _database = new ITManagerEntities())
            {
                var user = await _database.Users.Where(u => u.Id == ShellViewModel.CurrentUserId)
                    .Include(u => u.Queries).FirstOrDefaultAsync();
                    Queries = new ObservableCollection<Query>(user.Queries);
            }
        }

        private async void GoToQueryMethod(object query)
        {
            var queryId = ((Query) query).Id;
            var navigationParameters = new NavigationParameters();
            navigationParameters.Add("QueryId", queryId.ToString());
            _navigationService.NavigateToWithParameters(Constants.SearchView, navigationParameters: navigationParameters);
        }

        private async void RemoveQueryMethod(object query)
        {
            var _query = (Query)query;
            using (var _database = new ITManagerEntities())
            {
                _database.Queries.Remove(_database.Queries.FirstOrDefault(q => q.Id == _query.Id));
                await _database.SaveChangesAsync();
                var user = await _database.Users.Where(u => u.Id == ShellViewModel.CurrentUserId)
                    .Include(u => u.Queries).FirstOrDefaultAsync();
                Queries = new ObservableCollection<Query>(user.Queries);
            }
        }
    }
}
