using SocialNetwork.Core.Entities;
using SocialNetwork.Core.Models;
using SocialNetwork.Services;
using SocialNetwork.Services.DataAccess;
using SocialNetwork.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.Business
{
    class PostRepository : IPostRepository
    {
        private readonly IPostAccess access;
        private readonly IDisplayUserRepository displayUserRepository;

        public PostRepository(IPostAccess access, 
                              IDisplayUserRepository displayUserRepository)
        {
            this.access = access;
            this.displayUserRepository = displayUserRepository;
        }

        public Post Add(PostAdd post) => access.Add(post, displayUserRepository.GetCurrentId());

        public Post Update(PostUpdate post) => access.Update(post, displayUserRepository.GetCurrentId());

        public bool Delete(int id) => access.Delete(id, displayUserRepository.GetCurrentId());

        public IEnumerable<Post> Get(int userDisplayId) => access.Get(userDisplayId);

        public IEnumerable<Post> GetForCurrentUser() => access.Get(displayUserRepository.GetCurrentId());
    }
}
