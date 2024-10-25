namespace OrderService.Modules.Orders.Dto.Payments;

public class PaymentCreateDto
{
	public Guid OrderId { get; set; }
	public decimal Price { get; set; }
}