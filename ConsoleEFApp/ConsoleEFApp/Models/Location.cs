using ConsoleEFApp.Models.Abstractions;

namespace ConsoleEFApp.Models;

public class Location : IModel
{
    public int Id { get; set; }
    public string LocationName { get; set; }

    public virtual List<Pet>? Pets { get; set; } = null!;
}