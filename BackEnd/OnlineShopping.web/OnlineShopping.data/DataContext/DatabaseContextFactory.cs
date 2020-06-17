using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShopping.data.DataContext
{
    class DatabaseContextFactory : IDesignTimeDbContextFactory<ShoppingContext>
    {
        public ShoppingContext CreateDbContext(string[] args)
        {
            Appconfiguration appConfig = new Appconfiguration();
            var opsBuilder = new DbContextOptionsBuilder<ShoppingContext>();
            opsBuilder.UseSqlServer(appConfig.sqlConnectionString);
            return new ShoppingContext(opsBuilder.Options);
        }
    }
}
