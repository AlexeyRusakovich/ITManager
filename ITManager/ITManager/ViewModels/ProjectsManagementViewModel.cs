using AutoMapper;
using ITManager.Database;
using ITManager.ViewModels.Base;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITManager.ViewModels
{
    public class ProjectsManagementViewModel : BaseViewModel, INavigationAware
    {
        public ObservableCollection<Models.ProjectsManagementPageModels.Project> Projects {  get; set;}
        public ProjectsManagementViewModel() : base("Projects management")
        {
        }

        private async void FillProjects()
        {
            using (var _database = new ITManagerEntities())
            {
                Projects = new ObservableCollection<Models.ProjectsManagementPageModels.Project>(
                    Mapper.Map<IList<Project>, IList<Models.ProjectsManagementPageModels.Project>>(await _database.Projects.ToListAsync()));
            }
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            FillProjects();
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
