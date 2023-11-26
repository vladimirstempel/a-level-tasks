using Lesson9.Entities;
using Lesson9.Models;
using Lesson9.Repositories.Abstractions;
using Lesson9.Services.Abstractions;

namespace Lesson9.Services;

public class ShoeService : IShoeService
{
    private readonly IShoeRepository _shoeRepository;

    public ShoeService(IShoeRepository shoeRepository)
    {
        _shoeRepository = shoeRepository;
    }

    public Shoe GetShoe(string id)
    {
        var shoeEntity = _shoeRepository.GetShoe(id);

        return new Shoe()
        {
            Id = shoeEntity.Id,
            Description = shoeEntity.Description,
            Size = shoeEntity.Size,
            Style = shoeEntity.Style
        };
    }

    public string AddShoe(Shoe shoe)
    {
        return _shoeRepository.AddShoe(shoe);
    }

    public bool DeleteShoe(string id)
    {
        return _shoeRepository.DeleteShoe(id);
    }

    public Shoe[] GetShoeByText(string text)
    {
        var entities = _shoeRepository.GetShoeByText(text);

        return entities.Select(entity => new Shoe()
        {
            Id = entity.Id,
            Name = entity.Name,
            Description = entity.Description,
            Size = entity.Size,
            Style = entity.Style
        }).ToArray();
    }

    public string[] AddShoes(List<Shoe> shoes)
    {
        return _shoeRepository.AddShoes(shoes);
    }
}