using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ITManager.Models.UserPageModel
{
    
    public partial class Query : INotifyPropertyChanged
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string QueryString { get; set; }
        public string Description { get; set; }
   

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
