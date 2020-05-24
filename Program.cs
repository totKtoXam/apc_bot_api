using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apc_bot_api.Models.Base;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace apc_bot_api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                var _services = scope.ServiceProvider;
                var _context = _services.GetRequiredService<AppDbContext>();    

                try
                {
                    InitSeedData.Initialize(_services);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
