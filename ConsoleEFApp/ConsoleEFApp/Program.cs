using ConsoleEFApp.Data;
using ConsoleEFApp.Data.Seeds;
using ConsoleEFApp.Repositories;
using ConsoleEFApp.Repositories.Abstractions;
using ConsoleEFApp.Services;
using ConsoleEFApp.Services.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

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
        
        var migrationSection = configuration.GetSection("Migration");
        var isNeedMigration = migrationSection.GetSection("IsNeedMigration");

        if (isNeedMigration.Value != null && bool.Parse(isNeedMigration.Value))
        {
            await dbContext!.Database.EnsureCreatedAsync();
        }

        var app = provider.GetService<App>();
        await app!.Start();
    }

    private static void ConfigureServices(ServiceCollection serviceCollection, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DbConnection");
        
        serviceCollection.AddDbContextFactory<ApplicationDbContext>(opts
            => opts.UseSqlServer(connectionString));
        serviceCollection
            .AddScoped<IDbContextWrapper<ApplicationDbContext>, DbContextWrapper<ApplicationDbContext>>();

        serviceCollection
            .AddLogging(configure => configure.AddConsole())
            .AddTransient<DataSeed>()
            .AddTransient<IPetRepository, PetRepository>()
            .AddTransient<IBreedRepository, BreedRepository>()
            .AddTransient<ILocationRepository, LocationRepository>()
            .AddTransient<ICategoryRepository, CategoryRepository>()
            .AddTransient<IPetService, PetService>()
            .AddTransient<IBreedService, BreedService>()
            .AddTransient<ILocationService, LocationService>()
            .AddTransient<ICategoryService, CategoryService>()
            .AddTransient<App>();
    }
}