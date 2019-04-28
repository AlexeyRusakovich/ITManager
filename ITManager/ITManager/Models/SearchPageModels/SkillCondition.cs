using ITManager.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITManager.Models.SearchPageModels
{
    public class SkillCondition : INotifyPropertyChanged
    {
        public Models.UserPageModel.ProfessionalSkill Skill { get; set; }

        public SkillLevel From { get; set; }

        public SkillLevel To { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
