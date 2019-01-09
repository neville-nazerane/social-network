using SocialNetwork.Core.Entities;
using SocialNetwork.Core.Models;
using SocialNetwork.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SocialNetwork.Services.Test.Repositories
{
    public class PostRepositoryTest : TestDefaults
    {
        private readonly IPostRepository repository;

        public PostRepositoryTest()
        {
            repository = GetService<IPostRepository>();
        }

        async Task InitAsync()
        {
            await SignUpWithDefaultsAsync();
            await LoginWithDefaultAsync();
        }

        const string originalContent = "Sample data";

        [Fact]
        public async Task<Post> Add()
        {
            await InitAsync();
            Assert.Empty(repository.GetForCurrentUser());
            Assert.NotNull(repository.Add(new PostAdd { Content = originalContent }));
            Assert.Single(repository.GetForCurrentUser());
            var post = repository.GetForCurrentUser().First();

            Assert.Equal(originalContent, post.Content);

            return post;
        }

        [Fact]
        public async Task Update()
        {
            var post = await Add();
            string newContent = "New content";
            Assert.NotNull(repository.Update(new PostUpdate { Id = post.Id, Content = newContent }));
            post = repository.GetForCurrentUser().First();
            Assert.NotEqual(originalContent, post.Content);
            Assert.Equal(newContent, post.Content);
        }

        [Fact]
        public async Task Delete()
        {
            var post = await Add();
            Assert.True(repository.Delete(post.Id));
            Assert.Empty(repository.GetForCurrentUser());
        }

    }
}
