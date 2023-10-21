﻿namespace HomeWork4;

public static class ConsoleHelper
{
    public static void WriteLine(string stringToWrite, UseDivider useDivider = UseDivider.No)
    {
        if (useDivider is UseDivider.Before or UseDivider.Both)
        {
            WriteDivider();
        }

        Console.WriteLine(stringToWrite);

        if (useDivider is UseDivider.After or UseDivider.Both)
        {
            WriteDivider();
        }
    }

    private static void WriteDivider()
    {
        Console.WriteLine("\n----------------------------------------\n");
    }
}