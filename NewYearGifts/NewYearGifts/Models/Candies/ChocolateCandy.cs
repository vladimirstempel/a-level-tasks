namespace NewYearGifts.Models.Candies;

public class ChocolateCandy : Candy
{
    public int CocoaPercentage { get; private set; }

    public ChocolateCandy(string name, double weight, double sugarContent, int cocoaPercentage)
        : base(name, weight, sugarContent)
    {
        CocoaPercentage = cocoaPercentage;
    }
}