using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OrderService.Modules.Orders.Dto;
using OrderService.Modules.Orders.Ports;

namespace OrderService.Modules.Orders.Endpoints;

public static class GetOrderEndpoint
{
    public static void GetOrder(this IEndpointRouteBuilder endpointRouteBuilder)
    {
        endpointRouteBuilder.MapGet("/orders/{id:guid}", async (Guid id, IOrderRepository orderRepository, IMapper mapper) =>
            {
                var order = await orderRepository.GetAsync(id);
                return order is null ? Results.NotFound() : Results.Ok(mapper.Map<OrderReadDto>(order));
            })
            .Produces<OrderReadDto>(StatusCodes.Status200OK)
            .Produces<ProblemDetails>(StatusCodes.Status404NotFound)
            .WithName("Get order by Id")
            .WithOpenApi()
            .CacheOutput();
    }
}