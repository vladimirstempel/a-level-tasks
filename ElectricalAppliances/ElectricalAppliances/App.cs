using ElectricalAppliances.Exceptions;
using ElectricalAppliances.Extensions;
using ElectricalAppliances.Models;
using ElectricalAppliances.Models.Abstractions;
using ElectricalAppliances.Services.Abstractions;

namespace ElectricalAppliances;

public class App
{
    private readonly INetworkService _networkService;

    public App(INetworkService networkService)
    {
        _networkService = networkService;
    }

    public void Start()
    {
        var appliances = GenerateAppliances();

        try
        {
            PlugAppliances(appliances);

            SortAppliances(appliances);

            CalculateTotalConsumption();

            FindAppliance(appliances, "Playstation");
        }
        catch (MaxAppliancesException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }

    private void PlugAppliances(IElectricalAppliance[] appliances)
    {
        foreach (var appliance in appliances)
        {
            _networkService.PlugIn(appliance);
            Console.WriteLine($"{appliance.Name} plugged into network with ID {appliance.Id.ToString()}.");
        }
    }

    private void SortAppliances(IElectricalAppliance[] appliances)
    {
        var sortedAscAppliances = _networkService.SortByPowerConsumption();
        var sortedDescAppliances = _networkService.SortByPowerConsumption(false);

        Console.WriteLine();
        foreach (var appliance in sortedAscAppliances)
        {
            Console.WriteLine($"{appliance.Name} - Power Consumption ASC: {appliance.PowerConsumption}");
        }

        Console.WriteLine();
        foreach (var appliance in sortedDescAppliances)
        {
            Console.WriteLine($"{appliance.Name} - Power Consumption DESC: {appliance.PowerConsumption}");
        }
    }

    private void CalculateTotalConsumption()
    {
        var totalConsumption = _networkService.CalculateTotalPowerConsumption();
        Console.WriteLine($"\nTotal consumption: {totalConsumption}");
    }

    private void FindAppliance(IElectricalAppliance[] appliances, string statement)
    {
        var foundAppliance =
            appliances.Search(appliance => appliance.Name.ToLower().Contains(statement.ToLower()));

        Console.WriteLine(
            $"\nFound Appliance:\nId - {foundAppliance?.Id.ToString()}\nName - {foundAppliance?.Name}\nPower Consumption - {foundAppliance?.PowerConsumption}\nBrand - {foundAppliance?.Brand}");
    }

    private IElectricalAppliance[] GenerateAppliances()
    {
        var ps5 = new GamingConsole("Playstation 5", 500, "Sony");
        var xbox = new GamingConsole("Series X", 700, "XBox");
        var tv = new TV("Smart TV", 800, "Samsung");
        var heater = new Heater("Heater", 1500, "Dyson");

        return new List<IElectricalAppliance>
        {
            ps5,
            xbox,
            tv,
            heater
        }.ToArray();
    }
}