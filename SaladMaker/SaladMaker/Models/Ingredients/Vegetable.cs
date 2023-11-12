using SaladMaker.Common;
using SaladMaker.Models.Abstractions;

namespace SaladMaker.Models.Ingredients;

public class Vegetable : Ingredient
{
    public const IngredientType type = IngredientType.Vegetable;
    public const ProportionType proportionType = ProportionType.Piece;
    public Vegetable(double proportion) : base(type, proportionType, proportion)
    {
    }
}