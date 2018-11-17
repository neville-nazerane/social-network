using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SocialNetwork.Services.Test
{

    public class LoginTest : TestDefaults
    {
        private readonly ILoginManager loginManager;

        public LoginTest()
        {
            loginManager = GetService<ILoginManager>();
        }

        [Fact]
        public async Task SignUp()
        {
            var signup = DefaultSignUp;
            bool success = await loginManager.SignUpAsync(signup);
            Assert.True(success);
        }

        [Fact]
        public async Task DuplicateUserNameSignUp()
        {
            var signup = DefaultSignUp;
            bool success = await loginManager.SignUpAsync(signup);
            Assert.True(success);

            var duplicateNameSignUp = DefaultSignUp;
            bool successToFail = await loginManager.SignUpAsync(duplicateNameSignUp);
            Assert.False(successToFail);
        }

        [Fact]
        public async Task Login()
        {
            var login = DefaultLogin;
            bool result = await loginManager.LoginAsync(login);
            Assert.False(result);

            await loginManager.SignUpAsync(DefaultSignUp);
            result = await loginManager.LoginAsync(login);
            Assert.True(result);

        }

        [Fact]
        public async Task InvalidLogin()
        {
            var login = DefaultLogin;
            bool result = await loginManager.LoginAsync(login);
            Assert.False(result);

            await loginManager.SignUpAsync(DefaultSignUp);
            login.Password = "invalid pass";
            result = await loginManager.LoginAsync(login);
            Assert.False(result);

        }

    }
}
