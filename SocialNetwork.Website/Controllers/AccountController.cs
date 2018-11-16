using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Core.Models;
using SocialNetwork.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.Website.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILoginManager loginManager;

        public AccountController(ILoginManager loginManager)
        {
            this.loginManager = loginManager;
        }

        [HttpGet]
        public IActionResult Login(string returnUrl) => View(new Login { ReturnURL = returnUrl });

        [HttpPost]
        public async Task<IActionResult> Login(Login login)
        {
            if (await loginManager.LoginAsync(login)) return Redirect(login.ReturnURL);
            else return this.ValidateAndView(login);
        }

        [HttpGet]
        public IActionResult SignUp(string returnUrl) => View(new SignUp { ReturnURL = returnUrl });

        [HttpPost]
        public async Task<IActionResult> SignUp(SignUp signUp)
        {
            if (await loginManager.SignUp(signUp)) return Redirect(signUp.ReturnURL);
            else return this.ValidateAndView(signUp);
        }

    }
}
