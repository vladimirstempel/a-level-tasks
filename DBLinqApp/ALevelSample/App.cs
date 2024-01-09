using System.Collections.Generic;
using System.Threading.Tasks;
using ALevelSample.Models;
using ALevelSample.Services.Abstractions;

namespace ALevelSample;

public class App
{
    private readonly IUserService _userService;
    private readonly IOrderService _orderService;
    private readonly IProductService _productService;

    public App(
        IUserService userService,
        IOrderService orderService,
        IProductService productService)
    {
        _userService = userService;
        _orderService = orderService;
        _productService = productService;
    }

    public async Task Start()
    {
        var firstName = "first name";
        var lastName = "last name";

        var userId = await _userService.AddUser(firstName, lastName);

        await _userService.GetUser(userId);

        var userUpdated = await _userService.UpdateUser(userId, "Test", "Update");

        var userId2 = await _userService.AddUser(firstName, lastName);

        var user2Deleted = await _userService.DeleteUser(userId2);

        var product1 = await _productService.AddProductAsync("product1", 4);
        var product2 = await _productService.AddProductAsync("product2", 7);
        var product3 = await _productService.AddProductAsync("product3", 9);
        var product4 = await _productService.AddProductAsync("product4", 9);

        var product3Updated = await _productService.UpdateProduct(product3, "product3 Updated", 10);

        var product4Deleted = await _productService.DeleteProduct(product4);

        var order1 = await _orderService.AddOrderAsync(
            userId,
            new List<OrderItem>()
            {
                new OrderItem()
                {
                    Count = 3,
                    ProductId = product1
                },

                new OrderItem()
                {
                    Count = 6,
                    ProductId = product2
                },
            });

        var order2 = await _orderService.AddOrderAsync(
            userId,
            new List<OrderItem>()
            {
                new OrderItem()
                {
                    Count = 1,
                    ProductId = product1
                },

                new OrderItem()
                {
                    Count = 9,
                    ProductId = product2
                },
            });

        var order3 = await _orderService.AddOrderAsync(
            userId,
            new List<OrderItem>()
            {
                new OrderItem()
                {
                    Count = 5,
                    ProductId = product2
                },
            });

        var orderItem = await _orderService.AddOrderItemAsync(
            order2,
            new OrderItem()
            {
                Count = 15,
                ProductId = product2
            });

        var orderItem2 = await _orderService.AddOrderItemAsync(
            order2,
            new OrderItem()
            {
                Count = 13,
                ProductId = product2
            });

        if (orderItem2 != null)
        {
            var orderItemDeleted = await _orderService.DeleteOrderItem((int)orderItem2);
        }

        var order3Deleted = await _orderService.DeleteOrder(order3);

        var userOrder = await _orderService.GetOrderByUserIdAsync(userId);
    }
}