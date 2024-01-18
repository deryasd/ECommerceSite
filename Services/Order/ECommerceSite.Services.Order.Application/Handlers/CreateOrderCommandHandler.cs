using ECommerceSite.Services.Order.Application.Commands;
using ECommerceSite.Services.Order.Application.Dtos;
using ECommerceSite.Services.Order.Domain.OrderAggregate;
using ECommerceSite.Services.Order.Infrastructere;
using ECommerceSite.Shared.Dtos;
using MediatR;

namespace ECommerceSite.Services.Order.Application.Handlers
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Response<CreatedOrderDto>>
    {
        private readonly OrderDbContext _context;

        public CreateOrderCommandHandler(OrderDbContext context)
        {
            _context = context;
        }

        public async Task<Response<CreatedOrderDto>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var newAddress = new Address(request.Address.Country, request.Address.City, request.Address.Township, request.Address.Neighbourhood, request.Address.Street, request.Address.Gait, request.Address.Block, request.Address.Number, request.Address.ZipCode);

            Domain.OrderAggregate.Order newOrder = new Domain.OrderAggregate.Order(request.BuyerId, newAddress);

            request.OrderItems.ForEach(x =>
            {
                newOrder.AddOrderItem(x.ProductId, x.ProductName, x.Price, x.Quantity);
            });

            await _context.Orders.AddAsync(newOrder);

            await _context.SaveChangesAsync();

            return Response<CreatedOrderDto>.Success(new CreatedOrderDto { OrderId = newOrder.Id }, 200);
        }
    }
}