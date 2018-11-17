using SocialNetwork.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Services
{
    public interface ILoginManager
    {

        Task<bool> SignUpAsync(SignUp signUp);

        Task<bool> LoginAsync(Login login);

    }
}
