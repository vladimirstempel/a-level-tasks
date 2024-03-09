using Catalog.Host.Data;
using Catalog.Host.Data.Entities;
using Catalog.Host.Services.Interfaces;

namespace Catalog.Host.Repositories;

public class CatalogBrandRepository : Repository<CatalogBrand>
{
    public CatalogBrandRepository(IDbContextWrapper<ApplicationDbContext> dbContextWrapper)
        : base(dbContextWrapper)
    {
    }
}