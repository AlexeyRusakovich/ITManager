using ITManager.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITManager.Models
{
    public class UserAccountManagementModel : BaseViewModel
    {
        public UserAccountManagementModel() : base("")
        {
        }

        public string Login { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }

        private string _defaultPassword;
        public string DefaultPassword
        {
            get
            {
                return _defaultPassword;
            }

            set
            {
               Set(ref _defaultPassword, value);
            }
        }

        private bool _isInitial;
        public bool IsInitial
        {
            get
            {
                return _isInitial;
            }

            set
            {
               Set(ref _isInitial, value);
            }
        }
    }
}
