using NewYearGifts.Models.Abstractions;

namespace NewYearGifts.Models.Candies;

public class GummyFilledCandy : GummyCandy
{
    private bool Filled { get; }
    public string? Filling { get; private set; }

    public GummyFilledCandy(string name, double weight, double sugarContent, string flavor,  bool filled, string filling = "")
        : base(name, weight, sugarContent, flavor)
    {
        Filled = filled;
        
        if (Filled)
        {
            Filling = filling;
        }
    }
}