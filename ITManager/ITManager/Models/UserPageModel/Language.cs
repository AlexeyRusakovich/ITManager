using System;
using System.ComponentModel;

namespace ITManager.Models.UserPageModel
{
    
    public partial class Language : INotifyPropertyChanged
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public int LanguageLevelId { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
