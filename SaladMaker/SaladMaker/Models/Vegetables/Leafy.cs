namespace SaladMaker.Models.Vegetables;

public class Leafy : Vegetable
{
    public Leafy(string name, int calories)
    {
        Name = name;
        CaloriesPer100g = calories;
    }
}