using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityRoleManagment.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityRoleManagment.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginView)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(
                    loginView.Username, 
                    loginView.Password, 
                    loginView.RememberMe, 
                    false);

                if (result.Succeeded)
                {                    
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Username or password is not correct");
                }   
            }

            return View(loginView);
        }

        [HttpGet]
        public IActionResult LogOut()
        {
            signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerView)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser applicationUser = new ApplicationUser()
                {
                    Email = registerView.Email,
                    UserName = registerView.Email,
                    Birthdate = registerView.BirthDate
                };

                var result = userManager.CreateAsync(applicationUser, registerView.Password).Result;

                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(applicationUser, false);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }

            return View(registerView);
        }
    }
}