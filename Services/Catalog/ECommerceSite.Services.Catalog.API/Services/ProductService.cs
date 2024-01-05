using AutoMapper;
using ECommerceSite.Services.Catalog.DataAccess.Data;
using ECommerceSite.Services.Catalog.Dtos;
using ECommerceSite.Services.Catalog.Models.Models;
using ECommerceSite.Shared.Dtos;
using ECommerceSite.Services.Catalog.Services;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace ECommerceSite.Services.Catalog.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public ProductService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<Response<ProductsDtos>> CreateAsync(ProductCreateDtos productCreateDto)
        {
            var product = _mapper.Map<Products>(productCreateDto);

            _dbContext.Products.Add(product);
            await _dbContext.SaveChangesAsync();

            return Response<ProductsDtos>.Success(_mapper.Map<ProductsDtos>(product), 200);
        }

        public async Task<Response<NoContent>> DeleteAsync(int id)
        {
            var product = await _dbContext.Products.FindAsync(id);

            if (product == null)
            {
                return Response<NoContent>.Fail("Product not found", 404);
            }

            _dbContext.Products.Remove(product);
            await _dbContext.SaveChangesAsync();

            return Response<NoContent>.Success(204);
        }

        public async Task<Response<List<ProductsDtos>>> GetAllAsync()
        {
            var products = await _dbContext.Products
                .Include(p => p.Categories)
                .ToListAsync();
            return Response<List<ProductsDtos>>.Success(_mapper.Map<List<ProductsDtos>>(products), 200);
        }

        public async Task<Response<List<ProductsDtos>>> GetAllByIdAsync(int productId)
        {
            var products = await _dbContext.Products
            .Where(p => p.ProductId == productId)
            .Include(p => p.Categories)
            .ToListAsync();

            return Response<List<ProductsDtos>>.Success(_mapper.Map<List<ProductsDtos>>(products), 200);
        }

        public async Task<Response<ProductsDtos>> GetByIdAsync(int id)
        {
            var product = await _dbContext.Products.FindAsync(id);

            if (product == null)
            {
                return Response<ProductsDtos>.Fail("Product not found", 404);
            }

            return Response<ProductsDtos>.Success(_mapper.Map<ProductsDtos>(product), 200);
        }

        public async Task<Response<NoContent>> UpdateAsync(ProductUpdateDtos productUpdateDto)
        {
            var products = await _dbContext.Products.FindAsync(productUpdateDto.ProductId);

            if (products == null)
            {
                return Response<NoContent>.Fail("Product not found", 404);
            }
            products.Name = productUpdateDto.Name;
            products.Property = productUpdateDto.Property;
            products.Barcode = productUpdateDto.Barcode;
            products.Price = productUpdateDto.Price;
            products.CategoryId = productUpdateDto.CategoryId;
            

            _dbContext.Update(products);
            await _dbContext.SaveChangesAsync();

            return Response<NoContent>.Success(204);
        }
    }
}
