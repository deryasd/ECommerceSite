using ECommerceSite.Services.Basket.Dtos;
using ECommerceSite.Services.Order.Application.Commands;
using ECommerceSite.Services.Order.Application.Queries;
using ECommerceSite.Shared.ControllerBases;
using ECommerceSite.Shared.Messages;
using ECommerceSite.Shared.Services;
using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceSite.Services.Order.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : CustomBaseController
    {
        private readonly IMediator _mediator;
        private readonly ISharedIdentityService _sharedIdentityService;
        private readonly ISendEndpointProvider _sendEndpointProvider;
        public OrdersController(IMediator mediator, ISharedIdentityService sharedIdentityService, ISendEndpointProvider sendEndpointProvider)
        {
            _mediator = mediator;
            _sharedIdentityService = sharedIdentityService;
            _sendEndpointProvider = sendEndpointProvider;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            var response = await _mediator.Send(new GetOrdersByUserIdQuery { UserId = _sharedIdentityService.GetUserId });

            return CreateActionResultInstance(response);
        }

        [HttpPost]
        public async Task<IActionResult> SaveOrder(CreateOrderCommand createOrderCommand)
        {
            var response = await _mediator.Send(createOrderCommand);
            
            var sendEndpoint = await _sendEndpointProvider.GetSendEndpoint(new Uri("queue:create-order-service"));

            bool isSuccess = false;

            var createOrdeMessageCommand = new CreateOrderMessageCommand();

            createOrdeMessageCommand.BuyerId = createOrderCommand.BuyerId;
            createOrdeMessageCommand.Country = createOrderCommand.Address.Country;
            createOrdeMessageCommand.City = createOrderCommand.Address.City;
            createOrdeMessageCommand.Township = createOrderCommand.Address.Township;
            createOrdeMessageCommand.Neighbourhood = createOrderCommand.Address.Neighbourhood;
            createOrdeMessageCommand.Street = createOrderCommand.Address.Street;
            createOrdeMessageCommand.Gait = createOrderCommand.Address.Gait;
            createOrdeMessageCommand.Block = createOrderCommand.Address.Block;
            createOrdeMessageCommand.Number = createOrderCommand.Address.Number;
            createOrdeMessageCommand.ZipCode = createOrderCommand.Address.ZipCode;

            createOrderCommand.OrderItems.ForEach(item =>
            {
                createOrdeMessageCommand.OrderItems.Add(new OrderItem
                {
                    ProductId = item.ProductId,
                    ProductName = item.ProductName,
                    Quantity = item.Quantity,
                    Price = item.Price
                });
            });

            /*if(createOrdeMessageCommand != null)
            {
                 await _basketService.Delete(createOrderCommand.BuyerId);
            }*/

            await sendEndpoint.Send<CreateOrderMessageCommand>(createOrdeMessageCommand);

            return CreateActionResultInstance(response);
        }
    }
}