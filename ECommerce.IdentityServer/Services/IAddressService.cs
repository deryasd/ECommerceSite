using ECommerce.IdentityServer.Dtos;
using ECommerceSite.Shared.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommerce.IdentityServer.Services
{
    public interface IAddressService
    {
        Task<Response<List<AddressDtos>>> GetAllAsync();
        Task<Response<AddressDtos>> CreateAsync(AddressCreateDtos addressCreateDtos);
        Task<Response<AddressDtos>> GetByIdAsync(int id);
        Task<Response<NoContent>> DeleteAsync(int id);
        Task<Response<List<AddressDtos>>> GetAllByIdAsync(int addressId);
        Task<Response<NoContent>> UpdateAsync(AddressUpdateDtos addressUpdateDtos);
    }
}
