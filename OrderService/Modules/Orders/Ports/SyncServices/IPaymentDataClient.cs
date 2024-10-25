using OrderService.Modules.Orders.Dto.Payments;

namespace OrderService.Modules.Orders.Ports.SyncServices;

public interface IPaymentDataClient
{
	public Task CreatePaymentForOrderAsync(PaymentCreateDto paymentCreateDto);
}