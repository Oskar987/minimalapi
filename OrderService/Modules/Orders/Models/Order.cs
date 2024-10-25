namespace OrderService.Modules.Orders.Models;

public class Order
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public OrderStatus Status { get; set; }
    public List<OrderItem> Items { get; set; }
}

public enum OrderStatus
{
    Submitted = 1,
    Paid = 2,
    Shipped = 3,
    Canceled = 4
}