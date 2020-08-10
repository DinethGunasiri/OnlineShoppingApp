using Microsoft.EntityFrameworkCore;
using OnlineShopping.data;
using OnlineShopping.Data.IRepositories;
using OnlineShopping.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShopping.Data.Repository
{
    public class OrderItemsRepository : Repository<OrderItems>, IOrderItemRepository
    {
        public OrderItemsRepository(ShoppingContext context) : base(context)
        {

        }

        public IEnumerable<OrderItems> GeItems()
        {
            return context.OrderItems.ToList();
        }

        public OrderItems GetItemById(int id)
        {
            return context.OrderItems.Find(id);
        }

        public OrderItems InsertItems(OrderItems items)
        {
            context.OrderItems.Add(items);

            return items;
        }

        public void RemoveItems(int id)
        {
            var items = context.OrderItems.Find(id);
            context.OrderItems.Remove(items);
        }
        public OrderItems UpdateItems(OrderItems items)
        {
            context.Entry(items).State = EntityState.Modified;
            return items;
        }
        public void Save()
        {
            context.SaveChanges();
        }

        
    }
}
