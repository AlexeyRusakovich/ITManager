using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITManager.Helpers
{
    public static class NavigationHelper
    {
        public static void NavigateTo(this IRegionManager regionManager, string pageName)
        {
            NavigateToWithParameters(regionManager, pageName);
        }
        public static void NavigateToWithParameters(this IRegionManager regionManager, string pageName, string regionName = null, NavigationParameters navigationParameters = null)
        {
            if (regionManager == null || pageName == null)
                return;

            regionManager.RequestNavigate(regionName ?? Constants.MainRegion, pageName, navigationParameters);
        }
    }
}
