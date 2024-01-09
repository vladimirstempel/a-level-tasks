namespace ConsoleEFApp.Data.Entities;

public class Breed
{
    public int Id { get; set; }
    public string BreedName { get; set; }

    public Category? Category { get; set; }
}