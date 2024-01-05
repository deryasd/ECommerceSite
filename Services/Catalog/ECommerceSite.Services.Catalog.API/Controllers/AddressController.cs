using ECommerceSite.Services.Catalog.API.Dtos;
using ECommerceSite.Services.Catalog.Dtos;
using ECommerceSite.Services.Catalog.Services;
using ECommerceSite.Shared.ControllerBases;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceSite.Services.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : CustomBaseController
    {
        private readonly IAddressService _addressService;
        private readonly ILogger<AddressController> _logger;
        public AddressController(IAddressService addressService, ILogger<AddressController> logger)
        {
            _addressService = addressService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _addressService.GetAllAsync();

            return CreateActionResultInstance(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _addressService.GetByIdAsync(id);

            return CreateActionResultInstance(response);
        }

        [HttpGet]
        [Route("/api/[controller]/GetAllById/{addressId}")]
        public async Task<IActionResult> GetAllById(int addressId)
        {
            var response = await _addressService.GetAllByIdAsync(addressId);

            return CreateActionResultInstance(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddressCreateDtos addressCreateDtos)
        {
            var response = await _addressService.CreateAsync(addressCreateDtos);

            return CreateActionResultInstance(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(AddressUpdateDtos addressUpdateDtos)
        {
            var response = await _addressService.UpdateAsync(addressUpdateDtos);

            return CreateActionResultInstance(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _addressService.DeleteAsync(id);

            return CreateActionResultInstance(response);
        }
    }
}