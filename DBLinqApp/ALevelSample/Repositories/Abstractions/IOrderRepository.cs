using System.Collections.Generic;
using System.Threading.Tasks;
using ALevelSample.Data.Entities;
using ALevelSample.Models;

namespace ALevelSample.Repositories.Abstractions;

public interface IOrderRepository
{
    Task<int> AddOrderAsync(string user, List<OrderItem> items);
    Task<int?> AddOrderItemAsync(int orderId, OrderItem item);
    Task<OrderEntity?> GetOrderAsync(int id);
    Task<IEnumerable<OrderEntity>?> GetOrderByUserIdAsync(string id);
    Task<int?> UpdateOrderItemAsync(int id, int orderItemCount);
    Task<bool> DeleteOrderAsync(int id);
    Task<bool> DeleteOrderItemAsync(int id);
}