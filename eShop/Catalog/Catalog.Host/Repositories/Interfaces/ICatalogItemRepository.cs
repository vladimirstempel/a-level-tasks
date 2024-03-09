using Catalog.Host.Data;
using Catalog.Host.Data.Entities;

namespace Catalog.Host.Repositories.Interfaces;

public interface ICatalogItemRepository : IRepository<CatalogItem>
{
    Task<PaginatedItems<CatalogItem>> GetByPageAsync(int pageIndex, int pageSize);
    Task<CatalogItem?> GetByIdAsync(int id);
    Task<List<CatalogItem>> GetByTypeAsync(string type);
    Task<List<CatalogItem>> GetByBrandAsync(string type);
    Task<List<CatalogType>> GetTypesAsync();
    Task<List<CatalogBrand>> GetBrandsAsync();
}