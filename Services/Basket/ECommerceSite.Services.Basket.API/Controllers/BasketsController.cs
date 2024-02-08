using ECommerceSite.Services.Basket.Dtos;
using ECommerceSite.Services.Basket.Services;
using ECommerceSite.Shared.ControllerBases;
using ECommerceSite.Shared.Services;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceSite.Services.Basket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketsController : CustomBaseController
    {
        private readonly IBasketService _basketService;
        private readonly ISharedIdentityService _sharedIdentityService;
        private readonly ISendEndpointProvider _sendEndpointProvider;
        private readonly ILogger<BasketsController> _logger;
        public BasketsController(IBasketService basketService, ISharedIdentityService sharedIdentityService, ILogger<BasketsController> logger,ISendEndpointProvider sendEndpointProvider)
        {
            _basketService = basketService;
            _sharedIdentityService = sharedIdentityService;
            _logger = logger;
            _sendEndpointProvider = sendEndpointProvider;
        }

        [HttpGet]
        public async Task<IActionResult> GetBasket()
        {
            return CreateActionResultInstance(await _basketService.GetBasket(_sharedIdentityService.GetUserId));
        }

        [HttpPost]
        public async Task<IActionResult> SaveOrUpdateBasket(BasketDto basketDto)
        {
            basketDto.UserId = _sharedIdentityService.GetUserId;
            var response = await _basketService.SaveOrUpdate(basketDto);

            return CreateActionResultInstance(response);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBasket()

        {
            return CreateActionResultInstance(await _basketService.Delete(_sharedIdentityService.GetUserId));
        }
    }
}
