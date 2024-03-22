using Catalog.Host.Data;
using Catalog.Host.Data.Entities;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Host.Repositories;

public class CatalogTypeRepository : ICatalogTypeRepository
{
    private readonly ApplicationDbContext _dbContext;

    public CatalogTypeRepository(IDbContextWrapper<ApplicationDbContext> dbContextWrapper)
    {
        _dbContext = dbContextWrapper.DbContext;
    }

    public async Task<int?> Add(string type)
    {
        var result = await _dbContext.AddAsync(new CatalogType() { Type = type });

        await _dbContext.SaveChangesAsync();

        return result.Entity.Id;
    }

    public async Task<int?> Update(int id, string type)
    {
        var item = await _dbContext.CatalogTypes
            .Where((item) => item.Id == id)
            .FirstOrDefaultAsync();

        if (item == null)
        {
            return null;
        }

        item.Id = id;
        item.Type = type;

        await _dbContext.SaveChangesAsync();

        return item.Id;
    }

    public async Task<int?> Delete(int id)
    {
        var item = await _dbContext.CatalogTypes
            .Where((item) => item.Id == id)
            .FirstOrDefaultAsync();

        if (item == null)
        {
            return null;
        }

        _dbContext.Remove(item);

        await _dbContext.SaveChangesAsync();

        return id;
    }
}