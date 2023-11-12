using ElectricalAppliances.Models.Abstractions;

namespace ElectricalAppliances.Models;

public class TV : Multimedia
{
    public TV(string name, double powerConsumption, string brand)
    {
        Name = name;
        PowerConsumption = powerConsumption;
        Brand = brand;
    }
}