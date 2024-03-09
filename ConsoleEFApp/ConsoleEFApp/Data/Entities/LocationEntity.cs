using ConsoleEFApp.Data.Entities.Abstractions;

namespace ConsoleEFApp.Data.Entities;

public class LocationEntity : IEntity
{
    public int Id { get; set; }
    public string LocationName { get; set; }

    public List<PetEntity>? Pets { get; set; } = null!;
}