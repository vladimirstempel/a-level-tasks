using System.Text;
using NewYearGifts.Models;
using NewYearGifts.Models.Abstractions;
using NewYearGifts.Models.Candies;
using NewYearGifts.Services.Abstractions;

namespace NewYearGifts.Services;

public class GiftService : IGiftService
{
    public IGift Gift { get; }

    public GiftService(int giftSize)
    {
        Gift = new Gift(giftSize);
    }
    
    public void AddSweet(ISweet sweet)
    {
        Gift.AddSweet(sweet);
    }

    public void SortByWeight()
    {
        Array.Sort(Gift.Sweets, (a, b) => a.Weight.CompareTo(b.Weight));
    }

    public double GetTotalGiftWeight()
    {
        return Gift.TotalWeight;
    }

    public string ListToString()
    {
        var sb = new StringBuilder();

        for (var i = 0; i < Gift.Sweets.Length; i++)
        {
            sb.AppendLine($"Sweet #{i + 1}: {Gift.Sweets[i].ToString()}\n");
        }
        
        return sb.ToString();
    }

    public ISweet GetRandomSweetWeight()
    {
        var random = new Random();
        var randomIndex = random.Next(0, Gift.Sweets.Length);

        return Gift.Sweets[randomIndex];
    }

    public void GenerateGift()
    {
        // Generate sweets
        for (int i = 1; i <= Gift.Sweets.Length / (Gift.Sweets.Length / Gift.MinGiftSize); i++)
        {
            ICandy candy = new Candy($"Candy {i}", 20 + i * 5.5, 10 + i * 3.3);
            ICandy chocolateCandy = new ChocolateCandy($"Nuts Chocolate {i}", 40 + i * 4.5, 15 + i * 3.3, 2 * i);
            ICandy chocolateFilledCandy = new ChocolateFilledCandy($"Filled Candy {i}", 20 + i * 5, 10 + i * 3, 2 * i, "Caramel Filling");
            ICandy gummyCandy = new GummyCandy($"Nuts Chocolate {i}", 40 + i * 5, 15 + i * 3, "Random Flavor");
            ICandy gummyFilledCandy = new GummyFilledCandy($"Chocolate {i}", 40 + i * 5, 15 + i * 3, "Random Flavor", true, "Caramel Filling");

            AddSweet(candy);
            AddSweet(chocolateCandy);
            AddSweet(chocolateFilledCandy);
            AddSweet(gummyCandy);
            AddSweet(gummyFilledCandy);
        }
    }
}