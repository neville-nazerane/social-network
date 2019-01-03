using SocialNetwork.Core.Models;
using SocialNetwork.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SocialNetwork.Services.Test
{
    public class FriendManagerTest : TestDefaults
    {
        private readonly IFriendManager friendManager;
        private readonly ILoginContext loginContext;
        private int friendId;

        public FriendManagerTest()
        {
            friendManager = GetService<IFriendManager>();
            loginContext = GetService<ILoginContext>();
        }

        const string friendUserName = "theFriend";

        async Task InitAsync()
        {
            await SignUpWithDefaultsAsync();
            await SignUpAsync(new SignUp {
                UserName = friendUserName,
                Email = "someone@gmail.com",
                FirstName = "Doe",
                Password = DefaultPassword,
                ConfirmPassword = DefaultPassword
            });
            await LoginWithDefaultAsync();
            var displayUserRepository = GetService<IDisplayUserRepository>();
            friendId = displayUserRepository
                            .Search(new DisplayUserSearch { FirstName = "Doe" }).SingleOrDefault().Id;
        }

        [Fact]
        public async Task Request()
        {
            await InitAsync();
            int id = friendManager.Request(friendId);
            Assert.NotEqual(0, id);
            var status = friendManager.GetStatus(friendId);
            Assert.Equal(FriendStatus.RequestSent, status);
        }

        int GetCurrentUserDisplayId()
            => GetService<IDisplayUserRepository>().GetCurrent().Id;

        [Fact]
        public async Task Accept()
        {
            await Request();
            int userDisplayId = GetCurrentUserDisplayId();
            await LoginAsync(new Login {
                UserName = friendUserName,
                Password = DefaultPassword
            });
            friendManager.Accept(userDisplayId);
            await LoginWithDefaultAsync();
            var status = friendManager.GetStatus(friendId);
            Assert.Equal(FriendStatus.IsFriend, status);
        }

        [Fact]
        public async Task Reject()
        {
            await Request();
            int userDisplayId = GetCurrentUserDisplayId();
            await LoginAsync(new Login {
                UserName = friendUserName,
                Password = DefaultPassword
            });
            friendManager.Reject(userDisplayId);
            await LoginWithDefaultAsync();
            var status = friendManager.GetStatus(friendId);
            Assert.Equal(FriendStatus.None, status);
        }

    }
}
