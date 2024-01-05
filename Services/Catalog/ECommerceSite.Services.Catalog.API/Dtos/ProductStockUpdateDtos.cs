using ECommerceSite.Services.Catalog.Dtos;

namespace ECommerceSite.Services.Catalog.API.Dtos
{
    public class ProductStockUpdateDtos
    {
        public int ProductStorageId { get; set; }
        public int StorageId { get; set; }
        public int ProductId { get; set; }
        public int Stock { get; set; }
    }
}
