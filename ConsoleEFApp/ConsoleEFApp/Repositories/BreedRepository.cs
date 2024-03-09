using ConsoleEFApp.Data;
using ConsoleEFApp.Data.Entities;
using ConsoleEFApp.Models;
using ConsoleEFApp.Repositories.Abstractions;
using ConsoleEFApp.Services;
using ConsoleEFApp.Services.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ConsoleEFApp.Repositories;

public class BreedRepository : IBreedRepository
{
    private readonly ApplicationDbContext _dbContext;
    private readonly ILogger<BreedRepository> _logger;

    public BreedRepository(IDbContextWrapper<ApplicationDbContext> dbContextWrapper, ILogger<BreedRepository> logger)
    {
        _dbContext = dbContextWrapper.DbContext;
        _logger = logger;
    }

    public async Task<int> Create(Breed location)
    {
        var breedEntity = new BreedEntity()
        {
            BreedName = location.BreedName,
            CategoryId = location.Category.Id,
        };

        var result = await _dbContext.Breeds.AddAsync(breedEntity);
        await _dbContext.SaveChangesAsync();

        _logger.LogInformation("Breed Entity Created: ID - {0}, Name - {1}", result.Entity.Id,
            result.Entity.BreedName);

        return result.Entity.Id;
    }

    public async Task<BreedEntity?> Get(int id)
    {
        var entity = await _dbContext.Breeds
            .Include(entity => entity.Category)
            .Where(entity => entity.Id == id).FirstOrDefaultAsync();

        _logger.LogInformation("Breed Entity Updated: Name - {0}, Category - {1}", entity.BreedName,
            entity.Category?.CategoryName);

        return entity;
    }

    public async Task<List<BreedEntity>?> GetAll()
    {
        var entities = await _dbContext.Breeds
            .Include(entity => entity.Category)
            .ToListAsync();

        _logger.LogInformation("Breed Entities Fetched: Count - {0}", entities.Count);

        return entities;
    }

    public async Task<int?> Update(int id, Breed location)
    {
        var breedEntity = await _dbContext.Breeds
            .Include(entity => entity.Category)
            .Where(entity => entity.Id == id)
            .FirstOrDefaultAsync();

        if (breedEntity == null)
        {
            return null;
        }

        breedEntity.ToModel(location);

        _logger.LogInformation("Breed Entity Updated: Name - {0}, Category - {1}", breedEntity.BreedName,
            breedEntity.Category?.CategoryName);

        _dbContext.Breeds.Update(breedEntity);

        await _dbContext.SaveChangesAsync();

        return breedEntity.Id;
    }

    public async Task<bool> Delete(int id)
    {
        var breedEntity = await _dbContext.Breeds
            .Where(entity => entity.Id == id)
            .FirstOrDefaultAsync();

        if (breedEntity == null)
        {
            return false;
        }

        _dbContext.Breeds.Remove(breedEntity);

        await _dbContext.SaveChangesAsync();

        _logger.LogInformation("Breed Entity Deleted: ID - {0}", id);

        return true;
    }
}