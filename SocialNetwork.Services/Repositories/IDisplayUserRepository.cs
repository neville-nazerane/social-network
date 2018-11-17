using SocialNetwork.Core.Entities;
using SocialNetwork.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.Services.Repositories
{
    public interface IDisplayUserRepository 
            : IGenericRepository<DisplayUser, SignUp, DisplayUserUpdate>
    {

    }
}
