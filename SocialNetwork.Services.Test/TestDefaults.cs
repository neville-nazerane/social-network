using Microsoft.Extensions.DependencyInjection;
using SocialNetwork.Core.Models;
using SocialNetwork.DataAccess.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.Services.Test
{
    public class TestDefaults
    {

        private readonly ServiceProvider provider;

        public TestDefaults()
        {
            var services = new ServiceCollection()
                            .AddTestDataAccess()
                            .AddTestSimulations()
                            .AddBusiness(o => o.IdentityBuilder.AddAppDb());
            provider = services.BuildServiceProvider();
        }

        protected T GetService<T>() => provider.GetService<T>();

        protected const string DefaultUserName = "neville";
        protected const string DefaultPassword = "Hello123";

        protected SignUp DefaultSignUp => new SignUp {
            UserName = DefaultUserName,
            FirstName = "Neville",
            LastName = "Nazerane",
            Email = "admin@nevillenazerane.com",
            Password = DefaultPassword,
            ConfirmPassword = DefaultPassword
        };

        protected Login DefaultLogin => new Login {
            UserName = DefaultUserName,
            Password = DefaultPassword
        };

    }
}
