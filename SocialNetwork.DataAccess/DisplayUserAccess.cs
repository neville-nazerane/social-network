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
            : AccessDefaults<DisplayUser, SignUp, DisplayUserUpdate>, IDisplayUserAccess
    {

        public DisplayUserAccess(AppDbContext context) : base(context)
        {

        }

        protected override DbSet<DisplayUser> Entity => context.DisplayUsers;

        protected override DisplayUser AddMapping(SignUp add)
            => new DisplayUser {
                FirstName = add.FirstName,
                LastName = add.LastName
            };

        protected override void UpdateMapping(DisplayUser toUpdate, DisplayUserUpdate update)
        {
            toUpdate.FirstName = update.FirstName;
            toUpdate.LastName = update.LastName;
        }
    }
}
