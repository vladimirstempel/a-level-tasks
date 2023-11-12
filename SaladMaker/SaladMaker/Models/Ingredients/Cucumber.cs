namespace SaladMaker.Models.Ingredients;

public class Cucumber : Vegetable
{
    public double Proportion { get; }

    public Cucumber(double proportion) : base(proportion)
    {
        Proportion = proportion;
    }
}