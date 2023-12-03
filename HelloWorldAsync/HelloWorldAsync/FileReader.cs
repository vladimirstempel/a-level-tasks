using System.IO;
using System.Threading.Tasks;

namespace HelloWorldAsync;

internal static class FileReader
{
    public static async Task<string> ReadHelloAsync(string pathToFile = "")
    {
        return await File.ReadAllTextAsync(pathToFile + "hello.txt");
    }
    
    public static async Task<string> ReadWorldAsync(string pathToFile = "")
    {
        return await File.ReadAllTextAsync(pathToFile + "world.txt");
    }

    public static Task<string> CombineHelloWorldAsync(Task<string> hello, Task<string> world)
    {
        return Task.WhenAll(hello, world)
            .ContinueWith(task => string.Join(" ", task.Result));
    }
}