using Catalog.Host.Data;
using Catalog.Host.Data.Entities;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Host.Repositories;

public class CatalogItemRepository : ICatalogItemRepository
{
    private readonly ApplicationDbContext _dbContext;
    private readonly ILogger<CatalogItemRepository> _logger;

    public CatalogItemRepository(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<CatalogItemRepository> logger)
    {
        _dbContext = dbContextWrapper.DbContext;
        _logger = logger;
    }

    public async Task<PaginatedItems<CatalogItem>> GetByPageAsync(int pageIndex, int pageSize)
    {
        var totalItems = await _dbContext.CatalogItems
            .LongCountAsync();

        var itemsOnPage = await _dbContext.CatalogItems
            .Include(i => i.CatalogBrand)
            .Include(i => i.CatalogType)
            .OrderBy(c => c.Name)
            .Skip(pageSize * pageIndex)
            .Take(pageSize)
            .ToListAsync();

        return new PaginatedItems<CatalogItem>() { TotalCount = totalItems, Data = itemsOnPage };
    }

    public async Task<int?> Add(string name, string description, decimal price, int availableStock, int catalogBrandId, int catalogTypeId, string pictureFileName)
    {
        var item = await _dbContext.AddAsync(new CatalogItem
        {
            CatalogBrandId = catalogBrandId,
            CatalogTypeId = catalogTypeId,
            Description = description,
            Name = name,
            PictureFileName = pictureFileName,
            Price = price,
            AvailableStock = availableStock
        });

        await _dbContext.SaveChangesAsync();

        return item.Entity.Id;
    }

    public async Task<int?> Update(int id, string name, string description, decimal price, int availableStock, int catalogBrandId, int catalogTypeId, string pictureFileName)
    {
        var item = await _dbContext.CatalogItems
            .Where((item) => item.Id == id)
            .FirstOrDefaultAsync();

        if (item == null)
        {
            return null;
        }

        item.Id = id;
        item.CatalogBrandId = catalogBrandId;
        item.CatalogTypeId = catalogTypeId;
        item.Description = description;
        item.Name = name;
        item.PictureFileName = pictureFileName;
        item.Price = price;
        item.AvailableStock = availableStock;

        await _dbContext.SaveChangesAsync();

        return item.Id;
    }

    public async Task<int?> Delete(int id)
    {
        var item = await _dbContext.CatalogItems
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

    public async Task<CatalogItem?> GetByIdAsync(int id)
    {
        return await _dbContext.CatalogItems
            .Include(item => item.CatalogType)
            .Include(item => item.CatalogBrand)
            .FirstOrDefaultAsync((item) => item.Id == id);
    }

    public async Task<List<CatalogItem>> GetByTypeAsync(string type)
    {
        return await _dbContext.CatalogItems
            .Include(item => item.CatalogType)
            .Include(item => item.CatalogBrand)
            .Where(item => item.CatalogType.Type == type).ToListAsync();
    }

    public async Task<List<CatalogItem>> GetByBrandAsync(string brand)
    {
        return await _dbContext.CatalogItems
            .Include(item => item.CatalogType)
            .Include(item => item.CatalogBrand)
            .Where(item => item.CatalogBrand.Brand == brand).ToListAsync();
    }

    public async Task<List<CatalogType>> GetTypesAsync()
    {
        return await _dbContext.CatalogTypes.ToListAsync();
    }

    public async Task<List<CatalogBrand>> GetBrandsAsync()
    {
        return await _dbContext.CatalogBrands.ToListAsync();
    }
}