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
    class DisplayUserAccess :  IDisplayUserAccess
    {
        private readonly AppDbContext context;

        public DisplayUserAccess(AppDbContext context)
        {
            this.context = context;
        }

        public DisplayUser Add(SignUp signUp, int userId)
        {

            var toAdd = new DisplayUser
            {
                CreatedOn = DateTime.Now,
                FirstName = signUp.FirstName,
                LastName = signUp.LastName,
                UserId = userId
            };
            context.Add(toAdd);
            context.SaveChanges();
            return toAdd;
        }

        public DisplayUser Update(DisplayUserUpdate displayUser, int id)
        {
            var toEdit = context.DisplayUsers.SingleOrDefault(u => u.Id == id);
            if (toEdit != null)
            {
                toEdit.FirstName = displayUser.FirstName;
                toEdit.LastName = displayUser.LastName;
            }
            context.SaveChanges();
            return toEdit;
        }
        public DisplayUser Get(int id)
            => context.DisplayUsers.AsNoTracking().SingleOrDefault(u => u.Id == id);

        public IEnumerable<DisplayUser> Get()
            => context.DisplayUsers.AsNoTracking().ToList();

        public IEnumerable<DisplayUser> Search(DisplayUserSearch s, int excludeUserId)
            => context.DisplayUsers.AsNoTracking().Where(u => 
                                u.User.Id != excludeUserId 
                            && (string.IsNullOrWhiteSpace(s.FirstName) || u.FirstName.StartsWith(s.FirstName))
                            && (string.IsNullOrWhiteSpace(s.LastName) || u.LastName.StartsWith(s.LastName))
                            && (string.IsNullOrWhiteSpace(s.UserName) || u.User.UserName.StartsWith(s.UserName)));

        public IEnumerable<DisplayUser> Search(string q, int excludeUserId)
            => context.DisplayUsers.AsNoTracking().Where(u => 
                                    u.User.Id != excludeUserId && 
                                    (string.IsNullOrWhiteSpace(q)
                                    || u.FirstName.StartsWith(q) 
                                    || u.LastName.StartsWith(q) 
                                    || u.User.UserName.StartsWith(q)));

        public DisplayUser GetByUserId(int userId)
            => context.DisplayUsers.AsNoTracking().SingleOrDefault(u => u.UserId == userId);

        public int GetIdByUserId(int userId)
            => (from u in context.DisplayUsers where u.UserId == userId select u.Id).SingleOrDefault();

    }
}
