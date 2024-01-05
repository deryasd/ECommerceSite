using ECommerceSite.Services.Catalog.Dtos;
using ECommerceSite.Services.Catalog.Services;
using ECommerceSite.Shared.ControllerBases;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceSite.Services.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StorageController : CustomBaseController

    {
        private readonly IStorageService _storageService;
        private readonly ILogger<StorageController> _logger;
        public StorageController(IStorageService storageService, ILogger<StorageController> logger)
        {
            _storageService = storageService;
            this._logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _storageService.GetAllAsync();

            return CreateActionResultInstance(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _storageService.GetByIdAsync(id);

            return CreateActionResultInstance(response);
        }

        [HttpGet]
        [Route("/api/[controller]/GetAllById/{storageId}")]
        public async Task<IActionResult> GetAllByUserId(int storageId)
        {
            var response = await _storageService.GetAllByIdAsync(storageId);

            return CreateActionResultInstance(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(StorageCreateDtos storageCreateDtos)
        {
            var response = await _storageService.CreateAsync(storageCreateDtos);

            return CreateActionResultInstance(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(StorageUpdateDtos storageUpdateDtos)
        {
            var response = await _storageService.UpdateAsync(storageUpdateDtos);

            return CreateActionResultInstance(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _storageService.DeleteAsync(id);

            return CreateActionResultInstance(response);
        }

    }
}
