namespace OrderService.Modules.Orders.Models;

public class OrderItem
{
    public Guid Id { get; set; }
    public string ProductName { get; set; }
    public decimal Price { get; set; }
    public int Count { get; set; }
    public Guid OrderId { get; set; }
    public Order Order { get; set; }
}