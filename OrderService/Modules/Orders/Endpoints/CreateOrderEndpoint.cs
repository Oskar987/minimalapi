using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OrderService.Modules.Orders.Dto;
using OrderService.Modules.Orders.Dto.Payments;
using OrderService.Modules.Orders.Models;
using OrderService.Modules.Orders.Ports;
using OrderService.Modules.Orders.Ports.SyncServices;

namespace OrderService.Modules.Orders.Endpoints;

public static class CreateOrderEndpoint
{
    public static void CreateOrder(this IEndpointRouteBuilder endpointBuilder)
    {
        endpointBuilder.MapPost("/orders",
                async ([FromBody] OrderCreateDto orderCreateDto,
                    IOrderRepository orderRepository,
                    IPaymentDataClient paymentDataClient,
                    IMapper mapper) =>
                {
                    var order = mapper.Map<Order>(orderCreateDto);
                    await orderRepository.CreateAsync(order);
                    await orderRepository.SaveChangesAsync();

                    var paymentCreateDto = new PaymentCreateDto
                    {
                        OrderId = order.Id,
                        Price = order.Items.Sum(x => x.Price)
                    };

                    await paymentDataClient.CreatePaymentForOrderAsync(paymentCreateDto);

                    return Results.Created();
                })
            .Produces(StatusCodes.Status201Created)
            .WithName("Create order")
            .WithOpenApi();
    }
}