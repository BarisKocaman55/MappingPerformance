using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using Serilog.Events;

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

            CreateHostBuilder(args).Build().Run();
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
