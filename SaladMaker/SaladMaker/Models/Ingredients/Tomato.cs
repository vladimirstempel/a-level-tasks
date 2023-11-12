namespace SaladMaker.Models.Ingredients;

public class Tomato : Vegetable
{
    public double Proportion { get; }

    public Tomato(double proportion) : base(proportion)
    {
        Proportion = proportion;
    }
}