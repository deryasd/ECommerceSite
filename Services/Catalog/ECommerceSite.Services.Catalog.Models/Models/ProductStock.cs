using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceSite.Services.Catalog.Models.Models
{
    public class ProductStock
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductStorageId { get; set; }
        [ForeignKey("Storage")]
        public int StorageId { get; set; }
        public Storage Storage { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Products Product { get; set; }
        public int Stock { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}
