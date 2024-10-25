using AutoMapper;
using OrderService.Modules.Orders.Dto;
using OrderService.Modules.Orders.Ports;

namespace OrderService.Modules.Orders.Endpoints;

public static class GetOrdersEndpoint
{
    public static void GetOrders(this IEndpointRouteBuilder endpointRouteBuilder)
    {
        endpointRouteBuilder.MapGet("/orders", async (IOrderRepository orderRepository, IMapper mapper) =>
            {
                var orders = await orderRepository.GetAsync();
                return Results.Ok(mapper.Map<IEnumerable<OrderReadDto>>(orders));
            })
            .Produces<IEnumerable<OrderReadDto>>(StatusCodes.Status200OK)
            .WithName("Get orders")
            .WithOpenApi()
            .CacheOutput();
    }
}