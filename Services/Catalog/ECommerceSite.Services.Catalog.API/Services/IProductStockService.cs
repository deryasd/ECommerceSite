using ECommerceSite.Services.Catalog.API.Dtos;
using ECommerceSite.Services.Catalog.Dtos;
using ECommerceSite.Shared.Dtos;

namespace ECommerceSite.Services.Catalog.API.Services
{
    public interface IProductStockService
    {
        Task<Response<List<ProductStockDtos>>> GetAllAsync();

        Task<Response<ProductStockDtos>> GetByIdAsync(int id);

        Task<Response<List<ProductStockDtos>>> GetAllByIdAsync(int productStorageId);

        Task<Response<ProductStockDtos>> CreateAsync(ProductStockCreateDtos productStockCreateDtos);

        Task<Response<NoContent>> UpdateAsync(ProductStockUpdateDtos productStockUpdateDtos);

        Task<Response<NoContent>> DeleteAsync(int id);
    }
}
