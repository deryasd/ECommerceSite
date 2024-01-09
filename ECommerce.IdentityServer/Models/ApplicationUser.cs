
using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.IdentityServer.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public string Type { get; set; }
        [ForeignKey("Address")]
        public int AdressId { get; set; }
        public Address Address { get; set; }
        public DateTime CreatedTime { get; set; }

    }
}
