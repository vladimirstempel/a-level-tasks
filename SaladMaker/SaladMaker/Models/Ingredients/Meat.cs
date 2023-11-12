using SaladMaker.Common;
using SaladMaker.Models.Abstractions;

namespace SaladMaker.Models.Ingredients;

public class Meat : Ingredient
{
    public const IngredientType type = IngredientType.Meat;
    public const ProportionType proportionType = ProportionType.Oz;

    public Meat(double proportion) : base(type, proportionType, proportion)
    {
    }
}