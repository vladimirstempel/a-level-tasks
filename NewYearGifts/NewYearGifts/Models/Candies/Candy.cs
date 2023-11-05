using NewYearGifts.Models.Abstractions;

namespace NewYearGifts.Models.Candies;

public class Candy : Sweet, ICandy
{
    public Candy(string name, double weight, double sugarContent) : base(name, weight, sugarContent)
    {
    }
}