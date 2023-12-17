using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ReqresClient.Config;
using ReqresClient.Services;
using ReqresClient.Services.Abstractions;

namespace ReqresClient;

public static class Program
{
    public static async Task Main()
    {
        IConfiguration configuration = new ConfigurationBuilder()
            .AddJsonFile("config.json")
            .Build();

        var serviceCollection = new ServiceCollection();

        ConfigureServices(serviceCollection, configuration);

        var provider = serviceCollection.BuildServiceProvider();

        var app = provider.GetService<App>();

        await app.Start();
    }

    private static void ConfigureServices(ServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddOptions<ApiOption>().Bind(configuration.GetSection("Api"));
        serviceCollection
            .AddLogging(configure => configure.AddConsole())
            .AddHttpClient()
            .AddTransient<IInternalHttpClientService, InternalHttpClientService>()
            .AddTransient<IUserService, UserService>()
            .AddTransient<IRegisterService, RegisterService>()
            .AddTransient<App>();
    }
}