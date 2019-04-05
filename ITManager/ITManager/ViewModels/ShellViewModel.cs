using ITManager.ViewModels.Base;
using Prism.Events;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITManager.ViewModels
{
    public class ShellViewModel : BaseViewModel
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly IRegionManager _regionManager;

        public ShellViewModel(IEventAggregator eventAggregator, IRegionManager regionManager) : base("Shell")
        {
            _eventAggregator = eventAggregator;
            _regionManager = regionManager;
        }
    }
}
