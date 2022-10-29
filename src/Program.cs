using Amazon;
using Amazon.Extensions.NETCore.Setup;
using IYLTDSU.Api;

CreateHostBuilder(args).Build().Run();

static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.ConfigureKestrel(x => x.AddServerHeader = false);
            webBuilder.UseStartup<Startup>();
        })
        .ConfigureAppConfiguration((environment, app) =>
        {
            app.AddSystemsManager($"/{environment.HostingEnvironment.EnvironmentName}");
        });