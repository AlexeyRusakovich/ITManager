using System;
using System.ComponentModel;

namespace ITManager.Models.UserPageModel
{
    public partial class Education : INotifyPropertyChanged
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public System.DateTime StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public string University { get; set; }
        public string Faculty { get; set; }
        public string Speciality { get; set; }
    
        public virtual User User { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
