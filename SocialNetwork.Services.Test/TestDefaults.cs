using Microsoft.Extensions.DependencyInjection;
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
            provider = new ServiceCollection()
                            .AddTestDataAccess()
                            .AddBusiness()
                            .BuildServiceProvider();
        }

        protected T GetService<T>() => provider.GetService<T>();

    }
}
