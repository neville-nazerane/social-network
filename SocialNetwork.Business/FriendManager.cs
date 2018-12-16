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

        public void Accept(int requestId)
            => access.Accept(loginContext.UserId, requestId);

        public FriendStatus GetStatus(int userId)
            => access.GetStatus(loginContext.UserId, userId);

        public IEnumerable<DisplayUser> List()
            => access.List(loginContext.UserId);

        public void Reject(int requestId)
            => access.Reject(loginContext.UserId, requestId);

        public int Request(int userId)
            => access.Request(loginContext.UserId, userId);

    }
}
