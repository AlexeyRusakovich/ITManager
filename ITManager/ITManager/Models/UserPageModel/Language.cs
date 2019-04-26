using System;
using System.ComponentModel;

namespace ITManager.Models.UserPageModel
{
    
    public partial class Language : INotifyPropertyChanged
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int LanguageId { get;set;}
        public int LanguageLevelId { get; set; }

        public ITManager.Database.LanguagesList RelatedLanguage { get; set;}

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
