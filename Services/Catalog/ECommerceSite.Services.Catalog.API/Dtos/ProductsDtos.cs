using ECommerceSite.Services.Catalog.Models;
using ECommerceSite.Services.Catalog.Models.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceSite.Services.Catalog.Dtos
{
    public class ProductsDtos
    {
        public int ProductId { get; set; }
        public string Barcode { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public CategoryDtos Categories { get; set; }
        public string Property { get; set; }
        public Decimal Price { get; set; }

    }
}
