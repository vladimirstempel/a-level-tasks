using ElectricalAppliances;
using ElectricalAppliances.Repositories;
using ElectricalAppliances.Repositories.Abstractions;
using ElectricalAppliances.Services;
using ElectricalAppliances.Services.Abstractions;
using Microsoft.Extensions.DependencyInjection;

int networkMaxCapacity = 4;

var serviceCollection = new ServiceCollection()
    .AddTransient<INetworkRepository>(_ => new NetworkRepository(networkMaxCapacity))
    .AddTransient<INetworkService, NetworkService>()
    .AddScoped<App>();
    
var provider = serviceCollection.BuildServiceProvider();

var app = provider.GetService<App>();

app!.Start();