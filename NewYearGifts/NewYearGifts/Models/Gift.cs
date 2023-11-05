using NewYearGifts.Models.Abstractions;

namespace NewYearGifts.Models;

public class Gift : IGift
{
    
    private readonly ISweet[] _sweets;

    public double TotalWeight => _sweets.Sum(sweet => sweet.Weight);

    public ISweet[] Sweets => _sweets;
    public int MinGiftSize => 5;
    
    public Gift(int size)
    {
        _sweets = new Sweet[size < MinGiftSize ? MinGiftSize : size];
    }

    public void AddSweet(ISweet sweet)
    {
        for (int i = 0; i < _sweets.Length; i++)
        {
            if (_sweets[i] == null)
            {
                _sweets[i] = sweet;
                break;
            }
        }
    }
}