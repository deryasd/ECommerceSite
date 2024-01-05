using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ECommerceSite.Services.Catalog.Models.Models
{
    public class Products
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }
        public string Barcode { get; set; }
        public string Name { get; set; }

        [ForeignKey("Categories")]
        public int CategoryId { get; set; }
        public Categories Categories { get; set; }

        public string Property { get; set; }
        public Decimal Price { get; set; }
        public DateTime CreatedTime { get; set; }

        public List<ProductStock> ProductStock { get; set; }
    }
}
