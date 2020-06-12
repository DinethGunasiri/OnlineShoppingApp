using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace ShoppingApp.dataAccess.DataContext
{
    class DatabseContextFactory:IDesignTimeDbContextFactory<ShoppingContext>
    {
        public ShoppingContext CreateDbContext(string[] args)
        {
            AppConfiguration appConfig = new AppConfiguration();
            var opsBuilder = new DbContextOptionsBuilder<ShoppingContext>();
            opsBuilder.UseSqlServer(appConfig.sqlConnectionString);
            return new ShoppingContext(opsBuilder.Options);
        }
    }
}
