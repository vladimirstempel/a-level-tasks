namespace SaladMaker.Models;

public class Salad
{
    private Vegetable[] vegetables;

    public Vegetable[] Vegetables => vegetables;

    public Salad(Vegetable[] veggies)
    {
        vegetables = veggies;
    }

    public int CalculateTotalCalories()
    {
        int totalCalories = 0;
        foreach (var veg in vegetables)
        {
            totalCalories += veg.CaloriesPer100g;
        }
        return totalCalories;
    }
}