using Microsoft.AspNetCore.Identity;

namespace ECommmerce.IdentityServer.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public string Type { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string? Township { get; set; }
        public string? Neighbourhood { get; set; }
        public string? Street { get; set; }
        public string? Gait { get; set; }
        public string? Block { get; set; }
        public int Number { get; set; }
        public int? ZipCode { get; set; }

    }
}
