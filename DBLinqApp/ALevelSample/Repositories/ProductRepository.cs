using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ALevelSample.Data;
using ALevelSample.Data.Entities;
using ALevelSample.Models;
using ALevelSample.Repositories.Abstractions;
using ALevelSample.Services.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace ALevelSample.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _dbContext;

    public ProductRepository(IDbContextWrapper<ApplicationDbContext> dbContextWrapper)
    {
        _dbContext = dbContextWrapper.DbContext;
    }

    public async Task<int> AddProductAsync(string name, double price)
    {
        var product = new ProductEntity()
        {
            Name = name,
            Price = price
        };

        var result = await _dbContext.Products.AddAsync(product);
        await _dbContext.SaveChangesAsync();

        return result.Entity.Id;
    }

    public async Task<ProductEntity?> GetProductAsync(int id)
    {
        return await _dbContext.Products.FirstOrDefaultAsync(f => f.Id == id);
    }

    public async Task<IPaginationRepository<ProductEntity>> GetProductsAsync()
    {
        var pagination = await new PaginationRepository<ProductEntity>(_dbContext.Products).Paginate();
        return pagination;
    }

    public async Task<List<ProductEntity>> FilterProductsAsync(ProductFilters filters)
    {
        IQueryable<ProductEntity> products = _dbContext.Products;

        switch (filters.Ordering)
        {
            case OrderDirection.Asc:
                products = products.OrderBy(x => x.Id);
                break;
            case OrderDirection.Desc:
                products = products.OrderByDescending(x => x.Id);
                break;
            default:
                products = products.OrderBy(x => x.Id);
                break;
        }

        if (filters.Name != null)
        {
            products = products.Where(x => x.Name == filters.Name);
        }

        if (filters.Price != null)
        {
            products = products.Where(x => x.Price.Equals(filters.Price));
        }

        return await products.ToListAsync();
    }

    public async Task<int?> UpdateProductAsync(int id, string name, double price)
    {
        var productEntity = await _dbContext.Products.FirstOrDefaultAsync(f => f.Id == id);

        if (productEntity == null)
        {
            return null;
        }

        productEntity.Name = name;
        productEntity.Price = price;

        await _dbContext.SaveChangesAsync();

        return productEntity.Id;
    }

    public async Task<bool> DeleteProductAsync(int id)
    {
        var productEntity = await _dbContext.Products.FirstOrDefaultAsync(f => f.Id == id);

        if (productEntity == null)
        {
            return false;
        }

        _dbContext.Remove(productEntity);
        await _dbContext.SaveChangesAsync();

        return true;
    }
}
