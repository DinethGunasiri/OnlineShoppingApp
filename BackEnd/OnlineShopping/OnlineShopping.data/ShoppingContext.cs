using Microsoft.EntityFrameworkCore;
using OnlineShopping.data.Models;
using OnlineShopping.Data.Models;

namespace OnlineShopping.data
{
    public class ShoppingContext: DbContext
    {

        public ShoppingContext(DbContextOptions<ShoppingContext> options)
            :base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<ProductCategory> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<OrderItems> OrderItems { get; set; }
    }
}
