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

        bool RequestResponse(int userId, int requestId, bool response, bool save = true)
        {
            var request = context.FriendRequests.SingleOrDefault(
                        r => r.Id == requestId && r.RequestedForId == userId);
            if (request == null) return false;
            request.IsApproved = response;
            request.RespondedOn = DateTime.Now;
            context.SaveChanges();
            return true;
        }

        public bool Accept(int userId, int requestId)
        {
            if (!RequestResponse(userId, requestId, true)) return false;
            context.Add(new Friend {
                User1Id = userId,
                User2Id = requestId,
                CreatedOn = DateTime.Now
            });
            context.SaveChanges();
            return true;
        }

        public FriendStatus GetStatus(int userId, int otherId)
        {
            if (context.Friends.Any(
                                f => (f.User1Id == userId && f.User2Id == otherId)
                                 || (f.User2Id == userId && f.User1Id == otherId)))
                return FriendStatus.IsFriend;

            var request = context.FriendRequests.AsNoTracking().SingleOrDefault(
                            r => ((r.RequesterId == userId && r.RequestedForId == otherId)
                                || (r.RequesterId == otherId && r.RequestedForId == userId))
                                && r.IsApproved != false);
            if (request == null) return FriendStatus.None;
            if (request.RequesterId == userId) return FriendStatus.RequestSent;
            else if (request.RequestedForId == userId) return FriendStatus.RequestRecieved;
            return FriendStatus.None;
        }

        public IEnumerable<DisplayUser> List(int userId)
            => (from f in context.Friends.AsNoTracking()
                  where f.User1Id == userId
                  select f.User2)
            .Union(from f in context.Friends.AsNoTracking()
                   where f.User2Id == userId
                   select f.User1);

        public bool Reject(int userId, int requestId)
            => RequestResponse(userId, requestId, false);

        public int Request(int requesterId, int requestedForId)
        {
            var toAdd = new FriendRequest {
                RequesterId = requesterId,
                RequestedForId = requestedForId,
                CreatedOn = DateTime.Now
            };
            context.Add(toAdd);
            context.SaveChanges();
            return toAdd.Id;
        }
    }
}
