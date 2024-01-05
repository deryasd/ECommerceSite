using AutoMapper;
using ECommerceSite.Services.Catalog.DataAccess.Data;
using ECommerceSite.Services.Catalog.Dtos;
using ECommerceSite.Services.Catalog.Models.Models;
using ECommerceSite.Shared.Dtos;
using Microsoft.EntityFrameworkCore;

namespace ECommerceSite.Services.Catalog.Services
{
    public class StorageService : IStorageService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public StorageService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<Response<StorageDtos>> CreateAsync(StorageCreateDtos storageCreateDto)
        {
            var storage = _mapper.Map<Storage>(storageCreateDto);

            _dbContext.Storage.Add(storage);
            await _dbContext.SaveChangesAsync();

            return Response<StorageDtos>.Success(_mapper.Map<StorageDtos>(storage), 200);
        }

        public async Task<Response<NoContent>> DeleteAsync(int id)
        {

            var storage = await _dbContext.Storage.FindAsync(id);

            if (storage == null)
            {
                return Response<NoContent>.Fail("Product not found", 404);
            }

            _dbContext.Storage.Remove(storage);
            await _dbContext.SaveChangesAsync();

            return Response<NoContent>.Success(204);
        }

        public async Task<Response<List<StorageDtos>>> GetAllAsync()
        {
            var storage = await _dbContext.Storage
                .Include(p => p.Address)
                .ToListAsync();
            return Response<List<StorageDtos>>.Success(_mapper.Map<List<StorageDtos>>(storage), 200);
        }

        public async Task<Response<List<StorageDtos>>> GetAllByIdAsync(int storageId)
        {
            var storage = await _dbContext.Storage
             .Where(p => p.StorageId == storageId)
             .Include(p => p.Address)
             .ToListAsync();

            return Response<List<StorageDtos>>.Success(_mapper.Map<List<StorageDtos>>(storage), 200);
        }

        public async Task<Response<StorageDtos>> GetByIdAsync(int id)
        {
            var storage = await _dbContext.Storage.FindAsync(id);

            if (storage == null)
            {
                return Response<StorageDtos>.Fail("Product not found", 404);
            }

            return Response<StorageDtos>.Success(_mapper.Map<StorageDtos>(storage), 200);
        }

        public async Task<Response<NoContent>> UpdateAsync(StorageUpdateDtos storageUpdateDto)
        {
            var storage = await _dbContext.Storage.FindAsync(storageUpdateDto.StorageId);

            if (storage == null)
            {
                return Response<NoContent>.Fail("Product not found", 404);
            }

            storage.Name = storageUpdateDto.Name;
            storage.PhoneNumber = storageUpdateDto.PhoneNumber;
            storage.AdressId = storageUpdateDto.AdressId;

            _dbContext.Update(storage);
            await _dbContext.SaveChangesAsync();

            return Response<NoContent>.Success(204);
        }
    }
}
