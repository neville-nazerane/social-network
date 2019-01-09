using SocialNetwork.Core.Entities;
using SocialNetwork.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.Services.Repositories
{
    public interface IPostRepository
    {

        Post Add(PostAdd post);

        Post Update(PostUpdate post);

        bool Delete(int id);

        IEnumerable<Post> Get(int userDisplayId);
        IEnumerable<Post> GetForCurrentUser();

    }
}
