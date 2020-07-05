using Microsoft.EntityFrameworkCore;
using OnlineShopping.data.DataContext;
using OnlineShopping.data.Entities;
using OnlineShopping.data.Interfacses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.data.Functions
{
    public class OrderRepository : IOrder
    {
        public async Task<Orders> CreateOrder(Orders order)
        {
            using(var context = new ShoppingContext(ShoppingContext.ops.dbOptions))
            {
                await context.Orders.AddAsync(order);
                await context.SaveChangesAsync();
            }
            return order;
        }

        public async Task<Orders> DeleteOrder(int id)
        {
            var order = new Orders();
            using(var context = new ShoppingContext(ShoppingContext.ops.dbOptions))
            {
                order = await context.Orders.SingleOrDefaultAsync(c => c.OrderId == id);

                context.Orders.Remove(order);
                await context.SaveChangesAsync();
            }
            return order;
        }

        //public async Task<Orders> EditOrder(int id, Orders order)
        //{
        //    var orderDetails = new Orders();

        //    using(var context = new ShoppingContext(ShoppingContext.ops.dbOptions))
        //    {
        //        orderDetails = await context.Orders.SingleOrDefaultAsync(c => c.OrderId == id);

        //        if (orderDetails != null)
        //        {
        //            orderDetails.
        //        }
        //    }
        //}

        public async Task<Orders> GetOrder(int id)
        {
            var order = new Orders();

            using(var context = new ShoppingContext(ShoppingContext.ops.dbOptions))
            {
                order = await context.Orders.SingleOrDefaultAsync(c => c.OrderId == id);
            }
            return order;
        }

        public async Task<List<Orders>> GetOrders()
        {
            List<Orders> order = new List<Orders>();
            using(var context = new ShoppingContext(ShoppingContext.ops.dbOptions))
            {
                order = await context.Orders.ToListAsync();
            }
            return order;
        }
    }
}
