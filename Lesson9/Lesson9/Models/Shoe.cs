using Lesson9.Common;

namespace Lesson9.Models;

public class Shoe
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public byte Size { get; set; }
    public StyleType Style { get; set; }
}