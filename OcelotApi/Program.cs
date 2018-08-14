using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Web;
using System;

namespace OcelotApi
{
    public static class Program
    {

        public static void Main(string[] args)
        {
            var logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();

            try
            {
                logger.Debug($"Init {nameof(Main)}...");
                BuildWebHost(args).Run();
            }
            catch (Exception ex)
            {
                logger.Fatal(ex, $"{System.Diagnostics.Process.GetCurrentProcess().ProcessName} crashed!");
                throw;
            }
            finally
            {
                NLog.LogManager.Shutdown();
            }
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                    logging.SetMinimumLevel(LogLevel.Trace);
                })
                .UseNLog()
                .Build();
    }
}
