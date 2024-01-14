using ConsoleEFApp.Data.Entities.Abstractions;

namespace ConsoleEFApp.Data.Entities;

public class PetEntity : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public float Age { get; set; }
    public string ImageUrl { get; set; }
    public string Description { get; set; }
    
    public int? CategoryId { get; set; }
    public int? BreedId { get; set; }
    public int? LocationId { get; set; }

    public CategoryEntity? Category { get; set; } = null!;
    public BreedEntity? Breed { get; set; } = null!;
    public LocationEntity? Location { get; set; } = null!;
}