namespace ConsoleEFApp.Services.Abstractions;

public interface IBaseService<T>
{
    Task<int> Create(T model);
    Task<T?> Get(int id);
    Task<List<T>?> GetAll();
    Task<int?> Update(int id, T model);
    Task<bool> Delete(int id);
}