using OnlineShopping.data.Functions;
using OnlineShopping.data.Interfacses;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShopping.data.DataContext
{
    public static class ProductAccessFactory
    {
        public static IProduct GetProductDataAccessObj()
        {
            return new ProductRipository();
        }
    }
}
