using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebProject.Models.Users;
using WebProject.ViewModels;

namespace WebProject.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<User> userManager { get; }
        private SignInManager<User> signInManager { get; }
        public AccountController(UserManager<User> usermanager, SignInManager<User> signinmanager)
        {

            userManager = usermanager;
            signInManager = signinmanager;
        }
        public IActionResult Login() => View();
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model) {

            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(model.Email);
                var result = await signInManager.PasswordSignInAsync(user, model.Password, model.IsPersistent,false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Неккоректный логин или пароль");
                }
            }
            return View(model);
        }
        public IActionResult Register() => View();
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = new User
                {
                    UserName = model.UserName,
                    SurName = model.SurName,
                    Age = model.Age,
                    Email = model.Email,
                    Location = $"{model.Country},{model.City}",
                    PhoneNumber = model.PhoneNumber
                };
                var result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await userManager.AddClaimsAsync(user, new List<System.Security.Claims.Claim> {
                        new System.Security.Claims.Claim(System.Security.Claims.ClaimTypes.Email,model.Email)});
                    await signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Home");
                }
                else {
                    foreach (var item in result.Errors) {
                        ModelState.AddModelError("", item.Description);
                    } 
                }
            }           
            return View(model);
            }
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index","Home");
        }
    }
}