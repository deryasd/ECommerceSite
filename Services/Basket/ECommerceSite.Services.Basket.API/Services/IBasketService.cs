using ECommerceSite.Services.Basket.Dtos;
using ECommerceSite.Shared.Dtos;

namespace ECommerceSite.Services.Basket.Services
{
    public interface IBasketService
    {
        Task<Response<BasketDto>> GetBasket(string userId);
        Task<Response<bool>> SaveOrUpdate (BasketDto basket);
        Task<Response<bool>> Delete (string userId);

    }
}
