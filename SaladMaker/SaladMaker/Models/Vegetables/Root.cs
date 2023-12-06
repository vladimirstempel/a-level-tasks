namespace SaladMaker.Models.Vegetables;

public class Root : Vegetable
{
    public Root(string name, int calories)
    {
        Name = name;
        CaloriesPer100g = calories;
    }
}