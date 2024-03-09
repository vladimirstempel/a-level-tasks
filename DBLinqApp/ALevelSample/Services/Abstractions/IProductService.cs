using System.Collections.Generic;
using System.Threading.Tasks;
using ALevelSample.Data.Entities;
using ALevelSample.Models;

namespace ALevelSample.Services.Abstractions;

public interface IProductService
{
    Task<int> AddProductAsync(string name, double price);
    Task<Product> GetProductAsync(int id);
    Task<Pagination<Product, ProductEntity>> GetProductsAsync();
    Task<List<Product>> FilterProductsAsync(ProductFilters filters);
    Task<int?> UpdateProduct(int id, string name, double price);
    Task<bool> DeleteProduct(int id);
}