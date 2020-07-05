using OnlineShopping.data.DataContext;
using OnlineShopping.data.Entities;
using OnlineShopping.data.Interfacses;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace OnlineShopping.business.OrderLogic
{
    public class OrderManage
    {
        readonly IOrder _orderDataAccess;

        public OrderManage()
        {
            _orderDataAccess = OrderAccessFactory.GetOrderDataAccessObj();
        }

        // Get All Orders
        public async Task<List<Orders>> GetOrders()
        {
            List<Orders> order = await _orderDataAccess.GetOrders().ConfigureAwait(false);

            return order;
        }

        // Get Order by id
        public async Task<Orders> GetOrder(int id)
        {
           
            Orders order = await _orderDataAccess.GetOrder(id).ConfigureAwait(false);

            return order;
        }

        // Create Order
        public async Task<Orders> CreateOrder(Orders orders)
        {
           
            var orderDetais = await _orderDataAccess.CreateOrder(orders).ConfigureAwait(false);

            return orderDetais;
        }

        //Delete Order
        public async Task<Orders> DeleteOrder(int id)
        {
            
            var order = await _orderDataAccess.DeleteOrder(id).ConfigureAwait(false);

            return order;
        }
        
    }
}
