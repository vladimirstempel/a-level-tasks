using Catalog.Host.Models.Requests;

namespace Catalog.Host.Services.Interfaces;

public interface ICatalogItemService
{
    Task<int?> Add(CreateProductRequest item);
    Task<int?> Update(int id, CreateProductRequest item);
    Task<int?> Delete(int id);
}