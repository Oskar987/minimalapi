namespace OrderService.Modules.Orders.Dto;

public class OrderItemReadDto
{
    public string ProductName { get; set; }
    public decimal Price { get; set; }
    public int Count { get; set; }
}