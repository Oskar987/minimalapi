using OrderService.Modules.Orders.Models;

namespace OrderService.Modules.Orders.Dto;

public class OrderReadDto
{
    public Guid Id { get; set; }
    public List<OrderItemReadDto> Items { get; set; }
    public OrderStatus Status { get; set; }
}