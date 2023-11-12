namespace SaladMaker.Models.Ingredients;

public class Lettuce : Vegetable
{
    public double Proportion { get; }

    public Lettuce(double proportion) : base(proportion)
    {
    }
}