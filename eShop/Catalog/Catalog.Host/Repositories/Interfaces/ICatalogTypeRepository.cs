namespace Catalog.Host.Repositories.Interfaces;

public interface ICatalogTypeRepository
{
    Task<int?> Add(string type);
    Task<int?> Update(int id, string type);

    Task<int?> Delete(int id);
}