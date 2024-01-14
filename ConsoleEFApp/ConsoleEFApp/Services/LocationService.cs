using ConsoleEFApp.Data;
using ConsoleEFApp.Data.Entities;
using ConsoleEFApp.Models;
using ConsoleEFApp.Repositories.Abstractions;
using ConsoleEFApp.Services.Abstractions;
using Microsoft.Extensions.Logging;

namespace ConsoleEFApp.Services;

public class LocationService : BaseDataService<ApplicationDbContext>, ILocationService
{
    private readonly ILocationRepository _locationRepository;

    public LocationService(
        ILocationRepository locationRepository,
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<PetService> logger)
        : base(dbContextWrapper, logger)
    {
        _locationRepository = locationRepository;
    }

    public async Task<int> Create(Location model)
    {
        var id = await _locationRepository.Create(model);

        return id;
    }

    public async Task<Location?> Get(int id)
    {
        var entity = await _locationRepository.Get(id);

        if (entity == null)
        {
            return null;
        }

        var model = new Location();

        entity.ToModel(model);

        return model;
    }

    public async Task<List<Location>?> GetAll()
    {
        var entities = await _locationRepository.GetAll();

        if (entities == null)
        {
            return null;
        }
        
        var models = entities
            .Select<LocationEntity, Location>(entity =>
            {
                var model = new Location();
                entity.ToModel(model);
                return model;
            })
            .ToList();
        
        return models;
    }

    public async Task<int?> Update(int id, Location model)
    {
        return await _locationRepository.Update(id, model);
    }

    public async Task<bool> Delete(int id)
    {
        return await _locationRepository.Delete(id);
    }
}