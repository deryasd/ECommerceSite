using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ECommerceSite.Services.Catalog.Models.Models
{
    public class Address
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AddressId { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string? Township { get; set; }
        public string? Neighbourhood { get; set; }
        public string? Street { get; set; }
        public string? Gait { get; set; }
        public string? Block { get; set; }
        public int Number { get; set; }
        public int? ZipCode { get; set; }

        public List<Storage> Storage { get; set; }
    }
}
