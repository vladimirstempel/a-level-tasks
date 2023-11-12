namespace SaladMaker.Models.Ingredients;

public class Cheese : Diary
{
    public double Proportion { get; }

    public Cheese(double proportion) : base(proportion)
    {
        Proportion = proportion;
    }
}