using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITManager.Interfaces
{
    public interface INavigationService
    {
        void NavigateTo(string viewName);
        void NavigateToWithParameters(string viewName, string regionName = null, NavigationParameters navigationParameters = null);
    }
}
