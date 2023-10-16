using System;

double weight;
double height;
try
{
    Console.WriteLine("Enter a weight (kg):");
    weight = Convert.ToDouble(Console.ReadLine().Replace(".", ","));

    Console.WriteLine("Enter a height (m):");
    height = Convert.ToDouble(Console.ReadLine().Replace(".", ","));
}
catch
{
    Console.WriteLine("Please, enter number (e.g. 100, 100.5, 100,5)");
    return;
}

double bmi = weight / (height * height);
string weightStatus = "";

switch (bmi)
{
    case < 18.5:
        weightStatus = "Underweight";
        break;
    case >= 18.5 and <= 24.9:
        weightStatus = "Healthy Weight";
        break;
    case >= 25 and <= 29.9:
        weightStatus = "Overweight";
        break;
    case > 30:
        weightStatus = "Obesity";
        break;
}


Console.WriteLine($"Bmi: {bmi:0.#}");
Console.WriteLine($"Weight status: {weightStatus}");
