using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ITManager.Models.UserPageModel
{
    
    public partial class SkillLevel : INotifyPropertyChanged
    {
        public SkillLevel()
        {
            this.UserSkills = new HashSet<UserSkill>();
        }
    
        public int Id { get; set; }
        public string Level { get; set; }
    
        public virtual ICollection<UserSkill> UserSkills { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
