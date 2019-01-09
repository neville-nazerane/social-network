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
    class PostAccess : IPostAccess
    {
        private readonly AppDbContext context;

        public PostAccess(AppDbContext context)
        {
            this.context = context;
        }

        public Post Add(PostAdd post, int userDisplayId)
        {
            var toAdd = new Post {
                Content = post.Content,
                CreatedById = userDisplayId,
                CreatedOn = DateTime.Now
            };
            context.Add(toAdd);
            context.SaveChanges();
            return toAdd;
        }

        public Post Update(PostUpdate post, int userDisplayId)
        {
            var toEdit = context.Posts.SingleOrDefault(p => p.Id == post.Id && p.CreatedById == userDisplayId);
            if (toEdit != null)
            {
                toEdit.Content = post.Content;
                toEdit.UpdatedOn = DateTime.Now;
                context.Update(toEdit);
                context.SaveChanges();
            }
            return toEdit;
        }

        public bool Delete(int id, int userDisplayId)
        {
            var toDel = context.Posts.SingleOrDefault(p => p.Id == id && p.CreatedById == userDisplayId);
            if (toDel == null) return false;
            context.Remove(toDel);
            context.SaveChanges();
            return true;
        }

        public IEnumerable<Post> Get(int userDisplayId)
            => context.Posts.AsNoTracking().Where(p => p.CreatedById == userDisplayId);

    }
}
