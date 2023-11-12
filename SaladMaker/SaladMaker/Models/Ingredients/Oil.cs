using SaladMaker.Common;
using SaladMaker.Models.Abstractions;

namespace SaladMaker.Models.Ingredients;

public class Oil : Ingredient
{
    public const IngredientType type = IngredientType.Oil;
    public const ProportionType proportionType = ProportionType.TableSpoon;

    public Oil(double proportion) : base(type, proportionType, proportion)
    {
    }
}