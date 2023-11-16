namespace ElectricalAppliances.Models.Abstractions;

public abstract class Multimedia : IElectricalAppliance
{
    public Guid Id { get; } = Guid.NewGuid();
    public string Name { get; set; }
    public double PowerConsumption { get; set; }
    public string Brand { get; set; }
}