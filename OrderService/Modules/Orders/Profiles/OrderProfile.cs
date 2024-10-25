using AutoMapper;
using OrderService.Modules.Orders.Dto;
using OrderService.Modules.Orders.Models;

namespace OrderService.Modules.Orders.Profiles;

public class OrderProfile : Profile
{
    public OrderProfile()
    {
        CreateMap<Order, OrderReadDto>();
        CreateMap<OrderItem, OrderItemReadDto>();
        CreateMap<OrderCreateDto, Order>();
        CreateMap<OrderItemCreateDto, OrderItem>();
    }
}