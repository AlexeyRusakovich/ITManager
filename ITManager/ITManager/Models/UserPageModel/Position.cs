using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ITManager.Models.UserPageModel
{
    public partial class Position : INotifyPropertyChanged
    {
        public Position()
        {
            this.Projects = new HashSet<Project>();
            this.Users = new HashSet<User>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<Project> Projects { get; set; }
        public virtual ICollection<User> Users { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
