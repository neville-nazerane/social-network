using SocialNetwork.Core.Entities;
using SocialNetwork.Core.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.Services.Repositories
{
    public interface IDisplayUserRepository
    {

        DisplayUser GetCurrent();

        DisplayUser Update(DisplayUserUpdate displayUser);

        IEnumerable<DisplayUser> Search(DisplayUserSearch search);
        IEnumerable<DisplayUser> Get();
    }
}
