using ElectricalAppliances.Models.Abstractions;

namespace ElectricalAppliances.Repositories.Abstractions;

public interface INetworkRepository
{
    void PlugIn(IElectricalAppliance appliance);
    IElectricalAppliance[] SortByPowerConsumption(bool asc = true);
    double CalculateTotalPowerConsumption();
}