using ConsoleEFApp.Data.Entities;
using ConsoleEFApp.Models;

namespace ConsoleEFApp.Repositories.Abstractions;

public interface IPetRepository : IBaseRepository<PetEntity, Pet>
{
    Task<int> GetUkrainianPetsCount();
}