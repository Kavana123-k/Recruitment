using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Recruit.Models;
using NLog;
using NLog.Extensions.Logging;

namespace Recruit
{
    public class Program
    {
        public static Logger log = LogManager.GetCurrentClassLogger();
        public static void Main(string[] args)
        {
            log.Info("[Main]:Application Start");
            var serviceProvider = Init.CreateServices();

            // Put the database update into a scope to ensure
            // that all resources will be disposed.
            log.Info("[Main]: Fluent Migrator to setup Database tables");
            using (var scope = serviceProvider.CreateScope())
            {
                Init.UpdateDatabase(scope.ServiceProvider);
            }
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
             .ConfigureLogging((hostingContext, logging) =>
             {
                 logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                 logging.AddDebug();
                 logging.AddNLog();
             })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
