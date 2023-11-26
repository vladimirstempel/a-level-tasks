using System;
using DelegatesApp.Delegates;

namespace DelegatesApp;

public static class Program
{
    public static void Main()
    {
        var class1 = new Class1();
        var class2 = new Class2();

        Result result = class2.Calc(class1.Multiply, 10, 10);

        Show(result(10)); // True
        Show(result(3)); // False
    }

    private static void Show(bool result)
    {
        Console.WriteLine("The result of the program: {0}", result.ToString());
    }
}