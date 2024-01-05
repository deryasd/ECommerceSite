using ECommerceSite.Services.Catalog.Models.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ECommerceSite.Services.Catalog.Dtos;

namespace ECommerceSite.Services.Catalog.API.Dtos
{
    public class ProductStockDtos
    {
        public int ProductStorageId { get; set; }
        public int StorageId { get; set; }
        public StorageDtos Storage { get; set; }
        public int ProductId { get; set; }
        public ProductsDtos Product { get; set; }
        public int Stock { get; set; }
    }
}
