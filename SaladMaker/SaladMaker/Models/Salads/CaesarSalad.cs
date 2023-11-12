using SaladMaker.Models.Abstractions;
using SaladMaker.Models.Ingredients;

namespace SaladMaker.Models.Salads;

public class CaesarSalad : Salad
{
    private static readonly IIngredient[] Ingredients = new IIngredient[]
    {
        new Lettuce(2),
        new Chicken(3),
        new Croutons(0.5),
        new ParmesanCheese(1),
        new CaesarDressing(2)
    };

    public CaesarSalad() : base(Ingredients)
    {
    }
}