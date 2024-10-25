using Microsoft.EntityFrameworkCore;
using OrderService.Modules.Orders.Data;
using OrderService.Modules.Orders.Models;
using OrderService.Modules.Orders.Ports;

namespace OrderService.Modules.Orders.Adapters;

public class OrderRepository : IOrderRepository
{
    private readonly ApplicationDataContext _applicationDataContext;

    public OrderRepository(ApplicationDataContext applicationDataContext)
    {
        _applicationDataContext = applicationDataContext ?? throw new ArgumentNullException(nameof(applicationDataContext));
    }

    public async Task<bool> SaveChangesAsync() => await _applicationDataContext.SaveChangesAsync() >= 0;

    public async Task<IEnumerable<Order>> GetAsync() => await _applicationDataContext.Orders
        .Include(x => x.Items)
        .ToListAsync();

    public async Task<Order?> GetAsync(Guid id) => await _applicationDataContext.Orders
        .Include(x => x.Items)
        .FirstOrDefaultAsync(x => x.Id == id);

    public async Task CreateAsync(Order order) => await _applicationDataContext.Orders.AddAsync(order);

    public async Task DeleteAsync(Guid id)
    {
        var order = await _applicationDataContext.Orders.FindAsync(id);

        if (order is not null)
        {
            _applicationDataContext.Orders.Remove(order);
        }
    }
}