using Lesson9;
using Lesson9.Repositories;
using Lesson9.Repositories.Abstractions;
using Lesson9.Services;
using Lesson9.Services.Abstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

void ConfigureService(ServiceCollection serviceCollection, IConfiguration configuration)
{
    // serviceCollection.AddOptions<>();
    serviceCollection
        .AddTransient<IShoeService, ShoeService>()
        .AddScoped<IShoeRepository, ShoeRepository>()
        .AddTransient<App>();
}

IConfiguration configuration = new ConfigurationBuilder()
    .AddJsonFile("config.json")
    .Build();

var serviceCollection = new ServiceCollection();

ConfigureService(serviceCollection, configuration);

var provider = serviceCollection.BuildServiceProvider();

var app = provider.GetService<App>();

app!.Run();