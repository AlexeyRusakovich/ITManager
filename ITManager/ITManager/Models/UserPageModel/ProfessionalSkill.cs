using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ITManager.Models.UserPageModel
{
    
    public partial class ProfessionalSkill : INotifyPropertyChanged
    {
        public int Id { get; set; }
        public Nullable<int> ProfessionalGroupId { get; set; }
        public string Name { get; set; }
    
        public virtual TechnicalGroup TechnicalGroup { get; set; }
        public virtual UserSkill UserSkill { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
