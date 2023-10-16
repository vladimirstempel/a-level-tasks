using System.Collections.ObjectModel;
using System.Text.Json;
using UtilityLibraries;

namespace ArrayPlayground;

public class Task
{
    public void RunFirst()
    {
        Console.WriteLine("-------------------------- Start Task 1 -------------------------");

        int[] array = new int[10]; 

        array.FillArrayWithRandomInt(-200, 200);

        Collection<int> result = new Collection<int>();

        foreach (var num in array)
        {
            if (num >= -100 && num <= 100)
            {
                result.Add(num);
            }
        }

        Console.WriteLine($"T1: Initial Array: {JsonSerializer.Serialize(array)}");
        Console.WriteLine($"T1: Result Array: {JsonSerializer.Serialize(result)} (Count: {result.Count()})");
        Console.WriteLine("-----------------------------------------------------------------\n");
    }

    public void RunSecond()
    {
        Console.WriteLine("-------------------------- Start Task 2 -------------------------");

        int[] a = new int[20];
        int[] b = new int[20];

        a.FillArrayWithRandomInt(500, 1500);

        for (var i = 0; i < a.Length; i++)
        {
            if (a[i] < 888)
            {
                b[i] = a[i];
            }
        }

        Array.Sort(b, (current, next) => next - current);

        Console.WriteLine($"T2: Initial Array: {JsonSerializer.Serialize(a)}");
        Console.WriteLine($"T2: Result Array: {JsonSerializer.Serialize(b)}");
        Console.WriteLine("-----------------------------------------------------------------");
    }
}