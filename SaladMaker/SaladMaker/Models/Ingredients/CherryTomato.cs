namespace SaladMaker.Models.Ingredients;

public class CherryTomato : Tomato
{
    public double Proportion { get; }

    public CherryTomato(double proportion) : base(proportion)
    {
        Proportion = proportion;
    }
}