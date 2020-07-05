using OnlineShopping.data.DataContext;
using OnlineShopping.data.Entities;
using OnlineShopping.data.Interfacses;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace OnlineShopping.business.OrderItemLogic
{
    public class OrderItemManage
    { 
        readonly IOrderItem _orderItemDataAccess;

        public OrderItemManage()
        {
            _orderItemDataAccess = ItemAccessFactory.GetItemDataAccessObj();
        }
        // Get All OrderItems

        public async Task<List<OrderItems>> GetOrderItems()
        {
            List<OrderItems> orderItems = await _orderItemDataAccess.GetOrderItems().ConfigureAwait(false);

            return orderItems;
        }

        // Get OrderItem
        
        public async Task<OrderItems> GetOrderItme(int id)
        {
           
            var orderItems = await _orderItemDataAccess.GetOrderItem(id).ConfigureAwait(false);

            return orderItems;
              
        }

        // Create Order Items

        public async Task<OrderItems> CreateOrderItems(OrderItems items)
        {
           
            var orderItems = await _orderItemDataAccess.CreateOrderItems(items).ConfigureAwait(false);

            return orderItems;
        }

        // Edit Order Items

        public async Task<OrderItems> EditOrderItems(int id, OrderItems items)
        {
            var orderItems = await _orderItemDataAccess.EditOrderItems(id, items).ConfigureAwait(false);

            return orderItems;
        }

        //Delete Order Items

        public async Task<OrderItems> DeleteOrderItems(int id)
        {
            var orderItems = await _orderItemDataAccess.DeleteItem(id).ConfigureAwait(false);

            return orderItems;
        }

    }
}
