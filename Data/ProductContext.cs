using Microsoft.EntityFrameworkCore;

namespace BlazorApp1.Data
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions <ProductContext> options) : base(options) { }
        public DbSet<BlazorApp1.Models.Product> Products { get; set; }
    }
}
