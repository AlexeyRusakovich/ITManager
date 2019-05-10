using AutoMapper;
using ITManager.Database;
using ITManager.Helpers;
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
    public class SkillsManagementViewModel : BaseViewModel, INavigationAware
    {
        public ObservableCollection<Models.UserPageModel.ProfessionalSkill> Skills { get; set; }

        public string SkillName { get; set; }
        public ICommand SaveSkills { get; set;}
        public ICommand ResetSkills { get; set;}
        public ICommand RemoveSkill { get; set; }
        public ICommand AddSkill { get; set; }

        public SkillsManagementViewModel() : base("Skills management")
        {
            ResetSkills = new DelegateCommand(FillSkills);
            SaveSkills = new DelegateCommand(SaveSkillsMethod);
            RemoveSkill = new DelegateCommand<Models.UserPageModel.ProfessionalSkill>(RemoveSkillMethod);
            AddSkill = new DelegateCommand<string>(AddSkillMethod);
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            return;
        }

        private async void FillSkills()
        {
            using (var _database = new ITManagerEntities())
            {                
                Skills = new ObservableCollection<Models.UserPageModel.ProfessionalSkill>(Mapper.Map<IList<ProfessionalSkill>, IList<Models.UserPageModel.ProfessionalSkill>>(await _database.ProfessionalSkills.ToListAsync()));
            }
        }

        private async void SaveSkillsMethod()
        {
            using (var _database = new ITManagerEntities())
            {
                var skills = await _database.ProfessionalSkills.ToListAsync();

                foreach (var skill in skills)
                {
                    var _skill = Skills.FirstOrDefault(s => s.Id == skill.Id);
                    if(_skill != null)
                    {
                        skill.Name = _skill.Name;
                    }
                    else
                    {
                        _database.ProfessionalSkills.Remove(skill);
                    }                    
                }

                foreach (var skill in Skills.Where(s => s.Id == 0))
                {
                    _database.ProfessionalSkills.Add(new ProfessionalSkill
                    {
                        Name = skill.Name
                    });
                }
                
                await _database.SaveChangesAsync();  
                FillSkills();
            }
        }

        private void RemoveSkillMethod(Models.UserPageModel.ProfessionalSkill skill)
        {
            Skills.Remove(skill);
        }

        private void AddSkillMethod(string skillName)
        {
            string errors = null;
            if(IsValid(ValidatesProperties, out errors))
            {
                Errors = errors;
                using (var _database = new ITManagerEntities())
                {
                    if (!_database.ProfessionalSkills.Any(s => s.Name == SkillName))
                    {
                        Skills.Add(new Models.UserPageModel.ProfessionalSkill
                        {
                            Name = skillName
                        });
                    }
                    else
                        Errors = "This skill is already exists.";
                }                    
            }
            else
            {
                Errors = errors;
            }

            Errors = Errors?.Trim();            
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            FillSkills();
        }     
        
        #region Data validation

        public readonly string[] ValidatesProperties =
        {
            nameof(SkillName)
        };

        public override string Validate(string propertyName)
        {
            if(!DoValidation)
                return null;

            switch (propertyName)
            {
                case nameof(SkillName):
                    if(SkillName.IsNullOrWhiteSpace())
                        return string.Format(Constants.FieldMustBeFilledMessageFormat, nameof(SkillName));
                    else if(!SkillName.IsLengthBetween(2, 50))
                        return string.Format(Constants.LengthErrorMessageFormat, nameof(SkillName), 2, 50);
                    break;
            }

            return null;
        }
        
        #endregion
    }
}
