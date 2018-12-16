using Microsoft.AspNetCore.Identity;
using SocialNetwork.Business;
using SocialNetwork.Business.Extensions;
using SocialNetwork.Core.Entities;
using SocialNetwork.Services;
using SocialNetwork.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class BusinessServiceExtensions
    {

        public static IServiceCollection AddBusiness(
                                        this IServiceCollection services,
                                        Action<BusinessServiceOptions> options
            )
        {
            var opts = new BusinessServiceOptions
            {
                IdentityBuilder = services.AddIdentity<User, UserRole>()
            };
            options.Invoke(opts);
            return services
                        .AddScoped<ILoginManager, LoginManager>()
                        .AddScoped<IDisplayUserRepository, DisplayUserRepository>()
                        .AddScoped<IFriendManager, FriendManager>();
        }

    }
}
