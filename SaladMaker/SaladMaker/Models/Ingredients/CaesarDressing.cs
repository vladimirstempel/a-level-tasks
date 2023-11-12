namespace SaladMaker.Models.Ingredients;

public class CaesarDressing : Dressing
{
    public double Proportion { get; }

    public CaesarDressing(double proportion) : base(proportion)
    {
        Proportion = proportion;
    }
}