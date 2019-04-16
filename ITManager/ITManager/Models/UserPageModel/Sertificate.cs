using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ITManager.Models.UserPageModel
{
    
    public partial class Sertificate : INotifyPropertyChanged
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public System.DateTime Date { get; set; }
        public string Name { get; set; }
    
        public virtual User User { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
