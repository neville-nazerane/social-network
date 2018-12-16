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
        private int friendId;

        public FriendManagerTest()
        {
            friendManager = GetService<IFriendManager>();
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
            friendId = displayUserRepository.Get().Single(u => u.FirstName == "Doe").Id;
        }

        [Fact]
        public async Task<int> Request()
        {
            await InitAsync();
            int id = friendManager.Request(friendId);
            Assert.NotEqual(0, id);
            var status = friendManager.GetStatus(friendId);
            Assert.Equal(FriendStatus.RequestSent, status);
            return id;
        }

        [Fact]
        public async Task Accept()
        {
            int requestId = await Request();
            await LoginAsync(new Login {
                UserName = friendUserName,
                Password = DefaultPassword
            });
            friendManager.Accept(requestId);
            await LoginWithDefaultAsync();
            var status = friendManager.GetStatus(friendId);
            Assert.Equal(FriendStatus.IsFriend, status);
        }

        [Fact]
        public async Task Reject()
        {
            int requestId = await Request();
            await LoginAsync(new Login {
                UserName = friendUserName,
                Password = DefaultPassword
            });
            friendManager.Reject(requestId);
            await LoginWithDefaultAsync();
            var status = friendManager.GetStatus(friendId);
            Assert.Equal(FriendStatus.None, status);
        }

    }
}
