using NewYearGifts.Models.Abstractions;

namespace NewYearGifts.Models.Candies;

public class GummyCandy : Candy
{
    public string Flavor { get; private set; }
    
    public GummyCandy(string name, double weight, double sugarContent, string flavor)
        : base(name, weight, sugarContent)
    {
        Flavor = flavor;
    }
}