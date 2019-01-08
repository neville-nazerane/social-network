using SocialNetwork.Core.Entities;
using SocialNetwork.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.Services
{
    public interface IFriendManager
    {

        int Request(int displayUserId);

        void Accept(int displayUserId);

        void Reject(int displayUserId);

        void CancelRequest(int displayUserId);

        FriendStatus GetStatus(int displayUserId);

        IEnumerable<DisplayUser> List();

    }
}
