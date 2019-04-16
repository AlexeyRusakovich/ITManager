using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ITManager.Models.UserPageModel
{
    
    public partial class ProfessionalSummary : INotifyPropertyChanged
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string ProfessionalSummary1 { get; set; }
    
        public virtual User User { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
