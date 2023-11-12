using Microsoft.Extensions.DependencyInjection;
using SaladMaker;
using SaladMaker.Services;
using SaladMaker.Services.Abstractions;

var services = new ServiceCollection()
    .AddTransient<ISaladService, SaladService>()
    .AddTransient<App>();
    
var provider = services.BuildServiceProvider();

var app = provider.GetService<App>();

app!.Start();