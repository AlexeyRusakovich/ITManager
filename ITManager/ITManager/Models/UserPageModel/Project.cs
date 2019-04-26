using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ITManager.Models.UserPageModel
{
    public partial class Project : INotifyPropertyChanged
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int UserId { get; set; }
        public int PositionId { get; set; }
        public string Comment { get; set; }

        public ITManager.Database.Project RelatedProject { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
