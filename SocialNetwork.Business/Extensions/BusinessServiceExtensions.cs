using Microsoft.AspNetCore.Identity;
using SocialNetwork.Business;
using SocialNetwork.Core.Entities;
using SocialNetwork.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class BusinessServiceExtensions
    {

        public static IServiceCollection AddBusiness(this IServiceCollection services)
            => services.AddScoped<IDisplayUserRepository, DisplayUserRepository>();

        public static IdentityBuilder AddDefinedIdentity(this IServiceCollection services)
            => services.AddIdentity<User, UserRole>();

    }
}
