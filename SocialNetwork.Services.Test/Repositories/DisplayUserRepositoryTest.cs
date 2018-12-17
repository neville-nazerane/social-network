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
    public class DisplayUserRepositoryTest : TestDefaults
    {
        private readonly IDisplayUserRepository repository;

        public DisplayUserRepositoryTest()
        {
            repository = GetService<IDisplayUserRepository>();
        }

        async Task InitAsync()
        {
            await SignUpWithDefaultsAsync();
            await LoginWithDefaultAsync();
        }

        [Fact]
        public async Task UserCountTest()
        {
            await InitAsync();
            Assert.Single(repository.Get());

            var signup2 = DefaultSignUp;
            signup2.UserName = "newname";
            signup2.Email = "name@gmail.com";
            await SignUpAsync(signup2);
            Assert.Equal(2, repository.Get().Count());
            Assert.Single(repository.Search(new DisplayUserSearch { UserName = "new" }));
        }

        [Fact]
        public async Task FullNameTest()
        {
            await InitAsync();
            var user = repository.GetCurrent();
            Assert.Equal(DefaultFirstName, user.FirstName);
            Assert.Equal(DefaultLastName, user.LastName);
        }

        [Fact]
        public async Task UpdateFullNameTest()
        {
            await InitAsync();
            string changedFirstName = "NewFName";
            string changedLastName = "NewFName";
            var updated = repository.UpdateCurrent(new DisplayUserUpdate {
                FirstName = changedFirstName,
                LastName = changedLastName
            });
            Assert.NotNull(updated);
            var user = repository.GetCurrent();
            Assert.NotEqual(DefaultFirstName, user.FirstName);
            Assert.Equal(user.FirstName, user.FirstName);
            Assert.NotEqual(DefaultLastName, user.LastName);
            Assert.Equal(user.LastName, user.LastName);
        }

    }
}
