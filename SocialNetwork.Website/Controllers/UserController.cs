using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SocialNetwork.Services;
using SocialNetwork.Services.Repositories;
using SocialNetwork.Core.Models;
using SocialNetwork.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using SocialNetwork.Website.Models;

namespace SocialNetwork.Website.Controllers
{

    [Authorize]
    public class UserController : Controller
    {
        private readonly IDisplayUserRepository userRepository;
        private readonly IFriendManager friendManager;

        public UserController(IDisplayUserRepository userRepository, 
                                IFriendManager friendManager)
        {
            this.userRepository = userRepository;
            this.friendManager = friendManager;
        }

        [Route("[controller]/{id}"), HttpGet]
        public IActionResult Index(int id) => View(new UserViewModel {
            User = userRepository.Get(id),
            FriendStatus = friendManager.GetStatus(id)
        });

        public IActionResult AddRequest(int id)
        {
            friendManager.Request(id);
            return RedirectToIndex(id);
        }

        public IActionResult AcceptRequest(int id, int requestId)
        {
            friendManager.Accept(requestId);
            return RedirectToIndex(id);
        }

        IActionResult RedirectToIndex(int id) => RedirectToAction(nameof(Index), new { id });

    }
}
