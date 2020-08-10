using OnlineShopping.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShopping.Data.IRepositories
{
    public interface IOrderRepository
    {
        IEnumerable<Orders> GetOrders();
        Orders GetOrderById(int id);
        Orders InsertOrder(Orders orders);
        void RemoveOrder(int id);
        void Save();
    }
}
