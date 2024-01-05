using AutoMapper;
using ECommerceSite.Services.Catalog.API.Dtos;
using ECommerceSite.Services.Catalog.DataAccess.Data;
using ECommerceSite.Services.Catalog.Dtos;
using ECommerceSite.Services.Catalog.Models.Models;
using ECommerceSite.Shared.Dtos;
using Microsoft.EntityFrameworkCore;

namespace ECommerceSite.Services.Catalog.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public CategoryService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<Response<CategoryDtos>> CreateAsync(CategoryCreateDtos categoryCreateDtos)
        {
            var category = _mapper.Map<Categories>(categoryCreateDtos);
            _dbContext.Categories.Add(category);
            await _dbContext.SaveChangesAsync();

            return Response<CategoryDtos>.Success(_mapper.Map<CategoryDtos>(category), 200);
        }

        public async Task<Response<NoContent>> DeleteAsync(int id)
        {
            var category = await _dbContext.Categories.FindAsync(id);

            if (category == null)
            {
                return Response<NoContent>.Fail("Product not found", 404);
            }

            _dbContext.Categories.Remove(category);
            await _dbContext.SaveChangesAsync();

            return Response<NoContent>.Success(204);
        }

        public async Task<Response<List<CategoryDtos>>> GetAllAsync()
        {
            var category = await _dbContext.Categories.ToListAsync();
            return Response<List<CategoryDtos>>.Success(_mapper.Map<List<CategoryDtos>>(category), 200);
        }

        public async Task<Response<List<CategoryDtos>>> GetAllByIdAsync(int categoryId)
        {
            var category = await _dbContext.Categories
            .Where(p => p.CategoryId == categoryId)
            .ToListAsync();

            return Response<List<CategoryDtos>>.Success(_mapper.Map<List<CategoryDtos>>(category), 200);
        }

        public async Task<Response<CategoryDtos>> GetByIdAsync(int id)
        {
            var category = await _dbContext.Categories.FindAsync(id);

            if (category == null)
            {
                return Response<CategoryDtos>.Fail("Product not found", 404);
            }

            return Response<CategoryDtos>.Success(_mapper.Map<CategoryDtos>(category), 200);
        }

        public async Task<Response<NoContent>> UpdateAsync(CategoryUpdateDtos categoryUpdateDtos)
        {
            var category = await _dbContext.Categories.FindAsync(categoryUpdateDtos.CategoryId);

            if (category == null)
            {
                return Response<NoContent>.Fail("Product not found", 404);
            }

            category.Name = categoryUpdateDtos.Name;
            category.Description = categoryUpdateDtos.Description;
            
            _dbContext.Update(category);
            await _dbContext.SaveChangesAsync();

            return Response<NoContent>.Success(204);
        }
    }
}
