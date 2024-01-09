using AutoMapper;
using ECommerce.IdentityServer.Dtos;
using ECommerce.IdentityServer.Models;

namespace ECommerce.IdentityServer.Mapping
{
    public class GeneralMapping:Profile
    {
        public GeneralMapping() {
            CreateMap<Address, AddressDtos>().ReverseMap();
            CreateMap<Address, AddressCreateDtos>().ReverseMap();
            CreateMap<Address, AddressUpdateDtos>().ReverseMap();
            CreateMap<ApplicationUser, SignUpDto>().ReverseMap();

        }
    }
}
