using SocialNetwork.Core.Entities;
using SocialNetwork.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.TestSimulations
{
    class LoginContext : ILoginContext
    {

        public User User { get; set; }

        public int UserId => User.Id;

        public string UserName => User.UserName;

        public void RegisterLogin(User user) => User = user;

    }
}
