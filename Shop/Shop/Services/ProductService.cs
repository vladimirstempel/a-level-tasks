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

    public string AddProduct(string title, string description, double price)
    {
        var id = _productRepository.AddProduct(title, description, price);

        return id;
    }

    public Product GetProduct(string id)
    {
        var product = _productRepository.GetProduct(id);

        if (product == null)
        {
            return null;
        }

        return new Product()
        {
            Id = product.Id,
            Title = product.Title,
            Description = product.Description,
            Price = product.Price
        };
    }

    public string GetProductTitle(string id)
    {
        var product = GetProduct(id);

        if (product == null)
        {
            return null;
        }

        return product.Title;
    }

    public Product[] GetProducts()
    {
        return _productRepository.GetProducts()
            .Select((product) => new Product()
            {
                Id = product.Id,
                Title = product.Title,
                Description = product.Description,
                Price = product.Price
            }).ToArray();
    }
}