using Shop.Models;
using Shop.Repositories;

namespace Shop.Services;

public class ProductService
{
    private readonly ProductRepository _productRepository;

    public ProductService(ProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public Product GetProduct(string id)
    {
        var product = _productRepository.GetProduct(id);

        return new Product()
        {
            Id = product.Id,
            Title = product.Title,
            Price = product.Price
        };
    }

    public string GetProductTitle(string id)
    {
        var product = GetProduct(id);

        return product.Title;
    }

    public Product[] GetProducts()
    {
        return _productRepository.GetProducts()
            .Select((product) => new Product()
            {
                Id = product.Id,
                Title = product.Title,
                Price = product.Price
            }).ToArray();
    }
}