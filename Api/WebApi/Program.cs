using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.IO;
using Serilog;

namespace WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureLogging((hostingContext, config) =>
                {
                    config.ClearProviders();
                    var envName = hostingContext.HostingEnvironment.EnvironmentName;
                    var configuration = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json", optional:false, reloadOnChange: true)
                        .AddJsonFile($"appsettings.{envName}.json", optional: true, reloadOnChange: true)
                        .Build();

                    Log.Logger = new LoggerConfiguration()
                        .ReadFrom.Configuration(configuration)
                        //.Enrich.WithThreadId()
                        .CreateLogger();

                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
