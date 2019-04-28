using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using System.Windows;
using Prism.Unity;
using ITManager.Helpers;
using ITManager.Views;
using Prism.Events;
using ITManager.Interfaces;
using Prism.Regions;

namespace ITManager
{
    public class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<ShellView>();
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();
            App.Current.MainWindow = (Window)Shell;
            App.Current.MainWindow.Show();
        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();

            Container.RegisterType<IEventAggregator, EventAggregator>(new ContainerControlledLifetimeManager());
            Container.RegisterType<INavigationService, NavigationService>(new ContainerControlledLifetimeManager());

            Container.RegisterTypeForNavigation<ShellView>(Constants.ShellView);
            Container.RegisterTypeForNavigation<LoginView>(Constants.LoginView);
            Container.RegisterTypeForNavigation<RegisterView>(Constants.RegisterView);
            Container.RegisterTypeForNavigation<RolesManagementView>(Constants.RolesManagementView);
            Container.RegisterTypeForNavigation<AccountsManagementView>(Constants.AccountsManagementView);
            Container.RegisterTypeForNavigation<ChangePasswordView>(Constants.ChangePasswordView);
            Container.RegisterTypeForNavigation<MyPersonalPageView>(Constants.MyPersonalPageView);
            Container.RegisterTypeForNavigation<QueriesView>(Constants.QueriesView);
            Container.RegisterTypeForNavigation<SearchView>(Constants.SearchView);
            Container.RegisterTypeForNavigation<SkillsManagementView>(Constants.SkillsManagementView);
            Container.RegisterTypeForNavigation<ProjectsManagementView>(Constants.ProjectsManagementView);
            Container.RegisterTypeForNavigation<DefaultSearchView>(Constants.DefaultSearchView);
        }
    }
}
