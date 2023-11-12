namespace SaladMaker.Models.Ingredients;

public class Onion : Vegetable
{
    public double Proportion { get; }

    public Onion(double proportion) : base(proportion)
    {
        Proportion = proportion;
    }
}