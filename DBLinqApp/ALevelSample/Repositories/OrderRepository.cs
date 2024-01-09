using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ALevelSample.Data;
using ALevelSample.Data.Entities;
using ALevelSample.Models;
using ALevelSample.Repositories.Abstractions;
using ALevelSample.Services.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace ALevelSample.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly ApplicationDbContext _dbContext;

    public OrderRepository(IDbContextWrapper<ApplicationDbContext> dbContextWrapper)
    {
        _dbContext = dbContextWrapper.DbContext;
    }

    public async Task<int> AddOrderAsync(string user, List<OrderItem> items)
    {
        var result = await _dbContext.Orders.AddAsync(
            new OrderEntity()
            {
                UserId = user
            });

        await _dbContext.OrderItems.AddRangeAsync(
            items.Select(
                s => new OrderItemEntity()
                {
                    Count = s.Count,
                    OrderId = result.Entity.Id,
                    ProductId = s.ProductId
                }));

        await _dbContext.SaveChangesAsync();

        return result.Entity.Id;
    }

    public async Task<int?> AddOrderItemAsync(int orderId, OrderItem item)
    {
        var orderEntity = await GetOrderAsync(orderId);

        if (orderEntity == null)
        {
            return null;
        }

        var result = await _dbContext.OrderItems.AddAsync(
            new OrderItemEntity()
            {
                Count = item.Count,
                OrderId = orderId,
                ProductId = item.ProductId
            });

        await _dbContext.SaveChangesAsync();

        return result.Entity.Id;
    }

    public async Task<OrderEntity?> GetOrderAsync(int id)
    {
        return await _dbContext.Orders.Include(i => i.OrderItems).FirstOrDefaultAsync(f => f.Id == id);
    }

    public async Task<IEnumerable<OrderEntity>?> GetOrderByUserIdAsync(string id)
    {
        return await _dbContext.Orders.Include(i => i.OrderItems).Where(f => f.UserId == id).ToListAsync();
    }

    public async Task<int?> UpdateOrderItemAsync(int id, int orderItemCount)
    {
        var orderItemEntity = await _dbContext.OrderItems.FirstOrDefaultAsync(f => f.Id == id);

        if (orderItemEntity == null)
        {
            return null;
        }

        orderItemEntity.Count = orderItemCount;

        await _dbContext.SaveChangesAsync();

        return orderItemEntity.Id;
    }

    public async Task<bool> DeleteOrderAsync(int id)
    {
        var orderEntity = await _dbContext.Orders.FirstOrDefaultAsync(f => f.Id == id);

        if (orderEntity == null)
        {
            return false;
        }

        _dbContext.Remove(orderEntity);
        await _dbContext.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteOrderItemAsync(int id)
    {
        var orderItemEntity = await _dbContext.OrderItems.FirstOrDefaultAsync(f => f.Id == id);

        if (orderItemEntity == null)
        {
            return false;
        }

        _dbContext.Remove(orderItemEntity);
        await _dbContext.SaveChangesAsync();

        return true;
    }
}