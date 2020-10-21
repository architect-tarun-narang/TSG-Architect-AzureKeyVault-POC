using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace UserSecrets2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
             .ConfigureAppConfiguration((context, config) =>
               {
                   if (context.HostingEnvironment.IsProduction())
                   {
                       var root = config.Build();
                       config.AddAzureKeyVault($"https://{root["KeyVault:Vault"]}.vault.azure.net/",
                           root["KeyVault:ClientId"], root["KeyVault:ClientSecret"]);
                   }
               })
            .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
