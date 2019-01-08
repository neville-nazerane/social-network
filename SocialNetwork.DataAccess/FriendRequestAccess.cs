using Microsoft.EntityFrameworkCore;
using SocialNetwork.Core.Entities;
using SocialNetwork.Core.Models;
using SocialNetwork.Services.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocialNetwork.DataAccess
{
    class FriendRequestAccess : IFriendRequestAccess
    {
        private readonly AppDbContext context;

        public FriendRequestAccess(AppDbContext context)
        {
            this.context = context;
        }

        public int Request(int userId1, int displayUserId2)
        {
            var toAdd = new FriendRequest
            {
                CreatedOn = DateTime.Now,
                RequesterId = context.DisplayUsers.Single(d => d.UserId == userId1).Id,
                RequestedForId = displayUserId2
            };
            context.Add(toAdd);
            context.SaveChanges();
            return toAdd.Id;
        }
        
        FriendRequest _getRequest(int requestedForUserId, int requesterDisplayId)
              => context.FriendRequests.SingleOrDefault(f => f.RequestedFor.UserId == requestedForUserId
                                                        && f.RequesterId == requesterDisplayId);

        bool RespondToRequest(int requestedForUserId, int requesterDisplayId, bool response)
        {
            var request = _getRequest(requestedForUserId, requesterDisplayId);
            if (request == null) return false;
            request.RespondedOn = DateTime.Now;
            request.IsApproved = response;
            context.SaveChanges();
            return true;
        }

        public bool Accept(int requestedForUserId, int requesterDisplayId)
            => RespondToRequest(requestedForUserId, requesterDisplayId, true);

        public bool Reject(int requestedForUserId, int requesterDisplayId)
            => RespondToRequest(requestedForUserId, requesterDisplayId, false);

        public FriendStatus GetStatus(int userId1, int displayUserId2)
        {
            var request = context.FriendRequests.AsNoTracking()
                .SingleOrDefault(f => (f.RequestedFor.UserId == userId1 && f.RequesterId == displayUserId2)
                                    || (f.Requester.UserId == userId1 && f.RequestedForId == displayUserId2));

            if (request == null) return FriendStatus.None;
            if (request.IsApproved == true) return FriendStatus.IsFriend;
            if (request.IsApproved == false) return FriendStatus.None;
            if (request.RequestedForId == displayUserId2) return FriendStatus.RequestSent;
            if (request.RequesterId == displayUserId2) return FriendStatus.RequestRecieved;
            return FriendStatus.None;
        }

        public IEnumerable<DisplayUser> List(int userId)
            => (from f in context.Friends.AsNoTracking()
                where f.User1.UserId == userId
                select f.User1)
            .Union(from f in context.Friends.AsNoTracking()
                   where f.User2.UserId == userId
                   select f.User2).ToList();

        public bool CancelRequest(int requesterId, int requestedForDisplayId)
        {
            var request = context.FriendRequests.SingleOrDefault(r => 
                                r.Requester.Id == requesterId && r.RequestedForId == requestedForDisplayId);
            if (request == null) return false;
            context.Remove(request);
            context.SaveChanges();
            return true;
        }
    }
}
