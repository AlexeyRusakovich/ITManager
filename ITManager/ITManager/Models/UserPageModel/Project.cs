using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ITManager.Models.UserPageModel
{
    public partial class Project : INotifyPropertyChanged
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public System.DateTime StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public int PositionId { get; set; }
        public string Description { get; set; }
    
        public virtual Position Position { get; set; }
        public virtual User User { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
