using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ITManager.Models.UserPageModel
{
    public partial class UserRole : INotifyPropertyChanged
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }
    
        public virtual Role Role { get; set; }
        public virtual User User { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
