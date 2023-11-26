using ContactCollection.Enums;

namespace ContactCollection.Models.Abstractions;

public interface IContact
{
    public string Number { get; }
    public string Name { get; }
}