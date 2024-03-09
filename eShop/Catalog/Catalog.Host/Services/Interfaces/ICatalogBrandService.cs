using Catalog.Host.Models.Requests;

namespace Catalog.Host.Services.Interfaces;

public interface ICatalogBrandService
{
    Task<int?> Add(CreateBrandRequest type);
    Task<int?> Update(int id, CreateBrandRequest type);
    Task<int?> Delete(int id);
}