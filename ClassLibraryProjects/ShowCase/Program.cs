﻿using UtilityLibraries;

int row = 0;

do
{
    if (row == 0 || row >= 25)
    {
        ResetConsole();
    }

    var input = Console.ReadLine();
    if (string.IsNullOrEmpty(input))
    {
        break;
    }

    Console.WriteLine($"Input: {input}");
    Console.WriteLine("Begins with uppercase? " + $"{(input.StartsWithUpper() ? "Yes" : "No")}");
    Console.WriteLine();
    row += 4;
} while (true);

return;

void ResetConsole()
{
    if (row > 0)
    {
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    Console.Clear();
    Console.WriteLine($"{Environment.NewLine}Press <Enter> only to exit;" +
                      $" otherwise, enter a string and press <Enter>:{Environment.NewLine}");

    row = 3;
}