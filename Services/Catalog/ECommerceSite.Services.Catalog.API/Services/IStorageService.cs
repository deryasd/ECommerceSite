using ECommerceSite.Services.Catalog.Dtos;
using ECommerceSite.Shared.Dtos;

namespace ECommerceSite.Services.Catalog.Services
{
    public interface IStorageService
    {
        Task<Response<List<StorageDtos>>> GetAllAsync();

        Task<Response<StorageDtos>> GetByIdAsync(int id);

        Task<Response<List<StorageDtos>>> GetAllByIdAsync(int storageId);

        Task<Response<StorageDtos>> CreateAsync(StorageCreateDtos storageCreateDtos);

        Task<Response<NoContent>> UpdateAsync(StorageUpdateDtos storageUpdateDtos);

        Task<Response<NoContent>> DeleteAsync(int id);
    }
}
