namespace ConsoleEFApp.Repositories.Abstractions;

public interface IBaseRepository<TEntity, TModel>
{
    Task<int> Create(TModel location);
    Task<TEntity?> Get(int id);
    Task<List<TEntity>?> GetAll();
    Task<int?> Update(int id, TModel location);
    Task<bool> Delete(int id);
}