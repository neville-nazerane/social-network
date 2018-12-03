using Microsoft.Extensions.DependencyInjection;
using SocialNetwork.Core.Models;
using SocialNetwork.DataAccess.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Services.Test
{
    public class TestDefaults
    {

        private readonly ServiceProvider provider;
        private readonly ILoginManager loginManager;

        public TestDefaults()
        {
            var services = new ServiceCollection()
                            .AddTestDataAccess()
                            .AddTestSimulations()
                            .AddBusiness(o => o.IdentityBuilder.AddAppDb())
                            .AddNetCoreValidations();
            provider = services.BuildServiceProvider();
            loginManager = GetService<ILoginManager>();
        }

        protected T GetService<T>() => provider.GetService<T>();

        protected const string DefaultUserName = "neville";
        protected const string DefaultPassword = "Hello123!";
        protected const string DefaultFirstName = "Neville";
        protected const string DefaultLastName = "Nazerane";

        protected SignUp DefaultSignUp => new SignUp {
            UserName = DefaultUserName,
            FirstName = DefaultFirstName,
            LastName = DefaultLastName,
            Email = "admin@nevillenazerane.com",
            Password = DefaultPassword,
            ConfirmPassword = DefaultPassword
        };

        protected async Task SignUpAsync(SignUp signUp)
            => await loginManager.SignUpAsync(signUp);

        protected async Task SignUpWithDefaultsAsync()
            => await SignUpAsync(DefaultSignUp);
            
        protected Login DefaultLogin => new Login {
            UserName = DefaultUserName,
            Password = DefaultPassword
        };

        protected async Task LoginAsync(Login login)
            => await loginManager.LoginAsync(login);

        protected async Task LoginWithDefaultAsync()
            => await LoginAsync(DefaultLogin);

    }
}
