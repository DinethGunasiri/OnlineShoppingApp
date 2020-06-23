using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShopping.business.OrderItemLogic;
using OnlineShopping.data.Entities;
using OnlineShopping.service.Models;

namespace OnlineShopping.service.Controllers
{
    [Route("api/items")]
    [ApiController]
    public class OrderItemController : ControllerBase
    {
        private OrderItemManage oManage = new OrderItemManage();

        // Get all OrderItems

        [Route("all")]
        [HttpGet]
        public async Task<List<OrderItemsModel>> OrderItems()
        {
            List<OrderItemsModel> itemList = new List<OrderItemsModel>();
            var items = await oManage.GetOrderItems();

            if(items.Count > 0)
            {
                foreach(var item in items)
                {
                    OrderItemsModel currentItems = new OrderItemsModel
                    {
                        ItemId = item.ItemId,
                        ProductId = item.ProductId,
                        PurchasePrice = item.PurchasePrice,
                        Quantity = item.Quantity
                    };
                    itemList.Add(currentItems);
                }
            }
            return itemList;
        }

        // Get Order Item by Id
        [Route("id/{id}")]
        [HttpGet]
        public async Task<OrderItemsModel> GetOrderItem(int id)
        {
            var orderItem = await oManage.GetOrderItme(id);

            OrderItemsModel currentItems = new OrderItemsModel
            {
                ItemId = orderItem.ItemId,
                ProductId = orderItem.ProductId,
                PurchasePrice = orderItem.PurchasePrice,
                Quantity = orderItem.Quantity
            };

            return currentItems;
        }

        // Create new Order Itme
        [Route("new")]
        [HttpPost]
        public async Task<OrderItems> CreateOrderItem(OrderItems items)
        {
            return await oManage.CreateOrderItems(items);
        }

        // Edit Order Item
        [Route("edit/{id}")]
        [HttpPut]
        public async Task<OrderItems> EditItems(int id, OrderItems items)
        {
            return await oManage.EditOrderItems(id, items);
        }

        // Delete Order Item
        [Route("delete/{id}")]
        [HttpDelete]
        public async Task<OrderItems> DeleteItems(int id)
        {
            return await oManage.DeleteOrderItems(id);
        }
    }
}
