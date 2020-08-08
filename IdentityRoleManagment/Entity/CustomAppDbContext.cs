using IdentityRoleManagment.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdentityRoleManagment.Entity
{
    public class CustomAppDbContext : IdentityDbContext<ApplicationUser>
    {
        public CustomAppDbContext(DbContextOptions<CustomAppDbContext> dbContextOptions)
            :base(dbContextOptions)
        {
        }
    }
}
