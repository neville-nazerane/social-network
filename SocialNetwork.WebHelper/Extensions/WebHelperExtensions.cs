using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using SocialNetwork.Core.Entities;
using SocialNetwork.DataAccess.Extensions;
using SocialNetwork.Services;
using SocialNetwork.WebHelper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class WebHelperExtensions
    {

        public static IdentityBuilder AddDefinedIdentity(this IServiceCollection services)
            => services.AddIdentity<User, UserRole>();

        public static IServiceCollection AddWebHelpers(this IServiceCollection services) 
            => services
                .AddSingleton<IHttpContextAccessor, HttpContextAccessor>()
                .AddScoped<ILoginManager, LoginManager>();

    }
}
