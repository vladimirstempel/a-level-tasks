using System;
using System.Collections.Generic;

namespace ExtensionMethods;

public static class Program
{
    public static void Main()
    {
        DelegatesApp.Start();

        var contactList = new Dictionary<string, string>
        {
            { "contact1", "01928831238" },
            { "contact2", "01928831234" },
            { "contact3", "01928831236" },
            { "contact4", "01928831237" }
        };
        
        Console.WriteLine("\nFirstOrDefault: {0}", contactList.FirstOrDefault());
        Console.WriteLine("Where: {0}", string.Join(", ", contactList.Where(x => x.Key == "contact2")));
        Console.WriteLine("Select: {0}", string.Join(", ", contactList.Select(x => x.Value)));
        Console.WriteLine("Count: {0}", contactList.Count());
        Console.WriteLine("ElementAt: {0}", contactList.ElementAt(2));
        Console.WriteLine("ToList: {0}", contactList.ToList().GetType());
        Console.WriteLine("ToArray: {0}", contactList.ToArray().GetType());
    }
}