using Spectre.Console;

namespace Shop.Models;

public class Order
{
    private readonly Cart _cart;
    
    private readonly List<Product> _products;
    private readonly long _orderId;
    private readonly double _total;

    public Order(Cart cart)
    {
        _cart = cart;
        _products = cart.GetCardItems(true);
        _orderId = GenerateOrderId();
        _total = cart.Total;
    }

    public void PrintOrder()
    {
        _cart.ClearCart();
        
        AnsiConsole.Markup("\nYour order ID is - [green]{0}[/]", _orderId);

        AnsiConsole.WriteLine("\nYour order details:");

        var table = new Table();

        table.AddColumn(new TableColumn("#"));
        table.AddColumn(new TableColumn("Product Name"));
        table.AddColumn(new TableColumn("Product Price"));

        for (var i = 0; i < _products.Count; i++)
        {
            var row = new[]
            {
                new Markup((i + 1).ToString()),
                new Markup(_products[i].Title),
                new Markup($"[yellow]{_products[i].Price.ToString()}[/]")
            };
            table.AddRow(row);
        }

        table.AddEmptyRow();
        table.AddRow(new[] { new Markup(""), new Markup("Total:"), new Markup($"[yellow]{_total.ToString()}[/]") });

        AnsiConsole.Write(table);
    }

    private long GenerateOrderId()
    {
        return new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds();
    }
}