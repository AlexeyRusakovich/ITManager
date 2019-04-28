using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITManager.Models.SearchPageModels
{
    public class SearchedUserModel : INotifyPropertyChanged
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Persent { get; set; }

        public IDictionary<SkillCondition, bool> SkillsConditions { get; set; }
        public IDictionary<LanguageCondition, bool> LanguagesConditions { get; set; }
        public IDictionary<Models.ProjectsManagementPageModels.Project, bool> ProjectsConditions { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
