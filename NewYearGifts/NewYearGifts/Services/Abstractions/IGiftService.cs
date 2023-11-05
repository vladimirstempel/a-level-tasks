using NewYearGifts.Models.Abstractions;

namespace NewYearGifts.Services.Abstractions;

public interface IGiftService
{
    IGift Gift { get; }
    
    void AddSweet(ISweet sweet);

    void SortByWeight();

    public double GetTotalGiftWeight();
    
    public ISweet GetRandomSweetWeight();
    
    public void GenerateGift();
    
    public string ListToString();
}