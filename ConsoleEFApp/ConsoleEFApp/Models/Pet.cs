using ConsoleEFApp.Models.Abstractions;

namespace ConsoleEFApp.Models;

public class Pet : IModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public float Age { get; set; }
    public string ImageUrl { get; set; }
    public string Description { get; set; }

    public Category? Category { get; set; } = null!;
    public Breed? Breed { get; set; } = null!;
    public Location? Location { get; set; } = null!;
}