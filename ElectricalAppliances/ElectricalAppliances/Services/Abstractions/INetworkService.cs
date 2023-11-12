using ElectricalAppliances.Models.Abstractions;

namespace ElectricalAppliances.Services.Abstractions;

public interface INetworkService
{
    void PlugIn(IElectricalAppliance appliance);
    IElectricalAppliance[] SortByPowerConsumption(bool asc = true);
    double CalculateTotalPowerConsumption();
}