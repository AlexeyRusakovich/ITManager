using System;
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
        public static string SkillsManagementView => "SkillsManagementView";
        public static string ProjectsManagementView => "ProjectsManagementView";
        public static string DefaultSearchView => "DefaultSearchView";


        public static string MenuView => "MenuView";
        public static string ShellView => "ShellView";

        #endregion

        #region Validation messages

        public const string DateMustBeCorrectMessage = "Date must be correct.";

        public const string FieldMustBeFilledMessageFormat = "'{0}' field is required.";

        public const string LengthErrorMessageFormat= "The length of '{0}' must be from {1} to {2}.";

        #endregion
    }
}
