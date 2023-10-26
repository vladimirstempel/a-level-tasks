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

int evenUppercaseCount = ArrayService.CountUppercaseFromArray(evenChars);
int oddUppercaseCount = ArrayService.CountUppercaseFromArray(oddChars);

if (evenUppercaseCount > oddUppercaseCount)
{
    ConsoleHelper.WriteLine($"Even uppercase chars count: {evenUppercaseCount}", UseDivider.After);
}
else if (oddUppercaseCount > evenUppercaseCount)
{
    ConsoleHelper.WriteLine($"Odd uppercase chars count: {oddUppercaseCount}", UseDivider.After);
}
else
{
    ConsoleHelper.WriteLine("Both even and odd has equal uppercase chars count.");
    ConsoleHelper.WriteLine($"Even: {evenUppercaseCount}");
    ConsoleHelper.WriteLine($"Odd: {oddUppercaseCount}", UseDivider.After);
}

ConsoleHelper.Write($"Even chars from array: {string.Join(", ", evenChars)}; ");
ConsoleHelper.Write($"Odd chars from array: {string.Join(", ", oddChars)}", UseDivider.After);

ConsoleHelper.WriteLine("Press any key to exit...");
Console.ReadKey();