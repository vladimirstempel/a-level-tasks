using ConsoleEFApp.Models.Abstractions;

namespace ConsoleEFApp.Models;

public class Category : IModel
{
    public int Id { get; set; }
    public string CategoryName { get; set; }

    public List<Pet>? Pets { get; set; } = null!;
    public List<Breed>? Breeds { get; set; } = null!;
}