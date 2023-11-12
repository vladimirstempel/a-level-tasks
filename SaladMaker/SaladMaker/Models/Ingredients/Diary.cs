using SaladMaker.Common;
using SaladMaker.Models.Abstractions;

namespace SaladMaker.Models.Ingredients;

public class Diary : Ingredient
{
    public const IngredientType type = IngredientType.Dairy;
    public const ProportionType proportionType = ProportionType.Oz;

    public Diary(double proportion) : base(type, proportionType, proportion)
    {
    }
}