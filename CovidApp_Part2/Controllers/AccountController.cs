using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CovidApp_Part2.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CovidApp_Part2.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<IdentityUser> _userManager;
        private SignInManager<IdentityUser> _signInManager;
        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Login(string returnUrl)
        {
            return View(new LoginModel
            {
                ReturnUrl = returnUrl
            });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                await _signInManager.SignOutAsync();
                IdentityUser user =
                await _userManager.FindByEmailAsync(loginModel.Email);
                if (user != null)
                {
                    var result = await _signInManager.PasswordSignInAsync(user,
                    loginModel.Password, false, false);
                    if (result.Succeeded)
                    {
                        return Redirect(loginModel?.ReturnUrl ?? "/Home/Index");
                    }
                }
            }
            ModelState.AddModelError("", "Invalid email or password");
            return View(loginModel);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
