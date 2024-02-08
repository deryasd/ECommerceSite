using ECommerceSite.Services.Basket.DataAccess;
using ECommerceSite.Shared.Messages;
using MassTransit;

namespace ECommerceSite.Services.Basket.Application.Consumers
{
    public class BasketUpdatedEventConsumer : IConsumer<BasketUpdatedEvent>
    {
        private readonly RedisService _redisService;

        public BasketUpdatedEventConsumer(RedisService redisService)
        {
            _redisService = redisService;
        }

        public async Task Consume(ConsumeContext<BasketUpdatedEvent> context)
        {
            await _redisService.GetDb().KeyDeleteAsync(context.Message.UserId.ToString());

        }
    }
}
