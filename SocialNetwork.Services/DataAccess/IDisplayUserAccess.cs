﻿using SocialNetwork.Core.Entities;
using SocialNetwork.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.Services.DataAccess
{
    public interface IDisplayUserAccess
    {
        IEnumerable<DisplayUser> Search(DisplayUserSearch search, int excludeUserId);

        DisplayUser Add(SignUp signUp, int userId);

        DisplayUser Update(DisplayUserUpdate displayUser, int id);

        DisplayUser Get(int id);

        IEnumerable<DisplayUser> Get();

        DisplayUser GetByUserId(int userId);
        int GetIdByUserId(int userId);
        IEnumerable<DisplayUser> Search(string q, int excludeUserId);

    }
}
