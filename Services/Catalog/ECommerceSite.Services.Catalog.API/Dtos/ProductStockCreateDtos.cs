namespace ECommerceSite.Services.Catalog.API.Dtos
{
    public class ProductStockCreateDtos
    {
        public int StorageId { get; set; }
        public int ProductId { get; set; }
        public int Stock { get; set; }
        public DateTime CreatedTime { get; set; } = DateTime.Now;
    }
}
