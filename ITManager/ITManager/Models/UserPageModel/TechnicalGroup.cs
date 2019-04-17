using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ITManager.Models.UserPageModel
{
    public partial class TechnicalGroup : INotifyPropertyChanged
    {
        public TechnicalGroup()
        {
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
    

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
