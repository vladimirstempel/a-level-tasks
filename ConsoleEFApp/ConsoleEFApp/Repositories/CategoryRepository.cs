using ConsoleEFApp.Data;
using ConsoleEFApp.Data.Entities;
using ConsoleEFApp.Models;
using ConsoleEFApp.Repositories.Abstractions;
using ConsoleEFApp.Services;
using ConsoleEFApp.Services.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ConsoleEFApp.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly ApplicationDbContext _dbContext;
    private readonly ILogger<CategoryRepository> _logger;

    public CategoryRepository(IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<CategoryRepository> logger)
    {
        _dbContext = dbContextWrapper.DbContext;
        _logger = logger;
    }

    public async Task<int> Create(Category category)
    {
        var categoryEntity = new CategoryEntity()
        {
            CategoryName = category.CategoryName
        };

        var result = await _dbContext.Categories.AddAsync(categoryEntity);

        await _dbContext.SaveChangesAsync();

        _logger.LogInformation("Category Entity Created: ID - {0}, Name - {1}", result.Entity.Id,
            result.Entity.CategoryName);

        return result.Entity.Id;
    }

    public async Task<CategoryEntity?> Get(int id)
    {
        var entity = await _dbContext.Categories
            .Include(entity => entity.Breeds)
            .Include(entity => entity.Pets)
            .Where(entity => entity.Id == id)
            .FirstOrDefaultAsync();

        _logger.LogInformation("Category Entity Fetched: Name - {0}, Breeds - {1}, Pets - {2}", entity.CategoryName,
            entity.Breeds?.Count, entity.Pets?.Count);

        return entity;
    }

    public async Task<List<CategoryEntity>?> GetAll()
    {
        return await _dbContext.Categories
            .Include(entity => entity.Breeds)
            .Include(entity => entity.Pets)
            .ToListAsync();
    }

    public async Task<int?> Update(int id, Category category)
    {
        var categoryEntity = await _dbContext.Categories
            .Include(entity => entity.Breeds)
            .Include(entity => entity.Pets)
            .Where(entity => entity.Id == id)
            .FirstOrDefaultAsync();

        if (categoryEntity == null)
        {
            return null;
        }

        categoryEntity.ToModel(category);

        _logger.LogInformation("Category Entity Updated: Name - {0}, Breeds - {1}, Pets - {2}",
            categoryEntity.CategoryName,
            categoryEntity.Breeds?.Count, categoryEntity.Pets?.Count);

        _dbContext.Categories.Update(categoryEntity);

        await _dbContext.SaveChangesAsync();

        return categoryEntity.Id;
    }

    public async Task<bool> Delete(int id)
    {
        var categoryEntity = await _dbContext.Categories
            .Where(entity => entity.Id == id)
            .FirstOrDefaultAsync();

        if (categoryEntity == null)
        {
            return false;
        }

        _dbContext.Categories.Remove(categoryEntity);

        await _dbContext.SaveChangesAsync();

        _logger.LogInformation("Category Entities Deleted: ID - {0}", id);

        return true;
    }
}