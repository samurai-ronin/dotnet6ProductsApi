using Microsoft.EntityFrameworkCore;
using ProductsApi.Entities;

namespace ProductsApi.Data;
public class ProductContext:DbContext
{
    public ProductContext(DbContextOptions<ProductContext> options):base(options)
    {
    }
    public DbSet<Category> categories { get; set; }
    public DbSet<Product> products { get; set; }
    public DbSet<Size> sizes { get; set; }
}