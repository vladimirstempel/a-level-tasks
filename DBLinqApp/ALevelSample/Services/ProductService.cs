using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ALevelSample.Data;
using ALevelSample.Data.Entities;
using ALevelSample.Models;
using ALevelSample.Repositories.Abstractions;
using ALevelSample.Services.Abstractions;
using Microsoft.Extensions.Logging;

namespace ALevelSample.Services;

public class ProductService : BaseDataService<ApplicationDbContext>, IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly ILogger<UserService> _loggerService;

    public ProductService(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<BaseDataService<ApplicationDbContext>> logger,
        IProductRepository productRepository,
        ILogger<UserService> loggerService)
        : base(dbContextWrapper, logger)
    {
        _productRepository = productRepository;
        _loggerService = loggerService;
    }

    public async Task<int> AddProductAsync(string name, double price)
    {
        var id = await _productRepository.AddProductAsync(name, price);
        _loggerService.LogInformation($"Created product with Id = {id}");
        return id;
    }

    public async Task<Product> GetProductAsync(int id)
    {
        var result = await _productRepository.GetProductAsync(id);

        if (result == null)
        {
            _loggerService.LogWarning($"Not found product with Id = {id}");
            return null!;
        }

        return new Product()
        {
            Id = result.Id,
            Name = result.Name,
            Price = result.Price
        };
    }

    public async Task<Pagination<Product, ProductEntity>> GetProductsAsync()
    {
        var paginationRepository = await _productRepository.GetProductsAsync();
        var pagination = new Pagination<Product, ProductEntity>(paginationRepository);

        Pagination<Product, ProductEntity>.Mapper mapToProduct = (map) =>
        {
            map(
                x => new Product()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Price = x.Price
                });
        };

        pagination.OnInit += mapToProduct;
        pagination.OnNext += mapToProduct;
        pagination.OnPrev += mapToProduct;

        pagination.Init();

        return pagination;
    }

    public async Task<List<Product>> FilterProductsAsync(ProductFilters filters)
    {
        var entities = await _productRepository.FilterProductsAsync(filters);
        return entities.Select(
            x => new Product()
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price
            }).ToList();
    }

    public async Task<int?> UpdateProduct(int id, string name, double price)
    {
        var user = await _productRepository.GetProductAsync(id);

        if (user == null)
        {
            _loggerService.LogWarning($"Not found product with Id = {id}");
            return null!;
        }

        await _productRepository.UpdateProductAsync(id, name, price);

        _loggerService.LogInformation("Product with Id = {0} has been updated", id);

        return user.Id;
    }

    public async Task<bool> DeleteProduct(int id)
    {
        var productDeleted = await _productRepository.DeleteProductAsync(id);

        if (!productDeleted)
        {
            _loggerService.LogWarning($"Not found product with Id = {id}");
            return productDeleted;
        }

        _loggerService.LogInformation("Product with Id = {0} has been deleted", id);

        return productDeleted;
    }
}