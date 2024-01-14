using ConsoleEFApp.Data;
using ConsoleEFApp.Data.Entities;
using ConsoleEFApp.Models;
using ConsoleEFApp.Repositories.Abstractions;
using ConsoleEFApp.Services.Abstractions;
using Microsoft.Extensions.Logging;

namespace ConsoleEFApp.Services;

public class PetService : BaseDataService<ApplicationDbContext>, IPetService
{
    private readonly IPetRepository _petRepository;

    public PetService(
        IPetRepository petRepository,
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<PetService> logger)
        : base(dbContextWrapper, logger)
    {
        _petRepository = petRepository;
    }

    public async Task<int> Create(Pet model)
    {
        var petId = await _petRepository.Create(model);

        return petId;
    }

    public async Task<Pet?> Get(int id)
    {
        var petEntity = await _petRepository.Get(id);

        if (petEntity == null)
        {
            return null;
        }

        var pet = new Pet();

        petEntity.ToModel(pet);

        return pet;
    }

    public async Task<List<Pet>?> GetAll()
    {
        var petEntities = await _petRepository.GetAll();

        if (petEntities == null)
        {
            return null;
        }
        
        var pets = petEntities
            .Select<PetEntity, Pet>(x =>
            {
                var pet = new Pet();
                x.ToModel(pet);
                return pet;
            })
            .ToList();
        
        return pets;
    }

    public async Task<int> GetUkrainianPetsCount()
    {
        return await _petRepository.GetUkrainianPetsCount();
    }

    public async Task<int?> Update(int id, Pet pet)
    {
        return await _petRepository.Update(id, pet);
    }

    public async Task<bool> Delete(int id)
    {
        return await _petRepository.Delete(id);
    }
}