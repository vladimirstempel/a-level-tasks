

using ConsoleEFApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleEFApp;

public static class Program
{
    public static async Task Main()
    {
        var serviceCollection = new ServiceCollection();
        
        IConfiguration configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();
        
        ConfigureServices(serviceCollection, configuration);
        
        var provider = serviceCollection.BuildServiceProvider();

        var dbContext = provider.GetService<ApplicationDbContext>();
        
        await dbContext!.Database.EnsureCreatedAsync();

        var app = provider.GetService<App>();
        await app!.Start();
    }

    private static void ConfigureServices(ServiceCollection serviceCollection, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DbConnection");
        
        serviceCollection.AddDbContext<ApplicationDbContext>(opts
            => opts.UseSqlServer(connectionString));

        serviceCollection
            .AddTransient<App>();
    }
}