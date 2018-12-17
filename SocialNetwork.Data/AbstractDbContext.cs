using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SocialNetwork.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.Data
{
    public abstract class AbstractDbContext : IdentityDbContext<User, UserRole, int>
    {
        public AbstractDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<DisplayUser> DisplayUsers { get; set; }

        public DbSet<Friend> Friends { get; set; }

        public DbSet<FriendRequest> FriendRequests { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<DisplayUser>()
                            .RelationBuilder()
                                .OneToManyRestrict<FriendRequest>(f => f.Requester)
                                .OneToManyRestrict<FriendRequest>(f => f.RequestedFor)
                                .OneToManyRestrict<Friend>(f => f.User1)
                                .OneToManyRestrict<Friend>(f => f.User2);

        }

    }
}
