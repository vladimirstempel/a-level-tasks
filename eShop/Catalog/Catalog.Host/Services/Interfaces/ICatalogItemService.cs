using Catalog.Host.Data.Entities;
using Catalog.Host.Models.Requests;

namespace Catalog.Host.Services.Interfaces;

public interface ICatalogItemService
{
    Task<int?> Add(CatalogItem item);
    Task<int?> Update(int id, CatalogItem item);
    Task<int?> Delete(int id);
}