using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShopping.business.OrderLogic;
using OnlineShopping.data.Entities;
using OnlineShopping.service.Models;

namespace OnlineShopping.service.Controllers
{
    [Route("api/order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private OrderManage _orderManage; // = new OrderManage();

        public OrderController()
        {
            _orderManage = new OrderManage();
        }

       
        [HttpGet]
        public async Task<List<OrderViewModel>> GetOrders()
        {
            List<OrderViewModel> orderList = new List<OrderViewModel>();
            var orders = await _orderManage.GetOrders().ConfigureAwait(false);

            if(orders.Count > 0)
            {
                foreach(var order in orders)
                {
                    OrderViewModel currentOrder = new OrderViewModel
                    {
                        OrderId = order.OrderId,
                        CustomerId = order.CustomerId,
                        OrderDate = order.OrderDate,
                        ShippingAddress = order.ShippingAddress
                    };
                    orderList.Add(currentOrder);
                }
            }
            return orderList;
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<OrderViewModel> GetOrder(int id)
        {
            var order = await _orderManage.GetOrder(id).ConfigureAwait(false);

            OrderViewModel currentOrder = new OrderViewModel
            {
                OrderId = order.OrderId,
                CustomerId = order.CustomerId,
                OrderDate = order.OrderDate,
                ShippingAddress = order.ShippingAddress
            };
            return currentOrder;
        }

       
        [HttpPost]
        public async Task<Orders> CreateOrder(Orders orders)
        {
            return await _orderManage.CreateOrder(orders).ConfigureAwait(false);
        }

        [Route("{id}")]
        [HttpDelete]
        public async Task<Orders> DeleteOrder(int id)
        {
            return await _orderManage.DeleteOrder(id).ConfigureAwait(false);
        }
    }
}
