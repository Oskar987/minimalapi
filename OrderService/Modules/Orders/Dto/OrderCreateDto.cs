using OrderService.Modules.Orders.Models;

namespace OrderService.Modules.Orders.Dto;

public class OrderCreateDto
{
    public string Email { get; set; }
    public OrderItemCreateDto[] Items { get; set; }
}