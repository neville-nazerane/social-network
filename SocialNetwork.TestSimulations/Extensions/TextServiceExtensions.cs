using SocialNetwork.Services;
using SocialNetwork.TestSimulations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class TextServiceExtensions
    {

        public static IServiceCollection AddTestSimulations(this IServiceCollection services)
            => services.AddSingleton<ILoginContext, LoginContext>();

    }
}
