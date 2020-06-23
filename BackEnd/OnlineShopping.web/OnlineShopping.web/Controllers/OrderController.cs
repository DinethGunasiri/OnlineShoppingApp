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
        private OrderManage oManage = new OrderManage();

        [Route("all")]
        [HttpGet]
        public async Task<List<OrderViewModel>> GetOrders()
        {
            List<OrderViewModel> orderList = new List<OrderViewModel>();
            var orders = await oManage.GetOrders();

            if(orders.Count > 0)
            {
                foreach(var order in orders)
                {
                    OrderViewModel currentOrder = new OrderViewModel
                    {
                        OrderId = order.OrderId,
                        CustomerId = order.CustomerId,
                        OrderDate = order.OrderDate,
                        OrderItemsId = order.OrderItemsId,
                        ShippingAddress = order.ShippingAddress
                    };
                    orderList.Add(currentOrder);
                }
            }
            return orderList;
        }

        [Route("id/{id}")]
        [HttpGet]
        public async Task<OrderViewModel> GetOrder(int id)
        {
            var order = await oManage.GetOrder(id);

            OrderViewModel currentOrder = new OrderViewModel
            {
                OrderId = order.OrderId,
                CustomerId = order.CustomerId,
                OrderDate = order.OrderDate,
                OrderItemsId = order.OrderItemsId,
                ShippingAddress = order.ShippingAddress
            };
            return currentOrder;
        }

        [Route("new")]
        [HttpPost]
        public async Task<Orders> CreateOrder(Orders orders)
        {
            return await oManage.CreateOrder(orders);
        }

        [Route("delete/{id}")]
        [HttpDelete]
        public async Task<Orders> DeleteOrder(int id)
        {
            return await oManage.DeleteOrder(id);
        }
    }
}
