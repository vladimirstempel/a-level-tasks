using SaladMaker.Common;

namespace SaladMaker.Models.Abstractions;

public abstract class Ingredient : IIngredient
{
    public IngredientType Type { get; }
    public ProportionType ProportionType { get; }
    public double Proportion { get; }

    public Ingredient(IngredientType type, ProportionType proportionType, double proportion)
    {
        Type = type;
        ProportionType = proportionType;
        Proportion = proportion;
    }
}