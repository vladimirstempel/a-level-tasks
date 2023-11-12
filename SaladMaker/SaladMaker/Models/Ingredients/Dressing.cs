using SaladMaker.Common;
using SaladMaker.Models.Abstractions;

namespace SaladMaker.Models.Ingredients;

public class Dressing : Ingredient
{
    public const IngredientType type = IngredientType.Dressing;
    public const ProportionType proportionType = ProportionType.TableSpoon;

    public Dressing(double proportion) : base(type, proportionType, proportion)
    {
    }
}