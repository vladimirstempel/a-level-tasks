using Lesson9.Entities;
using Lesson9.Exceptions;
using Lesson9.Models;
using Lesson9.Repositories.Abstractions;

namespace Lesson9.Repositories;

public class ShoeRepository : IShoeRepository
{
    private readonly List<ShoeEntity> _mockStorage = new ();
        
    public ShoeEntity? GetShoe(string id)
    {
        foreach (var item in _mockStorage)
        {
            if (item.Id.ToString() == id)
            {
                return item;
            }
        }

        throw new ShoeNotFoundException($"Show with id {id} not found");
    }

    public string AddShoe(Shoe shoe)
    {
        var shoeEntity = new ShoeEntity()
        {
            Id = Guid.NewGuid(),
            Name = shoe.Name,
            Description = shoe.Description,
            Size = shoe.Size,
            Style = shoe.Style
        };
        
        _mockStorage.Add(shoeEntity);

        return shoeEntity.Id.ToString();
    }

    public string[] AddShoes(List<Shoe> shoes)
    {
        var shoeEntities = shoes.Select(shoe => new ShoeEntity()
        {
            Id = Guid.NewGuid(),
            Name = shoe.Name,
            Description = shoe.Description,
            Size = shoe.Size,
            Style = shoe.Style
        }).ToList();
        
        _mockStorage.AddRange(shoeEntities);

        return shoeEntities.Select(shoe => shoe.Id.ToString()).ToArray();
    }

    public ShoeEntity[] GetShoeByText(string text)
    {
        return _mockStorage.Where(shoe => shoe.Name.ToLower().Contains(text.ToLower()) || shoe.Description.ToLower().Contains(text.ToLower())).ToArray();
    }

    public bool DeleteShoe(string id)
    {
        var shoe = GetShoe(id);

        return shoe != null && _mockStorage.Remove(shoe);
    }
}