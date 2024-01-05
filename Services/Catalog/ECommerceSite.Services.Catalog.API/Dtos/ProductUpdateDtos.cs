namespace ECommerceSite.Services.Catalog.Dtos
{
    public class ProductUpdateDtos 
    {
        public int ProductId { get; set; }
        public string Barcode { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public string Property { get;  set; }
        public Decimal Price { get;  set; }
    }
}
