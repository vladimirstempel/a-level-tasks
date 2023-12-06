using System.Collections.Generic;
using SaladMaker.Models;

namespace SaladMaker.Extensions;

public static class Search
{
    public static Vegetable[] FindVegetablesByCalories(this Salad salad, int minCalories, int maxCalories)
    {
        List<Vegetable> result = new List<Vegetable>();

        foreach (var veg in salad.Vegetables)
        {
            if (veg.CaloriesPer100g >= minCalories && veg.CaloriesPer100g <= maxCalories)
            {
                result.Add(veg);
            }
        }

        return result.ToArray();
    }
}