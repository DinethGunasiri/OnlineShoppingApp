using OnlineShopping.data.Functions;
using OnlineShopping.data.Interfacses;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShopping.data.DataContext
{
    public class ItemAccessFactory
    {
        public static IOrderItem GetItemDataAccessObj()
        {
            return new OrderItemRepository();
        }
    }
}
