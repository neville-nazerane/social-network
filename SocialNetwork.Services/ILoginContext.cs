using SocialNetwork.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Services
{
    public interface ILoginContext
    {

        int UserId { get; }

        string UserName { get; }

        Task RegisterLoginAsync(User user);

    }
}
