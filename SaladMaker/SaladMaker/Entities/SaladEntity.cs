namespace SaladMaker.Entities;

public class SaladEntity
{
    public readonly IngredientEntity[] IngredientEntities;

    public SaladEntity(int ingredientSize)
    {
        IngredientEntities = new IngredientEntity[ingredientSize];
    }
}