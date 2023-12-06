using Newtonsoft.Json;
using Shop.Entities;

namespace Shop.Repositories;

public class ProductRepository
{
    private readonly ProductEntity[] _mockStorage = new ProductEntity[10];
    private int _mockStorageCursor = 0;

    public ProductRepository()
    {
        MockProducts();
    }

    public ProductEntity GetProduct(string id)
    {
        return _mockStorage.SingleOrDefault((product) => product.Id == id);
    }

    public ProductEntity[] GetProducts()
    {
        return _mockStorage;
    }

    private void MockProducts()
    {
        var productsList = LoadJson();

        foreach (var product in productsList)
        {
            AddProduct(product.Title, product.Price);
        }
    }

    private void AddProduct(string title, double price)
    {
        var product = new ProductEntity()
        {
            Id = Guid.NewGuid().ToString(),
            Title = title,
            Price = price
        };

        _mockStorage[_mockStorageCursor] = product;
        _mockStorageCursor++;
    }

    private List<ProductEntity> LoadJson()
    {
        var reader = new StreamReader("products.mock.json");

        string json = reader.ReadToEnd();
        
        reader.Dispose();

        return JsonConvert.DeserializeObject<List<ProductEntity>>(json);
    }
}