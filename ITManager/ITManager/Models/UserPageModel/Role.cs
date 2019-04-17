using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ITManager.Models.UserPageModel
{
    
    public partial class Role : INotifyPropertyChanged
    {
        public Role()
        {
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
    


        public event PropertyChangedEventHandler PropertyChanged;
    }
}
