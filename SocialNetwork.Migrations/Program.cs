using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace SocialNetwork.Migrations
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

    public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
        WebHost.CreateDefaultBuilder(args)
        // additional code
            .UseConfiguration(
                new ConfigurationBuilder()
                .AddXmlFile("file.xml", true) // second param is if file is optional
                .Build()
            )
        // end of additional code
            .UseStartup<Startup>();
    }
}
