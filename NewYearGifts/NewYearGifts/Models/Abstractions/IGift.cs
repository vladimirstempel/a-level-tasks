namespace NewYearGifts.Models.Abstractions;

public interface IGift
{
    ISweet[] Sweets { get; }
    
    int MinGiftSize { get; }
    
    public double TotalWeight { get; }

    public void AddSweet(ISweet sweet);
}