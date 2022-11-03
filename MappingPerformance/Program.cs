using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using Serilog.Events;
using Microsoft.Extensions.DependencyInjection;
using MappingPerformance.Adapters.DataAccess;

namespace MappingPerformance
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var fileName = string.Format("{0}/{1}.txt", "LogFiles", DateTime.Today.ToString("dd-MM-yyyy"));
            Log.Logger = new LoggerConfiguration()
                               .MinimumLevel.Information()
                               .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                               .MinimumLevel.Override("Microsoft.Hosting.Lifetime", LogEventLevel.Warning)
                               .WriteTo.Async(i => i.File(fileName))
                               .CreateLogger();

            var host = CreateHostBuilder(args).Build();
            CreateDbIfNotExists(host);

            host.Run();
        }

        private static void CreateDbIfNotExists(IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<DatabaseContext>();
                    DbInitiliazer.Initialize(context);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred creating the DB.");
                }
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
