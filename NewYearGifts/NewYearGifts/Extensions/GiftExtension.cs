using NewYearGifts.Models.Abstractions;

namespace NewYearGifts.Extensions;

public static class GiftExtension
{
    public static ISweet FindSweetByWeight(this IGift gift, double weight)
    {
        return Array.Find(gift.Sweets, sweet => sweet != null && sweet.Weight.Equals(weight));
    }
}