using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ITManager.Models.UserPageModel
{
    public partial class TechnicalGroup : INotifyPropertyChanged
    {
        public TechnicalGroup()
        {
            this.ProfessionalSkills = new HashSet<ProfessionalSkill>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<ProfessionalSkill> ProfessionalSkills { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
