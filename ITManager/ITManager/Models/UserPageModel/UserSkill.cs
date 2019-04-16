using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ITManager.Models.UserPageModel
{
    public partial class UserSkill : INotifyPropertyChanged
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int SkillId { get; set; }
        public int SkillLevelId { get; set; }
    
        public virtual ProfessionalSkill ProfessionalSkill { get; set; }
        public virtual SkillLevel SkillLevel { get; set; }
        public virtual User User { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
