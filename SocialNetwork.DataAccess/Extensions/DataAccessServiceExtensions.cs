using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SocialNetwork.Constants;
using SocialNetwork.DataAccess;
using SocialNetwork.Services.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;


namespace Microsoft.Extensions.DependencyInjection
{
    public static class DataAccessServiceExtensions
    {

        public static IServiceCollection AddDataAccess (
                                        this IServiceCollection services,
                                        IConfiguration configuration
                                    )
            => services.AddDbContext<AppDbContext>(config => 
                                config.UseSqlServer(configuration
                                                .GetConnectionString(DB.ConnectionKey)))
                       .Defaults();

        public static IServiceCollection AddTestDataAccess(this IServiceCollection services)
            => services.AddDbContext<AppDbContext>(config => 
                                    config.UseInMemoryDatabase("socialNetworkTest"))
                       .Defaults();

        static IServiceCollection Defaults(this IServiceCollection services)
            => services.AddScoped<IDisplayUserAccess, DisplayUserAccess>();

    }
}
