using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SocialNetwork.Services;
using SocialNetwork.Services.Repositories;
using Microsoft.AspNetCore.Authorization;

namespace SocialNetwork.Website.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILoginManager loginManager;
        private readonly IDisplayUserRepository displayUserRepository;

        public AccountController(ILoginManager loginManager, IDisplayUserRepository displayUserRepository)
        {
            this.loginManager = loginManager;
            this.displayUserRepository = displayUserRepository;
        }

        [Authorize]
        public IActionResult Index() => View(displayUserRepository.GetCurrent());

        [HttpGet]
        public IActionResult Login() => View();

        [HttpPost]
        public async Task<IActionResult> Login(Login login)
        {
            if (!ModelState.IsValid) return View(login);
            if (await loginManager.LoginAsync(login)) return Redirect("~/");
            else return this.ValidateAndView(login);
        }

        [HttpGet]
        public IActionResult SignUp() => View();

        [HttpPost]
        public async Task<IActionResult> SignUp(SignUp signUp)
        {
            if (!ModelState.IsValid) return View(signUp);
            if (await loginManager.SignUpAsync(signUp))
            {
                if (string.IsNullOrEmpty(signUp.ReturnURL)) return Redirect("~/");
                else return Redirect("~" + signUp.ReturnURL);
            }
            else return this.ValidateAndView(signUp);
        }

    }
}
