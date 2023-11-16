using ElectricalAppliances.Exceptions;
using ElectricalAppliances.Models.Abstractions;
using ElectricalAppliances.Repositories.Abstractions;

namespace ElectricalAppliances.Repositories;

public class NetworkRepository : INetworkRepository
{
    private IElectricalAppliance[] _appliances;
    private int _applianceCursor = 0;

    public NetworkRepository(int applianceCount)
    {
        _appliances = new IElectricalAppliance[applianceCount];
    }

    public void PlugIn(IElectricalAppliance appliance)
    {
        if (_applianceCursor < _appliances.Length)
        {
            _appliances[_applianceCursor] = appliance;
            _applianceCursor++;
        }
        else
        {
            throw new MaxAppliancesException($"Max appliance reached: {_appliances.Length}");
        }
    }

    public IElectricalAppliance[] SortByPowerConsumption(bool asc = true)
    {
        return asc
            ? _appliances.OrderBy(pc => pc.PowerConsumption).ToArray()
            : _appliances.OrderByDescending(pc => pc.PowerConsumption).ToArray();
    }

    public double CalculateTotalPowerConsumption()
    {
        return _appliances.Sum(x => x.PowerConsumption);
    }
}