using SaladMaker.Models.Abstractions;

namespace SaladMaker.Models.Salads;

public class GreekSalad : Salad
{
    private IIngredient[] _ingredients;

    public GreekSalad(int ingredientSize, IIngredient[] ingredients) : base(ingredientSize)
    {
        _ingredients = ingredients;
    }
}