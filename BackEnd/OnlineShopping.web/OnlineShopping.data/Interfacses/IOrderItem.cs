using OnlineShopping.data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.data.Interfacses
{
    public interface IOrderItem
    {
        Task<List<OrderItems>> GetOrderItems();
        Task<OrderItems> GetOrderItem(int id);
        Task<OrderItems> CreateOrderItems(OrderItems items);
        Task<OrderItems> EditOrderItems(int id, OrderItems items);
        Task<OrderItems> DeleteItem(int id);

    }
}
