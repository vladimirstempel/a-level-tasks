using ElectricalAppliances.Models.Abstractions;
using ElectricalAppliances.Repositories.Abstractions;
using ElectricalAppliances.Services.Abstractions;

namespace ElectricalAppliances.Services;

public class NetworkService : INetworkService
{
    private INetworkRepository _networkRepository;

    public NetworkService(INetworkRepository networkRepository)
    {
        _networkRepository = networkRepository;
    }
    
    public void PlugIn(IElectricalAppliance appliance)
    {
        _networkRepository.PlugIn(appliance);
    }

    public IElectricalAppliance[] SortByPowerConsumption(bool asc = true)
    {
        return _networkRepository.SortByPowerConsumption(asc);
    }

    public double CalculateTotalPowerConsumption()
    {
        return _networkRepository.CalculateTotalPowerConsumption();
    }
}