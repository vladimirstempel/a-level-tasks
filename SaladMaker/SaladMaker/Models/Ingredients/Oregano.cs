namespace SaladMaker.Models.Ingredients;

public class Oregano : Spice
{
    public double Proportion { get; }

    public Oregano(double proportion) : base(proportion)
    {
    }
}