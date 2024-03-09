namespace ALevelSample.Models;

public class ProductFilters
{
    public double? Price { get; set; }
    public string? Name { get; set; }

    public OrderDirection Ordering { get; set; } = OrderDirection.Asc;
}