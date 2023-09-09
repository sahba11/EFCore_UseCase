using EfCore.Domain.ProductAgg;
using EfCore.Domain.ProductCategoryAgg;
using EFCore.Infrastructure.EFCore.Mapping;
using Microsoft.EntityFrameworkCore;

namespace EFCore.Infrastructure.EFCore
{
    public class EfContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }

        public EfContext(DbContextOptions<EfContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(ProductMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
