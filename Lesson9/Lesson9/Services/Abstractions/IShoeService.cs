using Lesson9.Models;

namespace Lesson9.Services.Abstractions;

public interface IShoeService
{
    Shoe GetShoe(string id);
    string AddShoe(Shoe shoe);
    string[] AddShoes(List<Shoe> shoes);
    bool DeleteShoe(string id);
    Shoe[] GetShoeByText(string text);
}