using AutoMapper;
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
        private readonly IMapper mapper;
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IMapper mapper) {
            this.userManager = userManager; 
            this.signInManager = signInManager; 
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel) {
            try {
                if (ModelState.IsValid) {
                    ApplicationUser user = new ApplicationUser {
                        UserName = registerViewModel.Email,
                        Email = registerViewModel.Email,
                        PhoneNumber = registerViewModel.PhoneNumber,
                        FirstName = registerViewModel.FirstName,
                        LastName = registerViewModel.LastName,
                        Address1 = registerViewModel.Address2,
                        PostCode = registerViewModel.PostCode,
                    };
                    var res = await userManager.CreateAsync(user, registerViewModel.Password);

                    if (res.Succeeded) {
                        registerViewModel.RegistrationInValid = "";
                        await signInManager.SignInAsync(user, false);
                        return PartialView("_UserRegistrationPartial", registerViewModel);
                    }

                    if (res.Errors is not null) {
                        foreach (var error in res.Errors) {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }
                }
            } catch (Exception ex) {
                throw;
            }
            return PartialView("_UserRegistrationPartial", registerViewModel);
        }
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel) {
            if (ModelState.IsValid) {
                var res = await signInManager.PasswordSignInAsync(
                userName: loginViewModel.Email,
                password: loginViewModel.Password,
                isPersistent: loginViewModel.RememberMe,
                lockoutOnFailure: false
                );

                if (res.Succeeded) {
                    loginViewModel.LoginInValid = "";
                } else {
                    ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
                }
            }
            return PartialView("_UserLoginPartial");
        }
        [AllowAnonymous]
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout(string returnUrl = null){
            await signInManager.SignOutAsync();
            return (returnUrl is not null) ? LocalRedirect(returnUrl) : (RedirectToAction("Index","Home"));
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