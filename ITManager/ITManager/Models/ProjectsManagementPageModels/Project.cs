using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITManager.Models.ProjectsManagementPageModels
{
    public class Project : INotifyPropertyChanged
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public System.DateTime StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public string Description { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
