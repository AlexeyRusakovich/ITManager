using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITManager.Interfaces;

namespace ITManager.Helpers
{
    public class NavigationService : INavigationService
    {
        private readonly IRegionManager _regionManager;
        public NavigationService(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }
        public void NavigateTo(string viewName)
        {
            _regionManager.NavigateTo(viewName);
        }

        public void NavigateToWithParameters(string viewName, string regionName = null, NavigationParameters navigationParameters = null)
        {
            _regionManager.NavigateToWithParameters(viewName, regionName, navigationParameters);
        }
    }
}
