using Microsoft.AspNetCore.Mvc;

namespace Catalog.Host.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private static readonly Product[] Products = new[]
    {
        new Product()
        {
            title = "iPhone 9",
            description = "An apple mobile which is nothing like apple",
            price = 549
        },
        new Product()
        {
            title = "iPhone X",
            description = "SIM-Free, Model A19211 6.5-inch Super Retina HD display with OLED technology A12 Bionic chip with ...",
            price = 899
        },
        new Product()
        {
            title = "Samsung Universe 9",
            description = "Samsung's new variant which goes beyond Galaxy to the Universe",
            price = 1249
        },
        new Product()
        {
            title = "OPPOF19",
            description = "OPPO F19 is officially announced on April 2021.",
            price = 280
        },
        new Product()
        {
            title = "Huawei P30",
            description = "Huawei’s re-badged P30 Pro New Edition was officially unveiled yesterday in Germany and now the device has made its way to the UK.",
            price = 499
        },
        new Product()
        {
            title = "MacBook Pro",
            description = "MacBook Pro 2021 with mini-LED display may launch between September, November",
            price = 1749
        }
    };

    [HttpGet]
    public IEnumerable<Product> Get()
    {
        return Products;
    }
}