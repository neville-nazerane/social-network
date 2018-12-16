using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using SocialNetwork.Core.Entities;
using SocialNetwork.Services;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.WebHelper
{
    class LoginContext : ILoginContext
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly IHttpContextAccessor httpContextAccessor;

        public LoginContext(
                            UserManager<User> userManager,
                            SignInManager<User> signInManager,
                            IHttpContextAccessor httpContextAccessor
            )
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.httpContextAccessor = httpContextAccessor;
        }

        HttpContext HttpContext => httpContextAccessor.HttpContext;

        ClaimsPrincipal User => HttpContext.User;

        public int UserId => int.Parse(userManager.GetUserId(User));

        public string UserName => userManager.GetUserName(User);

        public async Task RegisterLoginAsync(User user)
            => await signInManager.SignInAsync(user, true);
    }
}
