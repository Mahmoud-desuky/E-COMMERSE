using Back.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Back.Infrastracture.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions options) : base(options)
        {

        }
        // Dbset Here
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductBrand>ProductBrands { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }

    }
}
