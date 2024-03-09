using Catalog.Host.Models.Requests;

namespace Catalog.Host.Services.Interfaces;

public interface ICatalogTypeService
{
    Task<int?> Add(CreateTypeRequest type);
    Task<int?> Update(int id, CreateTypeRequest type);
    Task<int?> Delete(int id);
}