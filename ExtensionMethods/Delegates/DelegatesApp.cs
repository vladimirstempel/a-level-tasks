using System;

namespace ExtensionMethods;

public static class DelegatesApp
{
    public static void Start()
    {
        Operation operation = Subscriptions.Sum;
        operation += Subscriptions.Sum;

        var result = Calc(operation, 10, 10);

        Console.WriteLine("The sum of the results of two subscriptions: {0}", result);
    }

    private static int? Calc(Operation operation, int x, int y)
    {
        try
        {
            var result = 0;
            foreach (var @delegate in operation.GetInvocationList())
            {
                var func = (Operation)@delegate;
                result += func(x, y);
            }
            return result;
        }
        catch (Exception e)
        {
            Console.WriteLine("ERROR: {0}", e.Message);
            return default(int);
        }
    }
}