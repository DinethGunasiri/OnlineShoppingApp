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
        private OrderItemManage _itemManage; // = new OrderItemManage();

        public OrderItemController()
        {
            _itemManage = new OrderItemManage();
        }

        // Get all OrderItems

       
        [HttpGet]
        public async Task<List<OrderItemsModel>> OrderItems()
        {
            List<OrderItemsModel> itemList = new List<OrderItemsModel>();
            var items = await _itemManage.GetOrderItems().ConfigureAwait(false);

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
        [Route("{id}")]
        [HttpGet]
        public async Task<OrderItemsModel> GetOrderItem(int id)
        {
            var orderItem = await _itemManage.GetOrderItme(id).ConfigureAwait(false);

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
        [HttpPost]
        public async Task<OrderItems> CreateOrderItem(OrderItems items)
        {
            return await _itemManage.CreateOrderItems(items).ConfigureAwait(false);
        }

        // Edit Order Item
        [Route("{id}")]
        [HttpPut]
        public async Task<OrderItems> EditItems(int id, OrderItems items)
        {
            return await _itemManage.EditOrderItems(id, items).ConfigureAwait(false);
        }

        // Delete Order Item
        [Route("{id}")]
        [HttpDelete]
        public async Task<OrderItems> DeleteItems(int id)
        {
            return await _itemManage.DeleteOrderItems(id).ConfigureAwait(false);
        }
    }
}
