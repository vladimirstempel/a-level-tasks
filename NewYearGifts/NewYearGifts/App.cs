using NewYearGifts.Services.Abstractions;
using NewYearGifts.Extensions;

namespace NewYearGifts;

public class App
{
    private readonly IGiftService _giftService;
    
    public App(IGiftService giftService)
    {
        _giftService = giftService;
    }

    public void Start()
    {
        Console.WriteLine("App starts...\n");
        Console.WriteLine("Generating gift...\n");
        _giftService.GenerateGift();

        var randomSweet = _giftService.GetRandomSweetWeight();
        
        Console.WriteLine($"Random Sweet: {randomSweet.ToString()}\n");
        
        Console.WriteLine($"Found by wight: {_giftService.Gift.FindSweetByWeight(randomSweet.Weight).ToString()}\n");

        Console.WriteLine($"Gift total weight - {_giftService.GetTotalGiftWeight()}\n");
        
        _giftService.SortByWeight();
        Console.WriteLine($"Sorted by weight ASC:\n{_giftService.ListToString()}\n");
        
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}