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
using ITManager.Helpers;

namespace ITManager.ViewModels
{
    public class ProjectsManagementViewModel : BaseViewModel, INavigationAware
    {
        public ObservableCollection<Models.ProjectsManagementPageModels.Project> Projects {  get; set; } = new ObservableCollection<Models.ProjectsManagementPageModels.Project>();

        #region New project properties

        public string ProjectName { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
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
                    EndDate = new DateTime().ToShortDateString();
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
            if (IsValid(ValidatesProperties, out var errors))
            {
                Errors = errors;
                Projects.Add(new Models.ProjectsManagementPageModels.Project
                {
                    Name = ProjectName,
                    StartDate = DateTime.Parse(StartDate),
                    EndDate = StillGoes ? null : new DateTime?(DateTime.Parse(EndDate)),
                    Description = Description
                });
            }
            else
            {
                Errors = errors;
            }

            Errors = Errors?.Trim();
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

        #region Data validation

        public readonly string[] ValidatesProperties =
        {
            nameof(ProjectName),
            nameof(StartDate),
            nameof(EndDate),
        };

        public override string Validate(string propertyName)
        {
            if(!DoValidation)
                return null;

            switch (propertyName)
            {
                case nameof(ProjectName):
                    if(ProjectName.IsNullOrWhiteSpace())
                        return string.Format(Constants.FieldMustBeFilledMessageFormat, nameof(ProjectName));
                    else if(!ProjectName.IsLengthBetween(3, 100))
                        return string.Format(Constants.LengthErrorMessageFormat, nameof(ProjectName), 3, 100);
                    break;

                case nameof(StartDate):
                    if(StartDate.IsNullOrWhiteSpace())
                        return string.Format(Constants.FieldMustBeFilledMessageFormat, nameof(StartDate));
                    else if(DateTime.Parse(StartDate) < new DateTime(2000, 1, 1))
                        return Constants.DateMustBeCorrectMessage;
                    else if (!StillGoes && !EndDate.IsNullOrWhiteSpace() &&
                             DateTime.Parse(StartDate) > DateTime.Parse(EndDate))
                        return string.Format(Constants.FieldMustBeLessThan, nameof(StartDate), nameof(EndDate));
                    break;

                case nameof(EndDate):
                    if(!StillGoes  && EndDate.IsNullOrWhiteSpace())
                        return string.Format(Constants.FieldMustBeFilledMessageFormat, nameof(EndDate));
                    else if(!StillGoes && DateTime.Parse(EndDate) < new DateTime(2000, 1, 1))
                        return Constants.DateMustBeCorrectMessage;
                    break;
            }
            return null;
        }
        
        #endregion
    }
}
