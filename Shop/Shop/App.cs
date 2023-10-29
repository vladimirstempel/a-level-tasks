using Shop.Models;
using Shop.Repositories;
using Shop.Services;
using Spectre.Console;

namespace Shop;

public class App
{
    private readonly ProductService _productService;

    public App(ProductService productService)
    {
        _productService = productService;
    }

    public void Start()
    {
        var selectedIdList = AskToSelectProducts();

        if (selectedIdList.Count == 0)
        {
            AnsiConsole.WriteLine("You didn't select any products, please try again...");
            Start();
            return;
        }

        var selectedProducts = selectedIdList.Select(id => _productService.GetProduct(id));

        var cart = new Cart(selectedProducts.ToArray());

        var cartProductNamesPrint = cart.GetCardItems().Select((p, index) => $"{index + 1}: {p.Title}");

        AnsiConsole.WriteLine("Products added to card: \n{0}", string.Join("\n", cartProductNamesPrint));

        AnsiConsole.WriteLine("\nTotal amount: {0}\n", cart.Total);

        var proceedWithCheckout = AskToBuy();

        if (!proceedWithCheckout)
        {
            Console.WriteLine("Well, see you next time.");
            Exit();
            return;
        }

        var order = new Order(cart);
        
        AnsiConsole.Markup("\n[green]Your order has been placed! Thank you![/]\n");
        
        order.PrintOrder();

        Exit();
    }

    private List<string> AskToSelectProducts()
    {
        var products = _productService.GetProducts();

        var productIds = products.Select(product => product.Id);

        return AnsiConsole.Prompt(
            new MultiSelectionPrompt<string>()
                .Title("Select [green]products[/] you want to buy")
                .NotRequired()
                .PageSize(products.Length)
                .MoreChoicesText("[grey](Move up and down to reveal more products)[/]")
                .InstructionsText(
                    "[grey](Press [blue]<space>[/] to toggle a product, " +
                    "[green]<enter>[/] to accept)[/]")
                .AddChoices(productIds)
                .UseConverter((id) => _productService.GetProductTitle(id))
        );
    }

    private bool AskToBuy()
    {
        return AnsiConsole.Confirm("\nProceed with checkout?");
    }

    private void Exit()
    {
        AnsiConsole.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}