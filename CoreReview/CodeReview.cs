using System;

public class Calculator // incorrect case and name
{
    // myVar - remove because not used
    public void CalculateTotal() // Incorrect case
    {
        // Fix formatting
        int value1 = 5;
        int value2 = 10;

        int result = value1 + value2;

        Console.WriteLine($"The result is: {result}"); // Unnecessary concatenation
    }
}

namespace AnotherNamespace
{
    public class AnotherClass
    {
        public void AnotherMethod()
        {
            if (true) // fix space
            {
                // Порушено правило щодо розташування фігурних дужок
                // Код
            }

            int myVariable = 5; // Fix incorrect var name
        }
    }
}

public class Program
{
    public static void Calculation() // Fix method name
    {
        // Fix formatting
        int a = 10;
        int b = 20;
        int result = a + b;

        Console.WriteLine($"The result is: {result}"); // Unnecessary concatenation
    }

    public static void Main()
    {
        // Код
    }
}