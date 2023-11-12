namespace SaladMaker.Models.Ingredients;

public class Chicken : Meat
{
    public double Proportion { get; }

    public Chicken(double proportion) : base(proportion)
    {
    }
}