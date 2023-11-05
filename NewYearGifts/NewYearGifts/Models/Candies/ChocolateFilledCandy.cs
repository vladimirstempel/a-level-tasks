using NewYearGifts.Models.Abstractions;

namespace NewYearGifts.Models.Candies;

public class ChocolateFilledCandy : ChocolateCandy
{
    public string Filling { get; private set; }

    public ChocolateFilledCandy(string name, double weight, double sugarContent, int cocoaPercentage, string filling)
        : base(name, weight, sugarContent, cocoaPercentage)
    {
        Filling = filling;
    }
}