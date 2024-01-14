using ConsoleEFApp.Data.Seeds;
using ConsoleEFApp.Models;
using ConsoleEFApp.Services.Abstractions;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace ConsoleEFApp;

public class App
{
    private readonly IPetService _petService;
    private readonly ILogger<App> _logger;
    private readonly DataSeed _dataSeed;

    public App(IPetService petService, ILogger<App> logger, DataSeed dataSeed)
    {
        _petService = petService;
        _logger = logger;
        _dataSeed = dataSeed;
    }
    
    public async Task Start()
    {
        // Create Data
        await _dataSeed.Init();
        
        var data = await _petService.GetAll();

        var uniq = await _petService.GetUkrainianPetsCount();
        
        _logger.LogInformation("Dogs grouped by category name with unique breed name that older than 3 years and located in Ukraine: Count - {0}", uniq);
        
        _logger.LogInformation("Data from DB: {0}", data.Count > 0 ? JsonPrettify(JsonSerializer.Serialize(data, JsonPetContext.Default.ListPet)) : "Database created, but empty");
    }
    
    private static string JsonPrettify(string json)
    {
        using (var stringReader = new StringReader(json))
        using (var stringWriter = new StringWriter())
        {
            var jsonReader = new JsonTextReader(stringReader);
            var jsonWriter = new JsonTextWriter(stringWriter) { Formatting = Formatting.Indented };
            jsonWriter.WriteToken(jsonReader);
            return stringWriter.ToString();
        }
    }
}