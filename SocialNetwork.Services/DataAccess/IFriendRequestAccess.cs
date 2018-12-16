using System;
using System.Collections.Generic;
using System.Text;
using SocialNetwork.Core.Entities;
using SocialNetwork.Core.Models;

namespace SocialNetwork.Services.DataAccess
{
    public interface IFriendRequestAccess
    {

        FriendStatus GetStatus(int userId1, int userId2);

        int Request(int userId1, int userId2);

        bool Reject(int userId, int requestId);

        bool Accept(int userId, int requestId);

        IEnumerable<DisplayUser> List(int userId);

    }
}
