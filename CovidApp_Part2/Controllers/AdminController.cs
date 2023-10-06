using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CovidApp_Part2.Data;
using CovidApp_Part2.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CovidApp_Part2.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private UserManager<IdentityUser> _userManager;
        private RoleManager<IdentityRole> _roleManager; 
        private IUserValidator<IdentityUser> _userValidator;
        private IPasswordValidator<IdentityUser> _passwordValidator;
        private IPasswordHasher<IdentityUser> _passwordHasher;
        public AdminController(UserManager<IdentityUser> userManager,
                               RoleManager<IdentityRole> roleManager,
                               IUserValidator<IdentityUser> userValidator,
                               IPasswordValidator<IdentityUser> passwordValidator, 
                               IPasswordHasher<IdentityUser> passwordHasher)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _userValidator = userValidator;
            _passwordValidator = passwordValidator;
            _passwordHasher = passwordHasher;
        }
        public IActionResult Index()
        {
            return View(_userManager.Users.OrderBy(u => u.UserName));
        }

        public ViewResult Create()
        {
            PopulateCreateUserDDL();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = new IdentityUser
                {
                    UserName = model.Name,
                    Email = model.Email
                };
                IdentityRole role = new IdentityRole
                {
                    Name = model.RoleName
                };
                IdentityResult result
                    = await _userManager.CreateAsync(user, model.Password);


                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, role.Name);
                    return RedirectToAction("Index");
                }
                else
                {
                    AddErrorsFromResult(result);
                }
            }
            return View(model);
        }
        private void PopulateCreateUserDDL(object selectedRole = null)
        {
            ViewBag.RoleId = new SelectList(_roleManager.Roles, "Name", "Name", selectedRole);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            IdentityUser user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                IdentityResult result = await _userManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    AddErrorsFromResult(result);
                }
            }
            else
            {
                ModelState.AddModelError("", "No user found");
            }
            return View("Index", _userManager.Users.OrderBy(u => u.UserName));
        }

        private void AddErrorsFromResult(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
        }
    }
}
 