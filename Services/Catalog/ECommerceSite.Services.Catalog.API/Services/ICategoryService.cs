using ECommerceSite.Services.Catalog.API.Dtos;
using ECommerceSite.Services.Catalog.Dtos;
using ECommerceSite.Shared.Dtos;

namespace ECommerceSite.Services.Catalog.Services
{
    public interface ICategoryService
    {
        Task<Response<List<CategoryDtos>>> GetAllAsync();

        Task<Response<CategoryDtos>> CreateAsync(CategoryCreateDtos categoryCreateDtos);

        Task<Response<CategoryDtos>> GetByIdAsync(int id);
        Task<Response<NoContent>> DeleteAsync(int id);
        Task<Response<List<CategoryDtos>>> GetAllByIdAsync(int categoryId);

        Task<Response<NoContent>> UpdateAsync(CategoryUpdateDtos categoryUpdateDtos);

    }
}
