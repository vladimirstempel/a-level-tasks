using ElectricalAppliances.Models.Abstractions;

namespace ElectricalAppliances.Models;

public class Heater : Climate
{
    public Heater(string name, double powerConsumption, string brand)
    {
        Name = name;
        PowerConsumption = powerConsumption;
        Brand = brand;
    }
}