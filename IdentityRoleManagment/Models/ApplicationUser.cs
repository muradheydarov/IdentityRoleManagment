using Microsoft.AspNetCore.Identity;
using System;

namespace IdentityRoleManagment.Models
{
    public class ApplicationUser : IdentityUser
    {   
        public DateTime Birthdate { get; set; }
    }
}
