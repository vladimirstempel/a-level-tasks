using System;
using HomeWork4;

int[] randomArray = ArrayService.GetRandomIntArray();

ConsoleHelper.WriteLine($"Random array: {string.Join(", ", randomArray)}", UseDivider.Before);

var even = ArrayService.GetEvenIntArray(randomArray);
var odd = ArrayService.GetOddIntArray(randomArray);

ConsoleHelper.WriteLine($"Even numbers from array: {string.Join(", ", even)}", UseDivider.Before);
ConsoleHelper.WriteLine($"Odd numbers from array: {string.Join(", ", odd)}", UseDivider.After);

char[] evenChars = ArrayService.GetCharsFromNumbers(even);
char[] oddChars = ArrayService.GetCharsFromNumbers(odd);

ConsoleHelper.WriteLine($"Even chars from array: {string.Join(", ", evenChars)}");
ConsoleHelper.WriteLine($"Odd chars from array: {string.Join(", ", oddChars)}", UseDivider.After);

ConsoleHelper.WriteLine("Press any key to exit...");
Console.ReadKey();