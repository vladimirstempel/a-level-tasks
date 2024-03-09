using ConsoleEFApp.Data.Entities.Abstractions;

namespace ConsoleEFApp.Data.Entities;

public class BreedEntity : IEntity
{
    public int Id { get; set; }
    public string BreedName { get; set; }
    public int CategoryId { get; set; }
    public CategoryEntity? Category { get; set; } = null!;
    
    public List<PetEntity>? Pets { get; set; } = null!;
}