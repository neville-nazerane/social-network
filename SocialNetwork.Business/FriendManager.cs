using SocialNetwork.Core.Entities;
using SocialNetwork.Core.Models;
using SocialNetwork.Services;
using SocialNetwork.Services.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.Business
{
    class FriendManager : IFriendManager
    {
        private readonly ILoginContext loginContext;
        private readonly IFriendRequestAccess access;

        public FriendManager (
                                ILoginContext loginContext,
                                IFriendRequestAccess access
                            )
        {
            this.loginContext = loginContext;
            this.access = access;
        }

        public void Accept(int displayUserId)
            => access.Accept(loginContext.UserId, displayUserId);

        public void CancelRequest(int displayUserId)
            => access.CancelRequest(loginContext.UserId, displayUserId);

        public FriendStatus GetStatus(int displayUserId)
            => access.GetStatus(loginContext.UserId, displayUserId);

        public IEnumerable<DisplayUser> List()
            => access.List(loginContext.UserId);

        public void Reject(int displayUserId) => access.Reject(loginContext.UserId, displayUserId);

        public int Request(int displayUserId)
            => access.Request(loginContext.UserId, displayUserId);

    }
}
