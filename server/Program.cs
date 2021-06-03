using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Reflection;

namespace server
{
    public class Program
    {
        public static void Main(string[] args) => CreateHostBuilder(args).Build().Run();

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(GetApplicationRoot())
                .AddEnvironmentVariables()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true).Build();


            return Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration(builder => builder.AddConfiguration(configuration))
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
        }

        public static string GetApplicationRoot()
        {
            var exePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            if (exePath.Contains("file:")) exePath = exePath.Remove(0, 5);
            if (!exePath.StartsWith("/var")) exePath = AppDomain.CurrentDomain.BaseDirectory;
            return exePath;
        }
    }
}
