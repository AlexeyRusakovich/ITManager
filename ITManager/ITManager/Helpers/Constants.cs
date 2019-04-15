﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITManager.Helpers
{
    public static class Constants
    {
        #region Roles

        public const int AdministratorRole = 1;
        public const int ManagerRole = 2;
        public const int UserRole = 3;

        #endregion

        #region Region names

        public static string MenuRegion => "MenuRegion";
        public static string MainRegion => "MainRegion";

        #endregion

        #region View Names

        public static string RegisterView => "RegisterView";
        public static string LoginView => "LoginView";
        public static string MainView => "MainView";
        public static string QueriesView => "QueriesView";
        public static string RolesManagementView => "RolesManagementView";
        public static string AccountsManagementView => "AccountsManagementView";
        public static string ChangePasswordView => "ChangePasswordView";
        public static string SearchView => "SearchView";
        public static string MyPersonalPageView => "MyPersonalPageView";


        public static string MenuView => "MenuView";
        public static string ShellView => "ShellView";

        #endregion
    }
}
