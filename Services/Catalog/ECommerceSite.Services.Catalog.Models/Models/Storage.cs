using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace ECommerceSite.Services.Catalog.Models.Models
{
    public class Storage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StorageId { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        [ForeignKey("Address")]
        public int AdressId { get; set; }
        public Address Address { get; set; }

        public List<ProductStock> ProductStock { get; set; }
    }
}
