using System;
using System.Collections.Generic;
using System.Linq;
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
        var product4 = await _productService.AddProductAsync("product4", 19);
        var product5 = await _productService.AddProductAsync("product5", 16);
        var product6 = await _productService.AddProductAsync("product6", 31);
        var product7 = await _productService.AddProductAsync("product7", 53);
        var product8 = await _productService.AddProductAsync("product8", 32);
        var product9 = await _productService.AddProductAsync("product9", 21);
        var product10 = await _productService.AddProductAsync("product10", 11);

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

        var pagination = await _productService.GetProductsAsync();

        var products = pagination.Items;

        Console.WriteLine(
            "Current Page: {3}, Current Items: {2}, Total Pages: {4}, Products: {0}, Total Items: {1}",
            string.Join(", ", products.Select(p => p.Name)),
            pagination.TotalItems,
            products.Count,
            pagination.CurrentPage,
            pagination.TotalPages);

        await pagination.Next();
        var products2 = pagination.Items;

        Console.WriteLine(
            "Current Page: {3}, Current Items: {2}, Total Pages: {4}, Products: {0}, Total Items: {1}",
            string.Join(", ", products2.Select(p => p.Name)),
            pagination.TotalItems,
            products2.Count,
            pagination.CurrentPage,
            pagination.TotalPages);

        await pagination.Prev();
        var products3 = pagination.Items;

        Console.WriteLine(
            "Current Page: {3}, Current Items: {2}, Total Pages: {4}, Products: {0}, Total Items: {1}",
            string.Join(", ", products3.Select(p => p.Name)),
            pagination.TotalItems,
            products3.Count,
            pagination.CurrentPage,
            pagination.TotalPages);

        var foundProduct = await _productService.GetProductAsync(product5);
        var foundProduct2 = await _productService.GetProductAsync(product7);
        var filters = new ProductFilters()
        {
            Name = foundProduct.Name,
            Ordering = OrderDirection.Desc
        };
        var filters2 = new ProductFilters()
        {
            Price = foundProduct2.Price,
            Ordering = OrderDirection.Desc
        };
        var filteredProducts = await _productService.FilterProductsAsync(filters);
        var filteredProducts2 = await _productService.FilterProductsAsync(filters2);

        filters.Ordering = OrderDirection.Asc;
        var filteredProducts3 = await _productService.FilterProductsAsync(filters);

        Console.WriteLine("Products filtered Desc: {0}", string.Join(", ", filteredProducts.Select(p => $"{p.Name} Id = {p.Id}")));
        Console.WriteLine("Products filtered 2 Desc: {0}", string.Join(", ", filteredProducts2.Select(p => $"{p.Name} Id = {p.Id}")));
        Console.WriteLine("Products filtered 3 Asc: {0}", string.Join(", ", filteredProducts3.Select(p => $"{p.Name} Id = {p.Id}")));
    }
}