using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ITManager.Models.UserPageModel
{
    
    public partial class LanguageLevel : INotifyPropertyChanged
    {
        public LanguageLevel()
        {
            this.Languages = new HashSet<Language>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<Language> Languages { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
