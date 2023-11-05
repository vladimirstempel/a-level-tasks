using NewYearGifts.Models.Abstractions;

namespace NewYearGifts.Models;

public class Sweet : ISweet
{
    public string Name { get; set; }
    public double Weight { get; set; }
    public double SugarContent { get; set; }

    protected Sweet(string name, double weight, double sugarContent)
    {
        Name = name;
        Weight = weight;
        SugarContent = sugarContent;
    }

    public override string ToString()
    {
        return $"\nName: {Name}\nWeight: {Weight}\nSugar Content: {SugarContent}";
    }
}