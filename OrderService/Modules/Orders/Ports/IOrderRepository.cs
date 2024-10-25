using OrderService.Modules.Orders.Models;

namespace OrderService.Modules.Orders.Ports;

public interface IOrderRepository
{
    Task<bool> SaveChangesAsync();
    Task<IEnumerable<Order>> GetAsync();
    Task<Order?> GetAsync(Guid id);
    Task CreateAsync(Order order);
    Task DeleteAsync(Guid id);
}