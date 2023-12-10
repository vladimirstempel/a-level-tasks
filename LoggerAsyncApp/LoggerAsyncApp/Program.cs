using System.Threading.Tasks;
using LoggerAsyncApp.Config;
using LoggerAsyncApp.Logger;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LoggerAsyncApp;

public static class Program
{
    public static async Task Main()
    {
        var app = ConfigureApp();

        await app.Start();
    }

    private static App ConfigureApp()
    {
        IConfiguration configuration = new ConfigurationBuilder()
            .AddJsonFile("config.json", true, true)
            .Build();
        
        var provider = new ServiceCollection()
            .AddSingleton<IConfig>(new Config.Config(configuration))
            .AddSingleton<ILogger, Logger.Logger>()
            .AddTransient<App>()
            .BuildServiceProvider();

        return provider.GetService<App>();
    }
}