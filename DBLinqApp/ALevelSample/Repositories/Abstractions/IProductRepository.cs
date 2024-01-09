using System.Collections.Generic;
using System.Threading.Tasks;
using ALevelSample.Data.Entities;
using ALevelSample.Models;

namespace ALevelSample.Repositories.Abstractions;

public interface IProductRepository
{
    Task<int> AddProductAsync(string name, double price);
    Task<ProductEntity?> GetProductAsync(int id);
    Task<IPaginationRepository<ProductEntity>> GetProductsAsync();
    Task<List<ProductEntity>> FilterProductsAsync(ProductFilters filters);
    Task<int?> UpdateProductAsync(int id, string name, double price);
    Task<bool> DeleteProductAsync(int id);
}