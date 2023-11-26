using Lesson9.Entities;
using Lesson9.Models;

namespace Lesson9.Repositories.Abstractions;

public interface IShoeRepository
{
    ShoeEntity? GetShoe(string id);
    string AddShoe(Shoe shoe);
    string[] AddShoes(List<Shoe> shoes);
    bool DeleteShoe(string id);
    ShoeEntity[] GetShoeByText(string text);
}