using SocialNetwork.Core.Entities;
using SocialNetwork.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.Services.Repositories
{
    interface IDisplayUserRepository
    {

        DisplayUser Add(DisplayUserAdd displayUser);

        DisplayUser Update(DisplayUserUpdate displayUser);

        DisplayUser Get(int id);

    }
}
