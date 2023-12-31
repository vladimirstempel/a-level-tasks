namespace ConsoleEFApp.Data.Entities;

public class Pet
{
    public int Id { get; set; }
    public string Name { get; set; }
    public float Age { get; set; }
    public string ImageUrl { get; set; }
    public string Description { get; set; }
    
    public string? CategoryId { get; set; }
    public string? BreedId { get; set; }
    public string? LocationId { get; set; }

    public Category? Category { get; set; }
    public Breed? Breed { get; set; }
    public Location? Location { get; set; }
}