using Catalog.Host.Data;
using Catalog.Host.Data.Entities;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Host.Repositories;

public class CatalogBrandRepository : ICatalogBrandRepository
{
    private readonly ApplicationDbContext _dbContext;

    public CatalogBrandRepository(IDbContextWrapper<ApplicationDbContext> dbContextWrapper)
    {
        _dbContext = dbContextWrapper.DbContext;
    }

    public async Task<int?> Add(string brand)
    {
        var result = await _dbContext.AddAsync(new CatalogBrand() { Brand = brand });

        await _dbContext.SaveChangesAsync();

        return result.Entity.Id;
    }

    public async Task<int?> Update(int id, string brand)
    {
        var item = await _dbContext.CatalogBrands
            .Where((item) => item.Id == id)
            .FirstOrDefaultAsync();

        if (item == null)
        {
            return null;
        }

        item.Id = id;
        item.Brand = brand;

        await _dbContext.SaveChangesAsync();

        return item.Id;
    }

    public async Task<int?> Delete(int id)
    {
        var item = await _dbContext.CatalogBrands
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