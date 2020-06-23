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
        private IOrder _order = new data.Functions.OrderFunction();

        // Get All Orders
        public async Task<List<Orders>> GetOrders()
        {
            try
            {
                List<Orders> order = await _order.GetOrders();

                if (order == null)
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                } 
                else
                {
                    return order;
                }
            }
            catch
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        // Get Order by id
        public async Task<Orders> GetOrder(int id)
        {
            try
            {
                Orders order = await _order.GetOrder(id);

                if(order == null)
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }
                else
                {
                    return order;
                }
            }
            catch
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        // Create Order
        public async Task<Orders> CreateOrder(Orders orders)
        {
            try
            {
                var orderDetais = await _order.CreateOrder(orders);

                if(orderDetais == null)
                {
                    throw new HttpResponseException(HttpStatusCode.BadRequest);
                }
                else
                {
                    return orderDetais;
                }
            }
            catch
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
        }

        //Delete Order
        public async Task<Orders> DeleteOrder(int id)
        {
            try
            {
                var order = await _order.DeleteOrder(id);

                if(order == null)
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }    
                else
                {
                    return order;
                }
            }
            catch
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }
        
    }
}
