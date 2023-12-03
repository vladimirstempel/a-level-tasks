using System;
using System.Threading.Tasks;

namespace HelloWorldAsync;

public static class Program
{
    public static async Task Main()
    {
        var helloTask = FileReader.ReadHelloAsync();
        var worldTask = FileReader.ReadWorldAsync();
        var helloWorld = await FileReader.CombineHelloWorldAsync(helloTask, worldTask);
        
        Console.WriteLine(helloWorld);
    }
}