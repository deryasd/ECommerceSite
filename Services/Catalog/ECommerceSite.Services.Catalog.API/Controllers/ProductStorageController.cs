using ECommerceSite.Services.Catalog.API.Dtos;
using ECommerceSite.Services.Catalog.API.Services;
using ECommerceSite.Shared.ControllerBases;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceSite.Services.Catalog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductStorageController : CustomBaseController
    {

        private readonly IProductStockService _productStockService;
        private readonly ILogger<ProductStorageController> _logger;
        public ProductStorageController(IProductStockService productStockService, ILogger<ProductStorageController> logger)
        {
            _productStockService = productStockService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _productStockService.GetAllAsync();

            return CreateActionResultInstance(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _productStockService.GetByIdAsync(id);

            return CreateActionResultInstance(response);
        }

        [HttpGet]
        [Route("/api/[controller]/GetAllById/{productStockId}")]
        public async Task<IActionResult> GetAllById(int productStockId)
        {
            var response = await _productStockService.GetAllByIdAsync(productStockId);

            return CreateActionResultInstance(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductStockCreateDtos productStockCreateDtos)
        {
            var response = await _productStockService.CreateAsync(productStockCreateDtos);

            return CreateActionResultInstance(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(ProductStockUpdateDtos productStockUpdateDtos)
        {
            var response = await _productStockService.UpdateAsync(productStockUpdateDtos);

            return CreateActionResultInstance(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _productStockService.DeleteAsync(id);

            return CreateActionResultInstance(response);
        }
    }
}
