namespace SaladMaker.Models.Vegetables;

public class Stem : Vegetable
{
    public Stem(string name, int calories)
    {
        Name = name;
        CaloriesPer100g = calories;
    }
}