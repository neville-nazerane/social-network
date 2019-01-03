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
        private readonly IFriendManager friendManager;

        public ProfileController(IDisplayUserRepository repository, IFriendManager friendManager)
        {
            this.repository = repository;
            this.friendManager = friendManager;
        }

        [HttpGet]
        public IActionResult Index() => View(repository.GetCurrentUpdate());

        [HttpPost]
        public IActionResult Index(DisplayUserUpdate user)
        {
            if (!ModelState.IsValid) return View(user);
            var updated = repository.UpdateCurrent(user);
            this.UpdateValidations();
            return View(user);
        }

        public IActionResult Friends() => View(friendManager.List());

    }

}
