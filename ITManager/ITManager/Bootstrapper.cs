using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using System.Windows;
using Prism.Unity;
using ITManager.Helpers;
using Prism.Events;

namespace ITManager
{
    public class Bootstrapper : UnityBootstrapper
    {
        public override void Run(bool runWithDefaultConfiguration)
        {
            base.Run(runWithDefaultConfiguration);
        }

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
            //Container.RegisterType<IKeyboardCommandListener, KeyboardCommandListener>(new ContainerControlledLifetimeManager());
            //Container.RegisterType<IGlobalKeyBoardHook, GlobalKeyboardHook>(new ContainerControlledLifetimeManager());
            //Container.RegisterType<INavigationService, NavigationService>(new ContainerControlledLifetimeManager());
            //Container.RegisterType<IActionManager, ActionManager>(new ContainerControlledLifetimeManager());

            //#region Registering actions

            //Container.RegisterType<ActionBase, ShowHideWindowAction>(Constants.ShowHideWindowActionGuid.ToString());

            //#endregion

            Container.RegisterTypeForNavigation<ShellView>(Constants.MainView);
            //Container.RegisterTypeForNavigation<MenuView>(Constants.MenuView);
            //Container.RegisterTypeForNavigation<SettingsView>(Constants.SettingsView);
            //Container.RegisterTypeForNavigation<ShortcutsView>(Constants.ShortcutsView);
        }
    }
}
