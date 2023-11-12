using SaladMaker.Services.Abstractions;

namespace SaladMaker;

public class App
{
    private readonly ISaladService _saladService;
    
    public App(ISaladService saladService)
    {
        _saladService = saladService;
    }
    
    public void Start()
    {
        Console.WriteLine("Starting...");
        
        _saladService.AddSalad();
    }
}