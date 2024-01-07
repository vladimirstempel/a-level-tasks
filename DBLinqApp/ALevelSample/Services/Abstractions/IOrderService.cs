using System.Collections.Generic;
using System.Threading.Tasks;
using ALevelSample.Models;

namespace ALevelSample.Services.Abstractions;

public interface IOrderService
{
    Task<int> AddOrderAsync(string user, List<OrderItem> items);
    Task<int?> AddOrderItemAsync(int id, OrderItem item);
    Task<Order> GetOrderAsync(int id);
    Task<IReadOnlyList<Order>> GetOrderByUserIdAsync(string id);
    Task<int?> UpdateOrderItem(int id, int orderItemId, int orderItemCount);
    Task<bool> DeleteOrder(int id);
    Task<bool> DeleteOrderItem(int id);
}