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
        var selectedIdList = ProductSelectList();

        if (selectedIdList.Count == 0)
        {
            AnsiConsole.WriteLine("You didn't select any products, please try again...");
            Start();
            return;
        }

        var selectedProducts = selectedIdList.Select(id => _productService.GetProduct(id));

        var cart = new Cart();

        cart.AddProducts(selectedProducts.ToArray());

        var cardProductNames = cart.GetCardItems().Select(p => p.Title);

        AnsiConsole.WriteLine("Products added to card: \n{0}", string.Join("\n", cardProductNames));

        AnsiConsole.WriteLine("\nTotal amount: {0}\n", cart.Total);

        var proceedWithCheckout = AskToBuy();

        if (!proceedWithCheckout)
        {
            Console.WriteLine("Well see you next time. Press any key to exit...");
            Console.ReadKey();
            return;
        }

        var order = new Order(cart.GetCardItems());
        
        order.PrintOrder();
    }

    private List<string> ProductSelectList()
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
}