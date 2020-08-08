using IdentityRoleManagment.Areas.Admin.Models;
using IdentityRoleManagment.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace IdentityRoleManagment.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class HomeController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public HomeController(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }

        public IActionResult CreateRole(RoleViewModel roleView)
        {
            if (ModelState.IsValid)
            {
                IdentityRole identityRole = new IdentityRole()
                {
                    Name = roleView.RoleName
                };

                var result = roleManager.CreateAsync(identityRole).Result;

                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }

            return View(roleView);
        }

        [HttpGet]
        public IActionResult GetAllRoles()
        {
            var roles = roleManager.Roles.ToList();

            return View(roles);
        }

        [HttpGet]
        public IActionResult EditUserRoles()
        {
            var result = new EditUserRolesViewModel();
            var users = userManager.Users.ToList();

            foreach (var user in users)
            {
                var roleResult = userManager.IsInRoleAsync(user,"Admin").Result;

                AddRoleToUserViewModel EditUserRolesViewModel = new AddRoleToUserViewModel()
                {
                    User = user,
                    IsInRole = roleResult
                };

                result.RoleToUser.Add(EditUserRolesViewModel);
            }

            return View(result);
        }

        [HttpPost]
        public IActionResult EditUserRoles(AddRoleToUserViewModel addRoleToUserViewModel)
        {
            if (true)
            {
                var user = userManager.FindByNameAsync("").Result;

                if (user != null)
                {
                    var result = userManager.AddToRoleAsync(user, "Admin").Result;

                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }
                }
            }

            return View();
        }

    }
}