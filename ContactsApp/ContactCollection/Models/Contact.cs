using ContactCollection.Models.Abstractions;

namespace ContactCollection.Models;

public sealed class Contact : IContact
{
    public string Number { get; }
    public string Name { get; }

    public Contact(string name, string number)
    {
        Name = name;
        Number = number;
    }
}