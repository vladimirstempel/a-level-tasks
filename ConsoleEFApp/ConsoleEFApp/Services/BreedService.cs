using ConsoleEFApp.Data;
using ConsoleEFApp.Data.Entities;
using ConsoleEFApp.Models;
using ConsoleEFApp.Repositories.Abstractions;
using ConsoleEFApp.Services.Abstractions;
using Microsoft.Extensions.Logging;

namespace ConsoleEFApp.Services;

public class BreedService : BaseDataService<ApplicationDbContext>, IBreedService
{
    private readonly IBreedRepository _breedRepository;

    public BreedService(
        IBreedRepository breedRepository,
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<PetService> logger)
        : base(dbContextWrapper, logger)
    {
        _breedRepository = breedRepository;
    }

    public async Task<int> Create(Breed model)
    {
        var id = await _breedRepository.Create(model);

        return id;
    }

    public async Task<Breed?> Get(int id)
    {
        var entity = await _breedRepository.Get(id);

        if (entity == null)
        {
            return null;
        }

        var model = new Breed();

        entity.ToModel(model);

        return model;
    }

    public async Task<List<Breed>?> GetAll()
    {
        var entities = await _breedRepository.GetAll();

        if (entities == null)
        {
            return null;
        }
        
        var models = entities
            .Select<BreedEntity, Breed>(entity =>
            {
                var model = new Breed();
                entity.ToModel(model);
                return model;
            })
            .ToList();
        
        return models;
    }

    public async Task<int?> Update(int id, Breed model)
    {
        return await _breedRepository.Update(id, model);
    }

    public async Task<bool> Delete(int id)
    {
        return await _breedRepository.Delete(id);
    }
}