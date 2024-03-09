using ConsoleEFApp.Data.Entities.Abstractions;

namespace ConsoleEFApp.Data.Entities;

public class CategoryEntity : IEntity
{
    public int Id { get; set; }
    public string CategoryName { get; set; }

    public List<PetEntity>? Pets { get; set; } = null!;
    public List<BreedEntity>? Breeds { get; set; } = null!;
}