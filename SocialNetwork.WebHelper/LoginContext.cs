using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using SocialNetwork.Core.Entities;
using SocialNetwork.Services;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace SocialNetwork.WebHelper
{
    class LoginContext : ILoginContext
    {
        private readonly UserManager<User> userManager;
        private readonly IHttpContextAccessor httpContextAccessor;

        public LoginContext(
                            UserManager<User> userManager,
                            IHttpContextAccessor httpContextAccessor
            )
        {
            this.userManager = userManager;
            this.httpContextAccessor = httpContextAccessor;
        }

        HttpContext HttpContext => httpContextAccessor.HttpContext;

        ClaimsPrincipal User => HttpContext.User;

        public int UserId => int.Parse(userManager.GetUserId(User));

        public string UserName => userManager.GetUserName(User);


    }
}
