using AutoMapper;
using ITManager.Database;
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
using System.Windows.Input;

namespace ITManager.ViewModels
{
    public class ProjectsManagementViewModel : BaseViewModel, INavigationAware
    {
        public ObservableCollection<Models.ProjectsManagementPageModels.Project> Projects {  get; set; } = new ObservableCollection<Models.ProjectsManagementPageModels.Project>();

        #region New project properties

        public string ProjectName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; } = new DateTime();
        public string Description { get; set; }

        private bool stillGoes { get; set; } 
        public bool StillGoes
        {
            get
            {
                return stillGoes;
            }
            set
            {
                stillGoes = value;
                if(stillGoes == true)
                    EndDate = null;
                else
                    EndDate = new DateTime();
            }
        }

        #endregion

        #region Commands

        public ICommand AddNewPorjectCommand { get; set; }

        public ICommand ResetProjects { get; set; }

        public ICommand SaveProjects { get; set; }

        public ICommand RemoveProject { get; set; }

        #endregion

        public ProjectsManagementViewModel() : base("Projects management")
        {
            AddNewPorjectCommand = new DelegateCommand(AddNewProjectMethod);
            ResetProjects = new DelegateCommand(FillProjects);
            SaveProjects = new DelegateCommand(SaveProjectsMethod);
            RemoveProject = new DelegateCommand<Models.ProjectsManagementPageModels.Project>(RemoveProjectMethod);
        }

        private void RemoveProjectMethod(Models.ProjectsManagementPageModels.Project project)
        {
            Projects.Remove(project);
        }
        
        private async void SaveProjectsMethod()
        {
            using (var _database = new ITManagerEntities())
            {
                var projects = await _database.Projects.ToListAsync();

                foreach (var project in projects)
                {
                    var _proejct = Projects.FirstOrDefault(p => p.Id == project.Id);
                    if(_proejct != null)
                    {
                        project.Name = _proejct.Name;
                        project.Description = _proejct.Description;
                        project.StartDate = _proejct.StartDate;
                        project.EndDate = _proejct.EndDate;
                    }
                    else
                    {
                        _database.Projects.Remove(project);
                    }
                }

                foreach (var newProject in Projects.Where(p => p.Id == 0).ToList())
                    {
                        _database.Projects.Add(new Project
                        {
                            Name = newProject.Name,
                            StartDate = newProject.StartDate,
                            EndDate =  newProject.EndDate,
                            Description = newProject.Description
                        });
                    }

                await _database.SaveChangesAsync();
                FillProjects();
            }
        }

        private async void FillProjects()
        {
            using (var _database = new ITManagerEntities())
            {
                Projects = new ObservableCollection<Models.ProjectsManagementPageModels.Project>(
                    Mapper.Map<IList<Project>, IList<Models.ProjectsManagementPageModels.Project>>(await _database.Projects.ToListAsync()));
            }
        }

        private void AddNewProjectMethod()
        {
            Projects.Add(new Models.ProjectsManagementPageModels.Project
            {
                Name = ProjectName,
                StartDate =StartDate,
                EndDate = EndDate,
                Description = Description
            });
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
