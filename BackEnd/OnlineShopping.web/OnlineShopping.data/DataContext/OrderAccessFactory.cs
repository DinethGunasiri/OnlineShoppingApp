using OnlineShopping.data.Functions;
using OnlineShopping.data.Interfacses;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShopping.data.DataContext
{
    public static class OrderAccessFactory
    {
        public static IOrder GetOrderDataAccessObj()
        {
            return new OrderRepository();
        }
    }
}
