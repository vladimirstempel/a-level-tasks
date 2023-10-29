namespace Shop.Models;

public class Cart
{
    private readonly List<Product> _products = new();
    
    public double Total
    {
        get
        {
            return _products.Sum((product) => product.Price);
        }
    }

    public void AddProducts(Product[] products)
    {
        _products.AddRange(products);
    }

    public List<Product> GetCardItems()
    {
        return _products;
    }

    public void ClearCart()
    {
        _products.Clear();
    }
}