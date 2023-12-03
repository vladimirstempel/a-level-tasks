using Microsoft.Extensions.DependencyInjection;
using SaladMaker;

var services = new ServiceCollection()
    .AddTransient<App>();
    
var provider = services.BuildServiceProvider();

var app = provider.GetService<App>();

app!.Start();