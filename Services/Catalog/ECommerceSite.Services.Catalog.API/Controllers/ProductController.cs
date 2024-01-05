using ECommerceSite.Services.Catalog.Dtos;
using ECommerceSite.Services.Catalog.Services;
using ECommerceSite.Shared.ControllerBases;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceSite.Services.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : CustomBaseController
    {
        private readonly IProductService _productService;
        private readonly ILogger<ProductController> _logger;
        public ProductController(IProductService productService, ILogger<ProductController> logger)
        {
            _productService = productService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _productService.GetAllAsync();

            return CreateActionResultInstance(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _productService.GetByIdAsync(id);

            return CreateActionResultInstance(response);
        }

        [HttpGet]
        [Route("/api/[controller]/GetAllById/{productId}")]
        public async Task<IActionResult> GetAllByUserId(int productId)
        {
            var response = await _productService.GetAllByIdAsync(productId);

            return CreateActionResultInstance(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateDtos productCreateDto)
        {
            var response = await _productService.CreateAsync(productCreateDto);

            return CreateActionResultInstance(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(ProductUpdateDtos productUpdateDtos )
        {
            var response = await _productService.UpdateAsync(productUpdateDtos);

            return CreateActionResultInstance(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _productService.DeleteAsync(id);

            return CreateActionResultInstance(response);
        }

    }
}
