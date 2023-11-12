using SaladMaker.Common;
using SaladMaker.Models.Abstractions;

namespace SaladMaker.Models.Ingredients;

public class Grain : Ingredient
{
    public const IngredientType type = IngredientType.Grain;
    public const ProportionType proportionType = ProportionType.Cup;

    public Grain(double proportion) : base(type, proportionType, proportion)
    {
    }
}