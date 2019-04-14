using ITManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ITManager.AttachedProperties
{
    public static class UserRolesAttachedProperties
    {


        public static string GetRequiredRoles(DependencyObject obj)
        {
            return (string)obj.GetValue(RequiredRolesProperty);
        }

        public static void SetRequiredRoles(DependencyObject obj, string value)
        {
            obj.SetValue(RequiredRolesProperty, value);
        }
        
        public static readonly DependencyProperty RequiredRolesProperty =
            DependencyProperty.RegisterAttached("RequiredRoles", typeof(string), typeof(UserRolesAttachedProperties), new PropertyMetadata(null, OnRolesChanged));

        private static void OnRolesChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (ShellViewModel.CurrentUser != null)
            {
                if(((string)e.NewValue).Split(',').ToList().Contains(ShellViewModel.CurrentUser.UserRoles.FirstOrDefault().RoleId.ToString()))
                {
                    ((Button)d).Visibility = Visibility.Visible;
                }
                else
                {
                    ((Button)d).Visibility = Visibility.Collapsed;
                }
            }
        }
    }
}
