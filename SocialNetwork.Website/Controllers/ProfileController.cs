using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SocialNetwork.Services;
using SocialNetwork.Services.Repositories;
using SocialNetwork.Core.Models;
using Microsoft.AspNetCore.Authorization;

namespace SocialNetwork.Website.Controllers
{

    [Authorize]
    public class ProfileController : Controller
    {
        private readonly IDisplayUserRepository repository;

        public ProfileController(IDisplayUserRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IActionResult Index() => View(repository.GetCurrent());

        [HttpPost]
        public IActionResult Index(DisplayUserUpdate user)
        {
            if (!ModelState.IsValid) return View(user);
            var updated = repository.UpdateCurrent(user);
            this.UpdateValidations();
            return View(user);
        }

    }

}
