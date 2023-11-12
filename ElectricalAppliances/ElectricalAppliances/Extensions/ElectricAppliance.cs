using ElectricalAppliances.Models.Abstractions;

namespace ElectricalAppliances.Extensions;

public static class ElectricAppliance
{
    public static IElectricalAppliance? Search(this IEnumerable<IElectricalAppliance> source,
        Func<IElectricalAppliance, bool> callback)
    {
        foreach (var item in source)
        {
            if (callback(item))
            {
                return item;
            }
        }

        return null;
    }
}