using SaladMaker.Models.Abstractions;

namespace SaladMaker.Models;

public class Salad
{
    public readonly IIngredient[] IngredientEntities;

    public Salad(IIngredient[] ingredients)
    {
        IngredientEntities = ingredients;
    }
}