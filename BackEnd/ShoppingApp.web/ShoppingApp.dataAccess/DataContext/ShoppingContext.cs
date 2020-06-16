using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ShoppingApp.common;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ShoppingApp.dataAccess.DataContext
{
    public class ShoppingContext : DbContext
    {
       public class OptionsBuild
        {
            public OptionsBuild()
            {
                settings = new AppConfiguration();
                opsBuilder = new DbContextOptionsBuilder<ShoppingContext>();
                opsBuilder.UseSqlServer(settings.sqlConnectionString);
                dbOptions = opsBuilder.Options;
                
            }

            public DbContextOptionsBuilder<ShoppingContext> opsBuilder { get; set; }
            public DbContextOptions<ShoppingContext> dbOptions { get; set; }
            private AppConfiguration settings { get; set; }
        }
        public static OptionsBuild ops = new OptionsBuild();

        public ShoppingContext(DbContextOptions<ShoppingContext> options): base(options) {}

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderItems> OrderItems { get; set; }
        public DbSet<Order> Orders { get; set; }

    }
}
