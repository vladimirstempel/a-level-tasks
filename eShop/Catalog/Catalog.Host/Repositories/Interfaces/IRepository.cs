using Catalog.Host.Data;
using Catalog.Host.Data.Entities;

namespace Catalog.Host.Repositories.Interfaces;

public interface IRepository<T>
    where T : BaseEntity
{
    Task<int?> Add(T entity);

    Task<int?> Update(int id, T entity);

    Task<int?> Delete(int id);
}