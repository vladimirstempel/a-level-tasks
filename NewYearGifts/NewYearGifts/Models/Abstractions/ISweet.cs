namespace NewYearGifts.Models.Abstractions;

public interface ISweet
{
    public string Name { get; set; }
    public double Weight { get; set; }
    public double SugarContent { get; set; }

    public string ToString();
}