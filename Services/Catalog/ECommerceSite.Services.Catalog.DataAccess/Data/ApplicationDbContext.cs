using ECommerceSite.Services.Catalog.Models.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;


namespace ECommerceSite.Services.Catalog.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public const string DEFAULT_SCHEMA = "Product";
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Products>().ToTable("Product", DEFAULT_SCHEMA);
            builder.Entity<Storage>().ToTable("Storage", DEFAULT_SCHEMA);
            builder.Entity<Categories>().ToTable("Categories", DEFAULT_SCHEMA);
            builder.Entity<Address>().ToTable("Address", DEFAULT_SCHEMA);
            builder.Entity<ProductStock>().ToTable("ProductStock", DEFAULT_SCHEMA);

            builder.Entity<Categories>()
                .HasMany(category => category.Products)
                .WithOne(product => product.Categories)
                .HasForeignKey(product => product.CategoryId);

            builder.Entity<Storage>()
                .HasMany(storage => storage.ProductStock)
                .WithOne(productStock => productStock.Storage)
                .HasForeignKey(product => product.StorageId);

            builder.Entity<Address>()
                .HasMany(Address => Address.Storage)
                .WithOne(storage => storage.Address)
                .HasForeignKey(storage => storage.AdressId);

            builder.Entity<Products>()
                .HasMany(product => product.ProductStock)
                .WithOne(productStock => productStock.Product)
                .HasForeignKey(productStock => productStock.ProductId);

            builder.Entity<Products>().Property(x => x.Price).HasColumnType("decimal(18,2)");

            builder.Entity<ProductStock>()
                 .Property(p => p.CreatedTime)
                 .HasColumnType("timestamp with time zone");

            builder.Entity<Products>()
                .Property(p => p.CreatedTime)
                .HasColumnType("timestamp with time zone");

            base.OnModelCreating(builder);
        }

        public DbSet<Products> Products{ get; set; }
        public DbSet<Storage> Storage { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<ProductStock> ProductStock { get; set; }
    }
}
