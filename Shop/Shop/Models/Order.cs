using Spectre.Console;

namespace Shop.Models;

public class Order
{
    private readonly List<Product> _products;
    private long _orderId;

    public double Total
    {
        get
        {
            return _products.Sum((product) => product.Price);
        }
    }

    public Order(List<Product> products)
    {
        _products = products;
        _orderId = GenerateOrderId();
    }

    public void PrintOrder()
    {
        AnsiConsole.Markup("\n[green]Order succeeded![/]\n");
        
        AnsiConsole.Markup("\nYour order ID is - [green]{0}[/]", _orderId);
        
        AnsiConsole.WriteLine("\nYour order details:");
        
        var table = new Table();

        table.AddColumn(new TableColumn("Product Name"));
        table.AddColumn(new TableColumn("Product Price"));

        foreach (var product in _products)
        {
            var row = new []{ new Markup(product.Title), new Markup($"[yellow]{product.Price.ToString()}[/]") } ;
            table.AddRow(row);
        }

        table.AddEmptyRow();
        table.AddRow(new[] { new Markup("Total:"), new Markup($"[yellow]{Total.ToString()}[/]") });
        
        AnsiConsole.Write(table);
    }

    private long GenerateOrderId()
    {
        return new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds();
    }
}