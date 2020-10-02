using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Pattengoods.Models
{
  public class PattengoodsContext : IdentityDbContext<User>
  {
    public DbSet<Category> Categories { get; set; }

    public DbSet<CategoryProduct> CategoryProduct { get; set; }

    public DbSet<Image> Images { get; set; }

    public DbSet<Product> Products { get; set; }

    public PattengoodsContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      base.OnModelCreating(builder);

      builder.Entity<Category>()
        .HasData(
          new Category {
            CategoryId = 1,
            CategoryTitle = "Furniture"
          }
        );

      builder.Entity<CategoryProduct>()
        .HasData(
          new CategoryProduct {
            CategoryProductId = 1,
            CategoryId = 1,
            ProductId = 1
          }
        );

      builder.Entity<Product>()
        .HasData(
          new Product {
            ProductId = 1,
            ProductManufacturer = "Thuma", 
            ProductName = "The Bed",
            ProductPrice = 995.00m,
            ProductDescription = "Meet the perfect platform bed frame. Thoughtfully designed and crafted to elevate any bedroom. Includes natural walnut colored frame, PillowBoard and cushion-coated slats.",
            ProductLink = "https://www.thuma.co/products/the-bed?variant=7550696456220"
          }
        );
    }
  }
}