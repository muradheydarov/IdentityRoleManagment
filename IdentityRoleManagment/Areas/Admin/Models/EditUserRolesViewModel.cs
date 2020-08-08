using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityRoleManagment.Areas.Admin.Models
{
    public class EditUserRolesViewModel
    {
        public EditUserRolesViewModel()
        {
            RoleToUser = new List<AddRoleToUserViewModel>();
        }
        public List<AddRoleToUserViewModel> RoleToUser { get; set; }
    }
}
