using System;
using SaladMaker.Extensions;
using SaladMaker.Models;
using SaladMaker.Models.Vegetables;

namespace SaladMaker;

public class App
{
    public void Start()
    {
        // Creating various vegetable objects
        Leafy spinach = new Leafy("Spinach", 23);
        Root carrot = new Root("Carrot", 41);
        Stem asparagus = new Stem("Asparagus", 20);
        Leafy lettuce = new Leafy("Lettuce", 15);

        // Creating an array of vegetables
        Vegetable[] veggies = { spinach, carrot, asparagus, lettuce };

        // Creating a salad
        Salad mySalad = new Salad(veggies);

        // Calculating total calories in the salad
        int totalCalories = mySalad.CalculateTotalCalories();
        Console.WriteLine($"Total calories in the salad: {totalCalories}");

        // Finding vegetables in the salad based on calories criteria
        int minCalories = 20;
        int maxCalories = 40;
        Vegetable[] selectedVegetables = mySalad.FindVegetablesByCalories(minCalories, maxCalories);

        Console.WriteLine($"Vegetables in the salad between {minCalories} and {maxCalories} calories:");
        foreach (var veg in selectedVegetables)
        {
            Console.WriteLine($"{veg.Name}: {veg.CaloriesPer100g} calories");
        }
    }
}