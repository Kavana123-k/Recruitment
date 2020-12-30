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
//using NLog;
using NLog.Extensions.Logging;
using log4net.Config;
using System.Xml;
using System.IO;
using System.Reflection;

namespace Recruit
{
    public class Program
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(Program));
        public static void Main(string[] args)
        {
            log.Info("[Main]:Application Start");
            var serviceProvider = Init.CreateServices();

            //  log.Info("Application - Main is invoked");
            XmlDocument log4netConfig = new XmlDocument();
            log4netConfig.Load(File.OpenRead("log4net.config"));
            var repo = log4net.LogManager.CreateRepository(Assembly.GetEntryAssembly(),
                       typeof(log4net.Repository.Hierarchy.Hierarchy));
            log4net.Config.XmlConfigurator.Configure(repo, log4netConfig["log4net"]);

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
              //.ConfigureLogging((hostingContext, logging) =>
              //{
              //    logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
              //    logging.AddDebug();
              //    logging.AddNLog();
              //})
              .ConfigureLogging((hostingContext, logging) =>
              {
                  // logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                  // logging.AddDebug();
                  // builder.SetMinimumLevel(LogLevel.Trace);
                  logging.AddLog4Net("log4net.config");// .AddNLog();
              })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
