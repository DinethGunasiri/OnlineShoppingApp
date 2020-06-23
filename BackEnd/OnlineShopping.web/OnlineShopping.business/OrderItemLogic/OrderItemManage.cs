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
        private IOrderItem _orderItems = new data.Functions.OrderItemFunctions();

        // Get All OrderItems

        public async Task<List<OrderItems>> GetOrderItems()
        {
            try
            {
                List<OrderItems> orderItems = await _orderItems.GetOrderItems();

                if(orderItems == null)
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }
                else
                {
                    return orderItems;
                }
            }
            catch (Exception)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        // Get OrderItem
        
        public async Task<OrderItems> GetOrderItme(int id)
        {
            try
            {
                var orderItems = await _orderItems.GetOrderItem(id);

                if (orderItems == null)
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }
                else
                {
                    return orderItems;
                }
            }
            catch (Exception)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        // Create Order Items

        public async Task<OrderItems> CreateOrderItems(OrderItems items)
        {
            try
            {
                var orderItems = await _orderItems.CreateOrderItems(items);

                if(orderItems == null)
                {
                    throw new HttpResponseException(HttpStatusCode.BadRequest);
                }
                else
                {
                    return orderItems;
                }
            }
            catch (Exception)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
        }

        // Edit Order Items

        public async Task<OrderItems> EditOrderItems(int id, OrderItems items)
        {
            try
            {
                var orderItems = await _orderItems.EditOrderItems(id, items);

                if(orderItems == null)
                {
                    throw new HttpResponseException(HttpStatusCode.BadRequest);
                }
                else
                {
                    return orderItems;
                }
            }
            catch (Exception)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
        }

        //Delete Order Items

        public async Task<OrderItems> DeleteOrderItems(int id)
        {
            try
            {
                var orderItems = await _orderItems.DeleteItem(id);

                if(orderItems == null)
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }    
                else
                {
                    return orderItems;
                }
            }
            catch (Exception)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

    }
}
