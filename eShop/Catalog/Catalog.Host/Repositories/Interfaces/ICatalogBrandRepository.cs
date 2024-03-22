using Catalog.Host.Data;
using Catalog.Host.Data.Entities;

namespace Catalog.Host.Repositories.Interfaces;

public interface ICatalogBrandRepository
{
    Task<int?> Add(string brand);
    Task<int?> Update(int id, string brand);

    Task<int?> Delete(int id);
}