using ECommerceSite.Services.Basket.Services;
using ECommerceSite.Shared.Dtos;
using Mass = MassTransit;
using System.Text.Json;
using ECommerceSite.Shared.Messages;
using ECommerceSite.Services.Basket.DataAccess;

namespace ECommerceSite.Services.Basket.Dtos
{
    public class BasketService : IBasketService
    {
        private readonly RedisService _redisService;
        private readonly Mass.IPublishEndpoint _publishEndPoint;

        public BasketService(RedisService redisService, Mass.IPublishEndpoint publishEndPoint)
        {
            _redisService = redisService;
            _publishEndPoint = publishEndPoint;
        }
        public async Task<Response<bool>> Delete(string userId)
        {   
            await _publishEndPoint.Publish<BasketUpdatedEvent>(new BasketUpdatedEvent { UserId = userId});
            var status = await _redisService.GetDb().KeyDeleteAsync(userId.ToString());
            return status ? Response<bool>.Success(204) : Response<bool>.Fail("Basket could not found.", 404);
        }

        public async Task<Response<BasketDto>> GetBasket(string userId)
        {
            var existBasket = await _redisService.GetDb().StringGetAsync(userId);

            if (String.IsNullOrEmpty(existBasket))
            {
                return Response<BasketDto>.Fail("Basket not found", 404);
            }

            return Response<BasketDto>.Success(JsonSerializer.Deserialize<BasketDto>(existBasket), 200);
        }

        public async Task<Response<bool>> SaveOrUpdate(BasketDto basketDto)
        {
            var status = await _redisService.GetDb().StringSetAsync(basketDto.UserId,JsonSerializer.Serialize(basketDto));

            return status ? Response<bool>.Success(204) : Response<bool>.Fail("Basket could not save or update.", 400);
        }
    }
}
