using ITManager.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITManager.Models.SearchPageModels
{
    public class LanguageCondition : INotifyPropertyChanged
    {
        public Models.UserPageModel.LanguagesList Language { get; set; }

        public LanguageLevel From { get; set; }

        public LanguageLevel To { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
