using ConsoleEFApp.Data;
using ConsoleEFApp.Data.Entities;
using ConsoleEFApp.Models;
using ConsoleEFApp.Repositories.Abstractions;
using ConsoleEFApp.Services;
using ConsoleEFApp.Services.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ConsoleEFApp.Repositories;

public class PetRepository : IPetRepository
{
    private readonly ApplicationDbContext _dbContext;
    private readonly ILogger<PetRepository> _logger;

    public PetRepository(IDbContextWrapper<ApplicationDbContext> dbContextWrapper, ILogger<PetRepository> logger)
    {
        _dbContext = dbContextWrapper.DbContext;
        _logger = logger;
    }

    public async Task<int> Create(Pet pet)
    {
        var petEntity = pet.ToEntity(new PetEntity());

        var result = await _dbContext.Pets.AddAsync(petEntity);
        await _dbContext.SaveChangesAsync();

        _logger.LogInformation("Pet Entity Created: ID - {0}, Name - {1}, Age - {2}", result.Entity.Id,
            result.Entity.Name, result.Entity.Age);

        return result.Entity.Id;
    }

    public async Task<PetEntity?> Get(int id)
    {
        var entity = await _dbContext.Pets
            .Include(x => x.Breed)
            .Include(x => x.Category)
            .Include(x => x.Location)
            .Where(x => x.Id == id)
            .FirstOrDefaultAsync();

        _logger.LogInformation("Pet Entity Fetched: Name - {0}, Age - {1}, Breed - {2}, Category - {3}, Location - {4}",
            entity?.Name, entity?.Age, entity?.Breed?.BreedName, entity?.Category?.CategoryName,
            entity?.Location?.LocationName);

        return entity;
    }

    public async Task<List<PetEntity>?> GetAll()
    {
        var entities = await _dbContext.Pets
            .Include(x => x.Breed)
            .Include(x => x.Category)
            .Include(x => x.Location)
            .ToListAsync();

        _logger.LogInformation("Pet Entities Fetched: Count - {0}", entities.Count);

        return entities;
    }

    public async Task<int> GetUkrainianPetsCount()
    {
        var entities = await _dbContext.Pets
            .Include(x => x.Breed)
            .Include(x => x.Category)
            .Include(x => x.Location)
            .Where(x => x.Location.LocationName == "Ukraine" && x.Age > 3)
            .GroupBy(x => x.Category.CategoryName)
            .ToListAsync();

        return entities
            .DistinctBy(x => x.First().Breed.BreedName)
            .Count();
    }

    public async Task<int?> Update(int id, Pet location)
    {
        var petEntity = await _dbContext.Pets
            .Include(x => x.Breed)
            .Include(x => x.Category)
            .Include(x => x.Location)
            .Where(x => x.Id == id)
            .FirstOrDefaultAsync();

        if (petEntity == null)
        {
            return null;
        }

        petEntity.ToModel(location);

        _logger.LogInformation("Pet Entity Updated: Name - {0}, Age - {1}, Breed - {2}, Category - {3}, Location - {4}",
            petEntity.Name, petEntity.Age, petEntity.Breed?.BreedName, petEntity.Category?.CategoryName,
            petEntity.Location?.LocationName);

        _dbContext.Pets.Update(petEntity);

        await _dbContext.SaveChangesAsync();

        return petEntity.Id;
    }

    public async Task<bool> Delete(int id)
    {
        var petEntity = await _dbContext.Pets.Where(pet => pet.Id == id).FirstOrDefaultAsync();

        if (petEntity == null)
        {
            return false;
        }

        _dbContext.Pets.Remove(petEntity);

        await _dbContext.SaveChangesAsync();

        _logger.LogInformation("Pet Entity Deleted: ID - {0}", id);

        return true;
    }
}