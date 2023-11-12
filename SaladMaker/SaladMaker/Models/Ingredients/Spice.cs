using SaladMaker.Common;
using SaladMaker.Models.Abstractions;

namespace SaladMaker.Models.Ingredients;

public class Spice : Ingredient
{
    public const IngredientType type = IngredientType.Spice;
    public const ProportionType proportionType = ProportionType.TeaSpoon;

    public Spice(double proportion) : base(type, proportionType, proportion)
    {
    }
}