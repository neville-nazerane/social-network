using SocialNetwork.Core.Entities;
using SocialNetwork.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.Services
{
    public interface IFriendManager
    {

        int Request(int userId);

        void Accept(int requestId);

        void Reject(int requestId);

        FriendStatus GetStatus(int userId);

        IEnumerable<DisplayUser> ListFriends();

    }
}
