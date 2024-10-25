namespace OrderService.Modules.Orders.Dto;

public class OrderItemCreateDto
{
    public string ProductName { get; set; }
    public decimal Price { get; set; }
    public int Count { get; set; }
}