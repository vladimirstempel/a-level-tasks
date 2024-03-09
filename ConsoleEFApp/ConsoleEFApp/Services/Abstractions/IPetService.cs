using ConsoleEFApp.Models;

namespace ConsoleEFApp.Services.Abstractions;

public interface IPetService : IBaseService<Pet>
{
    Task<int> GetUkrainianPetsCount();
}