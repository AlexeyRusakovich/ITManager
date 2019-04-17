using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ITManager.Models.UserPageModel
{
    
    public partial class User : INotifyPropertyChanged
    {
        public User()
        {
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public System.DateTime Birthday { get; set; }
        public int PositionId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public bool IsInitial { get; set; }
        public string DefaultPassword { get; set; }
    

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
