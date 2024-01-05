namespace ECommerceSite.Services.Catalog.Dtos
{
    public class ProductCreateDtos
    {
        public string Barcode { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public string Property { get; set; }
        public Decimal Price { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
