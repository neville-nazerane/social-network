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

        DisplayUser Get(int id);

        DisplayUser GetCurrent();
        DisplayUserUpdate GetCurrentUpdate();

        DisplayUser UpdateCurrent(DisplayUserUpdate displayUser);

        IEnumerable<DisplayUser> Get();

        IEnumerable<DisplayUser> Search(DisplayUserSearch search);
        IEnumerable<DisplayUser> Search(string q);
    }
}
