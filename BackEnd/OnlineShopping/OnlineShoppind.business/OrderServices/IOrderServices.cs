using OnlineShoppind.Business.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppind.Business.OrderServices
{
    public interface IOrderServices
    {
        IEnumerable<OrderDTO> GetOrders();
        OrderDTO GetOrderById(int id);
        OrderDTO InsertOrder(OrderDTO order);
        void RemoveOrder(int id);
    }
}
