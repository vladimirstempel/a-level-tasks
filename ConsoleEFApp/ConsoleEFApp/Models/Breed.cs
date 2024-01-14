using ConsoleEFApp.Models.Abstractions;

namespace ConsoleEFApp.Models;

public class Breed : IModel
{
    public int Id { get; set; }
    public string BreedName { get; set; }
    public Category Category { get; set; }
}