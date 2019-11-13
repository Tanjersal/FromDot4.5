using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SportsStore.Models.ViewModels;

namespace SportsStore.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<IdentityUser> userManager;
        private SignInManager<IdentityUser> signInManager;

        public AccountController(UserManager<IdentityUser> userM, SignInManager<IdentityUser> signIn)
        {
            userManager = userM;
            signInManager = signIn;
        }

        /// <summary>
        /// Login controller
        /// </summary>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        /// 
        [AllowAnonymous]
        public ViewResult Login(string returnUrl)
        {
            return View(new LoginViewModel()
            {
               ReturnUrl = returnUrl
            });
        }

        /// <summary>
        /// Login - POST
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        /// 
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel viewModel)
        {
            if(ModelState.IsValid)
            {
                IdentityUser user = await userManager.FindByNameAsync(viewModel.Name);
                if(user != null)
                {
                    await signInManager.SignOutAsync();
                    if((await signInManager.PasswordSignInAsync(user, viewModel.Password, false, false))
                        .Succeeded)
                    {
                        return Redirect(viewModel?.ReturnUrl ?? "/Admin/Index");
                    }
                }
            }

            ModelState.AddModelError("", "Invalida name or password");
            return View(viewModel);
            
        }


        /// <summary>
        /// Log out
        /// </summary>
        /// <param name="returnUrl">redirect url</param>
        /// <returns></returns>
        public async Task<IActionResult> LogOut(string returnUrl = "/")
        {
            await signInManager.SignOutAsync();
            return Redirect(returnUrl);
        }
        
    }
}