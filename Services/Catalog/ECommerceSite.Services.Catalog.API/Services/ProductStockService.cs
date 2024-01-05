using AutoMapper;
using ECommerceSite.Services.Catalog.API.Dtos;
using ECommerceSite.Services.Catalog.DataAccess.Data;
using ECommerceSite.Services.Catalog.Dtos;
using ECommerceSite.Services.Catalog.Models.Models;
using ECommerceSite.Shared.Dtos;
using Microsoft.EntityFrameworkCore;

namespace ECommerceSite.Services.Catalog.API.Services
{
    public class ProductStockService : IProductStockService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public ProductStockService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<Response<ProductStockDtos>> CreateAsync(ProductStockCreateDtos productStockCreateDtos)
        {
            var productStock = _mapper.Map<ProductStock>(productStockCreateDtos);

            _dbContext.ProductStock.Add(productStock);
            await _dbContext.SaveChangesAsync();

            return Response<ProductStockDtos>.Success(_mapper.Map<ProductStockDtos>(productStock), 200);
        }

        public async Task<Response<NoContent>> DeleteAsync(int id)
        {
            var productStock = await _dbContext.ProductStock.FindAsync(id);

            if (productStock == null)
            {
                return Response<NoContent>.Fail("Product not found", 404);
            }

            _dbContext.ProductStock.Remove(productStock);
            await _dbContext.SaveChangesAsync();

            return Response<NoContent>.Success(204);
        }

        public async Task<Response<List<ProductStockDtos>>> GetAllAsync()
        {
            var productStock = await _dbContext.ProductStock
                .Include(p => p.Storage)
                .Include(p => p.Storage.Address)
                .Include(p => p.Product)
                .Include(p => p.Product.Categories)
                .ToListAsync();
            return Response<List<ProductStockDtos>>.Success(_mapper.Map<List<ProductStockDtos>>(productStock), 200);
        }

        public async Task<Response<List<ProductStockDtos>>> GetAllByIdAsync(int productStorageId)
        {
            var productStock = await _dbContext.ProductStock
            .Where(p => p.ProductStorageId == productStorageId)
            .Include(p => p.Storage)
            .Include(p => p.Storage.Address)
            .Include(p => p.Product)
            .Include(p => p.Product.Categories)
            .ToListAsync();

            return Response<List<ProductStockDtos>>.Success(_mapper.Map<List<ProductStockDtos>>(productStock), 200);
        }

        public async Task<Response<ProductStockDtos>> GetByIdAsync(int id)
        {
            var productStock = await _dbContext.ProductStock.FindAsync(id);

            if (productStock == null)
            {
                return Response<ProductStockDtos>.Fail("Product not found", 404);
            }

            return Response<ProductStockDtos>.Success(_mapper.Map<ProductStockDtos>(productStock), 200);
        }

        public async Task<Response<NoContent>> UpdateAsync(ProductStockUpdateDtos productStockUpdateDtos)
        {
            var productStock = await _dbContext.ProductStock.FindAsync(productStockUpdateDtos.ProductStorageId);

            if (productStock == null)
            {
                return Response<NoContent>.Fail("Product not found", 404);
            }
            productStock.StorageId = productStockUpdateDtos.StorageId;
            productStock.ProductId = productStockUpdateDtos.ProductId;
            productStock.Stock = productStockUpdateDtos.Stock;

            _dbContext.Update(productStock);
            await _dbContext.SaveChangesAsync();

            return Response<NoContent>.Success(204);
        }
    }
}
