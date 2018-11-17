using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace SocialNetwork.DataAccess.Extensions
{
    public static class IdentityExtensions
    {

        public static IdentityBuilder AddAppDb(this IdentityBuilder builder)
            => builder.AddEntityFrameworkStores<AppDbContext>();

    }
}
