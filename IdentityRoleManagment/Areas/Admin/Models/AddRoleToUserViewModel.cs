using IdentityRoleManagment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityRoleManagment.Areas.Admin.Models
{
    public class AddRoleToUserViewModel
    {
        public ApplicationUser User { get; set; }
        public bool IsInRole { get; set; }

    }
}
