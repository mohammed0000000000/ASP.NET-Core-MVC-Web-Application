using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using TechWebApplication.Models.Auth;
using TechWebApplication.Services.ViewModel;

namespace TechWebApplication.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager) {
            this.userManager = userManager; 
            this.signInManager = signInManager; 
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register() {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel) {
            if (ModelState.IsValid) {
                var res = await signInManager.PasswordSignInAsync(
                userName: loginViewModel.Email,
                password: loginViewModel.Password,
                isPersistent: loginViewModel.RememberMe,
                lockoutOnFailure: false
                );
                //var user = await userManager.FindByEmailAsync(loginViewModel.Email);
                //if (user is not null)
                //{
                //    var checkPassword = await userManager.CheckPasswordAsync(user, loginViewModel.Password);
                //    if(checkPassword){
                //        await signInManager.SignInAsync(user, loginViewModel.RememberMe);
                //    }
                //}

                if (res.Succeeded) {
                    loginViewModel.LoginInValid = "";
                } else {
                    ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
                }
            }
            return PartialView("_UserLoginPartial");
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout(string returnUrl = null){
            await signInManager.SignOutAsync();
            return (returnUrl is not null) ? LocalRedirect(returnUrl) : (RedirectToAction("Login","Home"));
        }
    }
}
/*
    Custom Login Dialog
    1) create the _UserLoginPartial => partial view
    2) Update the Login Menu
    3) create the 'Login Model' class
    4) create the Login form
    5) create the 'UserAuthController' Controller Class
    6) Write the jQuery and AJAX Client-side Code
 */