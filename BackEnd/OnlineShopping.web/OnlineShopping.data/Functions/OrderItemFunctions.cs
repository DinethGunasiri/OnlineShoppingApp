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
    public class OrderItemFunctions : IOrderItem
    {
        // Get All Order Items
        public async Task<List<OrderItems>> GetOrderItems()
        {
            List<OrderItems> orderItems = new List<OrderItems>();

            using(var context = new ShoppingContext(ShoppingContext.ops.dbOptions))
            {
                orderItems = await context.OrderItems.ToListAsync();
            }

            return orderItems;
        }

        // Get Order Items by id
        public async Task<OrderItems> GetOrderItem(int id)
        {
            var orderItem = new OrderItems();

            using (var context = new ShoppingContext(ShoppingContext.ops.dbOptions))
            {
                orderItem = await context.OrderItems.SingleOrDefaultAsync(c => c.ItemId == id);
            }
            return orderItem;
        }

        // Create Order Items
        public async Task<OrderItems> CreateOrderItems(OrderItems items)
        {
            using(var context = new ShoppingContext(ShoppingContext.ops.dbOptions))
            {
                await context.OrderItems.AddAsync(items);
                await context.SaveChangesAsync();
            }

            return items;
        }

        // Edit Order Items
        public async Task<OrderItems> EditOrderItems(int id, OrderItems items)
        {
            var orderItems = new OrderItems();

            using(var context = new ShoppingContext(ShoppingContext.ops.dbOptions))
            {
                orderItems = await context.OrderItems.SingleOrDefaultAsync(c => c.ItemId == id);

                if(orderItems != null)
                {
                    orderItems.Product = items.Product;
                    orderItems.ProductId = items.ProductId;
                    orderItems.PurchasePrice = items.PurchasePrice;
                    orderItems.Quantity = items.Quantity;
                }
            }
            return orderItems;
        }

        // Delete Order Items
        public async Task<OrderItems> DeleteItem(int id)
        {
            var orderItems = new OrderItems();

            using(var context = new ShoppingContext(ShoppingContext.ops.dbOptions))
            {
                orderItems = await context.OrderItems.SingleOrDefaultAsync(c => c.ItemId == id);

                if(orderItems != null)
                {
                    context.OrderItems.Remove(orderItems);
                    await context.SaveChangesAsync();
                }
            }
            return orderItems; 
        }
    }
}
