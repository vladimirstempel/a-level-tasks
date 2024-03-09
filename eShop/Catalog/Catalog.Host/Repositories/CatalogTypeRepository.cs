using Catalog.Host.Data;
using Catalog.Host.Data.Entities;
using Catalog.Host.Services.Interfaces;

namespace Catalog.Host.Repositories;

public class CatalogTypeRepository : Repository<CatalogType>
{
    public CatalogTypeRepository(IDbContextWrapper<ApplicationDbContext> dbContextWrapper)
        : base(dbContextWrapper)
    {
    }
}