using Microsoft.AspNetCore.Mvc;
using OrderService.Modules.Orders.Ports;

namespace OrderService.Modules.Orders.Endpoints;

public static class DeleteOrderEndpoint
{
    public static void DeleteOrder(this IEndpointRouteBuilder endpointRouteBuilder)
    {
        endpointRouteBuilder.MapDelete("/orders/{id:guid}", async (Guid id, IOrderRepository orderRepository) =>
            {
                await orderRepository.DeleteAsync(id);
                return Results.Ok();
            })
            .Produces(StatusCodes.Status200OK)
            .WithName("Delete order by Id")
            .WithOpenApi();
    }
}