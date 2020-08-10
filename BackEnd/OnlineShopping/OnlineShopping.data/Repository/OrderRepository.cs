using OnlineShopping.data;
using OnlineShopping.Data.IRepositories;
using OnlineShopping.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopping.Data.Repository
{
    public class OrderRepository : Repository<Orders>, IOrderRepository 
    {
        public OrderRepository(ShoppingContext context) : base(context)
        {

        }

        public IEnumerable<Orders> GetOrders()
        {
            return context.Orders.ToList();
        }
        public Orders GetOrderById(int id)
        {
            return context.Orders.Find(id);
        }

        public Orders InsertOrder(Orders orders)
        {
            return context.Orders.Add(orders).Entity; 
        }

        public void RemoveOrder(int id)
        {
            var order = context.Orders.Find(id);
            context.Orders.Remove(order);
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
