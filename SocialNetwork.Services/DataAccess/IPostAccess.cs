using System;
using System.Collections.Generic;
using System.Text;
using SocialNetwork.Core.Entities;
using SocialNetwork.Core.Models;

namespace SocialNetwork.Services.DataAccess
{
    public interface IPostAccess
    {
        Post Add(PostAdd post, int userDisplayId);

        Post Update(PostUpdate post, int userDisplayId);

        IEnumerable<Post> Get(int userDisplayId);

        bool Delete(int id, int userDisplayId);

    }
}
