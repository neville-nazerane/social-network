using SocialNetwork.Core.Entities;
using SocialNetwork.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.Services.DataAccess
{
    public interface IDisplayUserAccess 
                        : IGenericAccess<DisplayUser, DisplayUserAdd, DisplayUserUpdate>
    {

        bool DisplayUserExists(string displayName);

    }
}
