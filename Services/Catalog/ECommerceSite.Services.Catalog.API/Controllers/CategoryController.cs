using ECommerceSite.Services.Catalog.API.Dtos;
using ECommerceSite.Services.Catalog.Dtos;
using ECommerceSite.Services.Catalog.Services;
using ECommerceSite.Shared.ControllerBases;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceSite.Services.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : CustomBaseController
    {
        private readonly ICategoryService _categoryService;
        private readonly ILogger<CategoryController> _logger;

        public CategoryController(ICategoryService categoryService, ILogger<CategoryController> logger)
        {
            _categoryService = categoryService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _categoryService.GetAllAsync();

            return CreateActionResultInstance(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _categoryService.GetByIdAsync(id);

            return CreateActionResultInstance(response);
        }

        [HttpGet]
        [Route("/api/[controller]/GetAllById/{categoryId}")]
        public async Task<IActionResult> GetAllById(int categoryId)
        {
            var response = await _categoryService.GetAllByIdAsync(categoryId);

            return CreateActionResultInstance(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryCreateDtos categoryCreateDtos)
        {
            var response = await _categoryService.CreateAsync(categoryCreateDtos);

            return CreateActionResultInstance(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(CategoryUpdateDtos categoryUpdateDtos)
        {
            var response = await _categoryService.UpdateAsync(categoryUpdateDtos);

            return CreateActionResultInstance(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _categoryService.DeleteAsync(id);

            return CreateActionResultInstance(response);
        }
    }
}
