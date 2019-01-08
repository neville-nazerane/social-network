using System;
using System.Collections.Generic;
using System.Text;
using SocialNetwork.Core.Entities;
using SocialNetwork.Core.Models;

namespace SocialNetwork.Services.DataAccess
{
    public interface IFriendRequestAccess
    {

        FriendStatus GetStatus(int userId1, int displayUserId2);

        int Request(int userId1, int displayUserId2);

        bool Reject(int requestedForUserId, int requesterDisplayId);

        bool Accept(int requestedForUserId, int requesterDisplayId);

        bool CancelRequest(int requesterId, int requestedForDisplayId);

        IEnumerable<DisplayUser> List(int userId);

    }
}
