using System.Text;
using OrderService.Modules.Orders.Dto.Payments;
using OrderService.Modules.Orders.Ports.SyncServices;
using System.Text.Json;
using Microsoft.Extensions.Options;
using OrderService.Modules.Orders.Options;

namespace OrderService.Modules.Orders.Adapters.SyncServices;

public class PaymentDataClient : IPaymentDataClient
{
	private readonly HttpClient _httpClient;
	private readonly PaymentOptions _paymentOptions; 

	public PaymentDataClient(HttpClient httpClient, IOptions<PaymentOptions> paymentOptions)
	{
		_httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
		_paymentOptions = paymentOptions?.Value ??  throw new ArgumentNullException(nameof(paymentOptions)); 
	}


	public async Task CreatePaymentForOrderAsync(PaymentCreateDto paymentCreateDto)
	{
		var httpContent =
			new StringContent(
				JsonSerializer.Serialize(paymentCreateDto),
				Encoding.UTF8,
				"application/json");
		
		var response = await _httpClient.PostAsync(_paymentOptions.Url, httpContent);

		Console.WriteLine(response.IsSuccessStatusCode 
			? "==> Sync post query to Payment service was ok" 
			: "==> Sync post query to Payment service was NOT ok");
	}
}