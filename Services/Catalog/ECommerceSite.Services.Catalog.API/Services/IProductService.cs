using ECommerceSite.Services.Catalog.Dtos;
using ECommerceSite.Shared.Dtos;

namespace ECommerceSite.Services.Catalog.Services
{
    public interface IProductService
    {
        Task<Response<List<ProductsDtos>>> GetAllAsync();

        Task<Response<ProductsDtos>> GetByIdAsync(int id);

        Task<Response<List<ProductsDtos>>> GetAllByIdAsync(int productId);

        Task<Response<ProductsDtos>> CreateAsync(ProductCreateDtos productCreateDto);

        Task<Response<NoContent>> UpdateAsync(ProductUpdateDtos productUpdateDto);

        Task<Response<NoContent>> DeleteAsync(int id);
    }
}
