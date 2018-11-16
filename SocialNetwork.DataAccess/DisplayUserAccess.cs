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
    class DisplayUserAccess 
            : AccessDefaults<DisplayUser, DisplayUserAdd, DisplayUserUpdate>, IDisplayUserAccess
    {

        public DisplayUserAccess(AppDbContext context) : base(context)
        {

        }

        protected override DbSet<DisplayUser> Entity => context.DisplayUsers;

        public bool DisplayUserExists(string displayName) 
            => context.DisplayUsers.Any(u => u.DisplayName == displayName);

        protected override DisplayUser AddMapping(DisplayUserAdd add)
            => new DisplayUser {
                DisplayName = add.DisplayName
            };

        protected override void UpdateMapping(DisplayUser toUpdate, DisplayUserUpdate update)
        {
            toUpdate.DisplayName = update.DisplayName;
        }
    }
}
