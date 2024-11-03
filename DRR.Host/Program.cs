using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace DRR;

public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration(app =>
            {
                var env = Directory.GetParent(typeof(Program).Assembly.Location)?.FullName;
                var settingFolder = Path.Combine(env, "Appsettings");
                Console.WriteLine(settingFolder);
                app.AddJsonFile(Path.Combine(settingFolder, "appsettings.json"), optional: false, reloadOnChange: true);
                app.AddJsonFile(Path.Combine(settingFolder, "appsettings.Development.json"), optional: false, reloadOnChange: true);
                app.AddJsonFile("defaultData.json", optional: false, reloadOnChange: true);
            })
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
}