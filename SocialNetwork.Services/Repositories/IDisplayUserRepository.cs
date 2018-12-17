﻿using SocialNetwork.Core.Entities;
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
        DisplayUserUpdate GetCurrentUpdate();

        DisplayUser UpdateCurrent(DisplayUserUpdate displayUser);

        IEnumerable<DisplayUser> Search(DisplayUserSearch search);
        IEnumerable<DisplayUser> Get();
    }
}
