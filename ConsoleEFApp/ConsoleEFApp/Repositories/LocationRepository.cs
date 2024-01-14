using ConsoleEFApp.Data;
using ConsoleEFApp.Data.Entities;
using ConsoleEFApp.Models;
using ConsoleEFApp.Repositories.Abstractions;
using ConsoleEFApp.Services;
using ConsoleEFApp.Services.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ConsoleEFApp.Repositories;

public class LocationRepository : ILocationRepository
{
    private readonly ApplicationDbContext _dbContext;
    private readonly ILogger<LocationRepository> _logger;

    public LocationRepository(IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<LocationRepository> logger)
    {
        _dbContext = dbContextWrapper.DbContext;
        _logger = logger;
    }

    public async Task<int> Create(Location location)
    {
        var locationEntity = new LocationEntity()
        {
            LocationName = location.LocationName
        };

        var result = await _dbContext.Locations.AddAsync(locationEntity);

        await _dbContext.SaveChangesAsync();

        _logger.LogInformation("Location Entity Created: ID - {0}, Name - {1}", result.Entity.Id,
            result.Entity.LocationName);

        return result.Entity.Id;
    }

    public async Task<LocationEntity?> Get(int id)
    {
        var entity = await _dbContext.Locations
            .Where(entity => entity.Id == id)
            .FirstOrDefaultAsync();

        _logger.LogInformation("Location Entity Fetched: Name - {0}", entity?.LocationName);

        return entity;
    }

    public async Task<List<LocationEntity>?> GetAll()
    {
        var entities = await _dbContext.Locations.ToListAsync();

        _logger.LogInformation("Location Entities Fetched: Count - {0}", entities.Count);

        return entities;
    }

    public async Task<int?> Update(int id, Location location)
    {
        var locationEntity = await _dbContext.Locations
            .Where(entity => entity.Id == id)
            .FirstOrDefaultAsync();

        if (locationEntity == null)
        {
            return null;
        }

        locationEntity.ToModel(location);

        _logger.LogInformation("Location Entity Updated: Name - {0}", locationEntity.LocationName);

        _dbContext.Locations.Update(locationEntity);

        await _dbContext.SaveChangesAsync();

        return locationEntity.Id;
    }

    public async Task<bool> Delete(int id)
    {
        var locationEntity = await _dbContext.Locations
            .Where(entity => entity.Id == id)
            .FirstOrDefaultAsync();

        if (locationEntity == null)
        {
            return false;
        }

        _dbContext.Locations.Remove(locationEntity);

        await _dbContext.SaveChangesAsync();

        _logger.LogInformation("Location Entities Deleted: ID - {0}", id);

        return true;
    }
}