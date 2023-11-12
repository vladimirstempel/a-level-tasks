namespace SaladMaker.Models.Ingredients;

public class Olive : Vegetable
{
    public double Proportion { get; }

    public Olive(double proportion) : base(proportion)
    {
        Proportion = proportion;
    }
}