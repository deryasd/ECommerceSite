using System.ComponentModel.DataAnnotations;

namespace ECommmerce.IdentityServer.Dtos
{
    public class SignUpDto
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string City { get; set; }
        public string? Township { get; set; }
        public string? Neighbourhood { get; set; }
        public string? Street { get; set; }
        public string? Gait { get; set; }
        public string? Block { get; set; }
        [Required]
        public int Number { get; set; }
        public int? ZipCode { get; set; }
    }
}
