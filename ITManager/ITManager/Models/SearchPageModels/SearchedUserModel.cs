using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITManager.Models.SearchPageModels
{
    public class SearchedUserModel : INotifyPropertyChanged
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Persent { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
