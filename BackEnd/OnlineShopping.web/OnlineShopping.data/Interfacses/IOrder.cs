using OnlineShopping.data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.data.Interfacses
{
    public interface IOrder
    {
        Task<List<Orders>> GetOrders();
        Task<Orders> GetOrder(int id);
        Task<Orders> CreateOrder(Orders order);
       // Task<Orders> EditOrder(int id, Orders order);
        Task<Orders> DeleteOrder(int id);
    }
}
