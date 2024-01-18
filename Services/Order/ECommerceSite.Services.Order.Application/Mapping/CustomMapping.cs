using AutoMapper;
using ECommerceSite.Services.Order.Application.Dtos;
using ECommerceSite.Services.Order.Domain.OrderAggregate;

namespace ECommerceSite.Services.Order.Application.Mapping
{
    internal class CustomMapping : Profile
    {
        public CustomMapping()
        {
            CreateMap<Domain.OrderAggregate.Order, OrderDto>().ReverseMap();
            CreateMap<OrderItem, OrderItemDto>().ReverseMap();
            CreateMap<Address, AddressDto>().ReverseMap();
        }
    }
}