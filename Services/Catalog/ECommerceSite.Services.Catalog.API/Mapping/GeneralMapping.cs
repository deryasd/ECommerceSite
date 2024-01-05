using AutoMapper;
using ECommerceSite.Services.Catalog.API.Dtos;
using ECommerceSite.Services.Catalog.Dtos;
using ECommerceSite.Services.Catalog.Models.Models;

namespace ECommerceSite.Services.Catalog.Mapping
{
    public class GeneralMapping:Profile
    {
        public GeneralMapping() {
            CreateMap<Products, ProductsDtos>().ReverseMap();
            CreateMap<Address, AddressDtos>().ReverseMap();
            CreateMap<Categories, CategoryDtos>().ReverseMap();
            CreateMap<Storage, StorageDtos>().ReverseMap();
            CreateMap<Products, ProductCreateDtos>().ReverseMap();
            CreateMap<Products, ProductUpdateDtos>().ReverseMap();
            CreateMap<Storage, StorageCreateDtos>().ReverseMap();
            CreateMap<Storage, StorageUpdateDtos>().ReverseMap();
            CreateMap<Address, AddressCreateDtos>().ReverseMap();
            CreateMap<Address, AddressUpdateDtos>().ReverseMap();
            CreateMap<Categories, CategoryCreateDtos>().ReverseMap();
            CreateMap<Categories, CategoryUpdateDtos>().ReverseMap();
            CreateMap<ProductStock, ProductStockDtos>().ReverseMap();
            CreateMap<ProductStock, ProductStockCreateDtos>().ReverseMap();
            CreateMap<ProductStock, ProductStockUpdateDtos>().ReverseMap();
        }
    }
}
