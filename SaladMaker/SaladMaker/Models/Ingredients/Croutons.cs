namespace SaladMaker.Models.Ingredients;

public class Croutons : Grain
{
    public double Proportion { get; }

    public Croutons(double proportion) : base(proportion)
    {
        Proportion = proportion;
    }
}