using SocialNetwork.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.Services
{
    public interface ILoginContext
    {

        int UserId { get; }

        string UserName { get; }

        void RegisterLogin(User user);

    }
}
