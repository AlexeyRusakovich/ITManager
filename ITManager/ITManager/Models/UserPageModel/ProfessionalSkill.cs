using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ITManager.Models.UserPageModel
{
    
    public partial class ProfessionalSkill : INotifyPropertyChanged
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsChecked { get; set;}

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
