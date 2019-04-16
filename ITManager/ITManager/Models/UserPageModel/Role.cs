using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ITManager.Models.UserPageModel
{
    
    public partial class Role : INotifyPropertyChanged
    {
        public Role()
        {
            this.UserRoles = new HashSet<UserRole>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<UserRole> UserRoles { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
