using Catalog.Host.Data;
using Catalog.Host.Data.Entities;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;

namespace Catalog.Host.Repositories;

public class Repository<T> : IRepository<T>
    where T : BaseEntity
{
    private readonly ApplicationDbContext _dbContext;

    public Repository(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper)
    {
        _dbContext = dbContextWrapper.DbContext;
    }

    public async Task<int?> Add(T entity)
    {
        var result = await _dbContext.AddAsync(entity);

        await _dbContext.SaveChangesAsync();

        return result.Entity.Id;
    }

    public async Task<int?> Update(int id, T entity)
    {
        var result = _dbContext.Update(entity);

        await _dbContext.SaveChangesAsync();

        return result.Entity.Id;
    }

    public async Task<int?> Delete(int id)
    {
        _dbContext.Remove(new CatalogItem()
        {
            Id = id
        });

        await _dbContext.SaveChangesAsync();

        return id;
    }
}