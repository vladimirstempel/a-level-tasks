using SaladMaker.Common;

namespace SaladMaker.Models.Abstractions;

public interface IIngredient
{
    public IngredientType Type { get; }
    public ProportionType ProportionType { get; }
    public double Proportion { get; }
}