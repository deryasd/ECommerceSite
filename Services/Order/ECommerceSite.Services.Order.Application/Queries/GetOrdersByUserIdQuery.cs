using ECommerceSite.Services.Order.Application.Dtos;
using ECommerceSite.Shared.Dtos;
using MediatR;
namespace ECommerceSite.Services.Order.Application.Queries
{
    public class GetOrdersByUserIdQuery : IRequest<Response<List<OrderDto>>>
    {
        public string UserId { get; set; }
    }
}