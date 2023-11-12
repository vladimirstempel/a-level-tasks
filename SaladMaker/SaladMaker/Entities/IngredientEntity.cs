using SaladMaker.Common;

namespace SaladMaker.Entities;

public class IngredientEntity
{
    public IngredientType Type { get; }
    public string Name { get; }

    public IngredientEntity(IngredientType type, string name)
    {
        Type = type;
        Name = name;
    }
}