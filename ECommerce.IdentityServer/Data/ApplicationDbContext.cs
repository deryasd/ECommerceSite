using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ECommerce.IdentityServer.Models;

namespace ECommerce.IdentityServer.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public const string DEFAULT_SCHEMA = "Users";
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>().ToTable("ApplicationUser", DEFAULT_SCHEMA);
            builder.Entity<Address>().ToTable("Address", DEFAULT_SCHEMA);

            builder.Entity<Address>()
                .HasMany(address => address.Users)
                .WithOne(users => users.Address)
                .HasForeignKey(users => users.AdressId);

            builder.Entity<ApplicationUser>()
                .Property(p => p.CreatedTime)
                .HasColumnType("timestamp with time zone");

        }

        public DbSet<ApplicationUser> Users {  get; set; }
        public DbSet<Address> Address { get; set; }
    }
}
