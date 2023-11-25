using ContactCollection;

public sealed class Program
{
    public static void Main()
    {
        // Fixes ukrainian symbols in console
        Console.OutputEncoding = System.Text.Encoding.Default;
        
        ContactList contactList = new()
        {
            { "Володимир", "+380730115333" },
            { "Ірина", "+380730333433" },
            { "Наталія", "+380630335333" },
            { "Іван", "+380730555333" },
            { "Yohan", "+491603269132" },
            { "123123123", "+491603449132" },
            { "Aasd", "+441603269132" },
            { "###", "+491606669132" },
            { "123", "+441603269122" },
            { "-----", "+441603269111" },
            { "435345", "01603269111" },
            { "====", "0931233256" },
            { "12sadasd", "0931233256" },
            { "##sdasd", "0931666562" }
        };
        
        foreach (var keyValue in contactList)
        {
            Console.WriteLine(
                "Section - {0}, Contact - {1}",
                keyValue.Key,
                string.Join(", ", keyValue.Value.Select(x => $"{x.Name} | {x.Number}"))
            );
        }

        var foundContact = contactList.SearchByName("As");

        Console.WriteLine("\nFound Contact: Name - {0}, Number - {1}", foundContact?.Name, foundContact?.Number);
        
        Console.WriteLine("\nContacts count: {0}", contactList.Count());
    }
}