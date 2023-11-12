namespace ElectricalAppliances.Models.Abstractions;

public interface IElectricalAppliance
{
    public Guid Id { get; }
    string Name { get; }
    double PowerConsumption { get; }
    string Brand { get; }
}