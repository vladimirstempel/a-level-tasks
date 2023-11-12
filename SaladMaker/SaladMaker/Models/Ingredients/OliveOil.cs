namespace SaladMaker.Models.Ingredients;

public class OliveOil : Oil
{
    public double Proportion { get; }

    public OliveOil(double proportion) : base(proportion)
    {
    }
}