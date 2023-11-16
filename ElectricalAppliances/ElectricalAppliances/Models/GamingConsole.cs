using ElectricalAppliances.Models.Abstractions;

namespace ElectricalAppliances.Models;

public class GamingConsole : Gaming
{
    public GamingConsole(string name, double powerConsumption, string brand)
    {
        Name = name;
        PowerConsumption = powerConsumption;
        Brand = brand;
    }
}