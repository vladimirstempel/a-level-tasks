using Logger;
using Microsoft.Extensions.DependencyInjection;

namespace LoggerApp;

public static class Program
{
    public static void Main()
    {
        var serviceCollection = new ServiceCollection()
            .AddTransient<Actions>()
            .AddTransient<FileService>()
            .AddSingleton<Logger.Logger>()
            .AddTransient<App>();

        var provider = serviceCollection.BuildServiceProvider();
        var app = provider.GetService<App>();
        
        app!.Run();
    }
}