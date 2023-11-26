using Lesson9.Common;
using Lesson9.Exceptions;
using Lesson9.Models;
using Lesson9.Services.Abstractions;

namespace Lesson9;

public class App
{
    private readonly IShoeService _shoeService;

    public App(IShoeService shoeService)
    {
        _shoeService = shoeService;
    }

    public void Run()
    {
        try
        {
            var ids = _shoeService.AddShoes(GetMockShoes());

            var shoes = _shoeService.GetShoeByText("air");
        }
        catch (ShoeNotFoundException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public List<Shoe> GetMockShoes()
    {
        var shoes = new List<Shoe>();
        
        shoes.Add(new Shoe()
        {
            Name = "Nike Air",
            Description = "Very good",
            Size = 45,
            Style = StyleType.Runners
        });
        
        shoes.Add(new Shoe()
        {
            Name = "Nike",
            Description = "Very good shoe",
            Size = 42,
            Style = StyleType.Snikers
        });
        
        shoes.Add(new Shoe()
        {
            Name = "Adidas",
            Description = "Very very good",
            Size = 46,
            Style = StyleType.Oxford
        });
        
        return shoes;
    }
}