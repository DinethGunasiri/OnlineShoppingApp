using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineShopping.data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShopping.data.DataContext
{
    public class ShoppingContext : DbContext
    {
        public class OptionsBuild
        {
            public OptionsBuild()
            {
                settings = new Appconfiguration();
                opsBuilder = new DbContextOptionsBuilder<ShoppingContext>();
                opsBuilder.UseSqlServer(settings.sqlConnectionString);
                dbOptions = opsBuilder.Options;

            }

            public DbContextOptionsBuilder<ShoppingContext> opsBuilder { get; set; }
            public DbContextOptions<ShoppingContext> dbOptions { get; set; }
            private Appconfiguration settings { get; set; }
        }
        public static OptionsBuild ops = new OptionsBuild();

        public ShoppingContext(DbContextOptions<ShoppingContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<OrderItems> OrderItems { get; set; }
        public DbSet<ProductCategory> Categories { get; set; }
    }
}
