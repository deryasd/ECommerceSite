using ECommerce.IdentityServer.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.IdentityServer.Dtos
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
        public Address Address { get; set; }
        public DateTime CreatedTime { get; set; } = DateTime.Now;
    }
}
