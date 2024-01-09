using AutoMapper;
using ECommerce.IdentityServer.Data;
using ECommerce.IdentityServer.Dtos;
using ECommerce.IdentityServer.Models;
using ECommerceSite.Shared.Dtos;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.IdentityServer.Services
{
    public class AddressService : IAddressService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public AddressService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<Response<AddressDtos>> CreateAsync(AddressCreateDtos addressCreateDtos)
        {
            var address = _mapper.Map<Address>(addressCreateDtos);
            _dbContext.Address.Add(address);
            await _dbContext.SaveChangesAsync();

            return Response<AddressDtos>.Success(_mapper.Map<AddressDtos>(address), 200);
        }

        public async Task<Response<NoContent>> DeleteAsync(int id)
        {
            var address = await _dbContext.Address.FindAsync(id);

            if (address == null)
            {
                return Response<NoContent>.Fail("Product not found", 404);
            }

            _dbContext.Address.Remove(address);
            await _dbContext.SaveChangesAsync();

            return Response<NoContent>.Success(204);
        }

        public async Task<Response<List<AddressDtos>>> GetAllAsync()
        {
            var address = await _dbContext.Address.ToListAsync();
            return Response<List<AddressDtos>>.Success(_mapper.Map<List<AddressDtos>>(address), 200);
        }

        public async Task<Response<List<AddressDtos>>> GetAllByIdAsync(int addressId)
        {
            var address = await _dbContext.Address
             .Where(p => p.AddressId == addressId)
             .ToListAsync();

            return Response<List<AddressDtos>>.Success(_mapper.Map<List<AddressDtos>>(address), 200);
        }

        public async Task<Response<AddressDtos>> GetByIdAsync(int id)
        {
            var address = await _dbContext.Address.FindAsync(id);

            if (address == null)
            {
                return Response<AddressDtos>.Fail("Product not found", 404);
            }

            return Response<AddressDtos>.Success(_mapper.Map<AddressDtos>(address), 200);
        }

        public async Task<Response<NoContent>> UpdateAsync(AddressUpdateDtos addressUpdateDtos)
        {
            var address = await _dbContext.Address.FindAsync(addressUpdateDtos.AddressId);

            if (address == null)
            {
                return Response<NoContent>.Fail("Product not found", 404);
            }
            address.AddressId = addressUpdateDtos.AddressId;
            address.Country = addressUpdateDtos.Country;
            address.City = addressUpdateDtos.City;
            address.Township = addressUpdateDtos.Township;
            address.Neighbourhood = addressUpdateDtos.Neighbourhood;
            address.Street = addressUpdateDtos.Street;
            address.Gait = addressUpdateDtos.Gait;
            address.Block = addressUpdateDtos.Block;
            address.Number = addressUpdateDtos.Number;
            address.ZipCode = addressUpdateDtos.ZipCode;

            _dbContext.Update(address);
            await _dbContext.SaveChangesAsync();

            return Response<NoContent>.Success(204);
        }
    }
}
