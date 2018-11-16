using SocialNetwork.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Services
{
    public interface ILoginManager
    {

        int UserId { get; }

        string UserName { get; }

        Task<bool> SignUp(SignUp signUp);

        Task<bool> LoginAsync(Login login);

    }
}
