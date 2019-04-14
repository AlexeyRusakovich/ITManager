using ITManager.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ITManager.Models
{
    public class UserRoleManagementModel : BaseViewModel
    {
        public UserRoleManagementModel() : base("")
        {
        }

        public string Login { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        private int roleId { get ; set; }
        public int RoleId
        {
            get
            {
                 return roleId;
            }
            set
            {
                roleId = value;
                if(roleId != DefaultRoleId)
                {                    
                    HasChanges = true;
                    RaisePropertyChanged(nameof(HasChanges));
                }
                else
                {
                    HasChanges = false;
                    RaisePropertyChanged(nameof(HasChanges));
                }
            }
        }
        public int DefaultRoleId { get; set;}
        public bool HasChanges { get; set; }
    }
}
