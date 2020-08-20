using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineShoppind.Business.DTOs;
using OnlineShoppind.Business.OrderItemServises;

namespace OnlineShopping.Controllers
{
    [Authorize]
    [Route("api/items")]
    [ApiController]
    public class OrderItemController : ControllerBase
    {
        private readonly IItemServices _itemLogc;
        private readonly ILogger _logger;

        public OrderItemController(IItemServices itemServices, ILogger<OrderItemController> logger)
        {
            _itemLogc = itemServices;
            _logger = logger;
        }

        // Get all Product items
        [HttpGet]
        public IEnumerable<ItemDTO> GetItems()
        {
            IEnumerable<ItemDTO> items = new List<ItemDTO>();

            _logger.LogInformation($"Start: Getting OrderItems {items}");

            items = _itemLogc.GetItems();

            if (items == null)
            {
                _logger.LogInformation($"somthing went wrong in getting all items {items}");
                throw new ArgumentException($"Cannot get all items {items}");

            }

            _logger.LogInformation($"Complete: Getting OrderItems {items}");

            return items;
        }


        // Get product items by id
        [HttpGet]
        [Route("{id}")]
        public ItemDTO GetItem(int id)
        {
            
            ItemDTO item = _itemLogc.GetItemById(id);

            _logger.LogInformation($"Start: Getting OrderItem {item}");

            if (item == null)
            {
                _logger.LogInformation($"Somthing went wrong GetItem {id}");
                 throw new ArgumentException($"Cannot get item by item id : {id}", nameof(id));
            }

            _logger.LogInformation($"Complete: Getting OrderItem {id}, {item}");

            return item;
        }

        // Save product items 
        [HttpPost]
        public ItemDTO InsertItem(ItemDTO item)
        {
            _logger.LogInformation($"Start: Inserting OrderItem {item}");

            ItemDTO itemDto = _itemLogc.InsertItem(item);


            _logger.LogInformation($"Complete: Insert rderItems {itemDto}", itemDto);

            return itemDto;
        }

        // Edit product items
        [HttpPut]
        [Route("{id}")]
        public ItemDTO UpdateItem(int id, ItemDTO item)
        {
            _logger.LogInformation($"Start: Updating OrderItem {id}, {item}");

            ItemDTO itemDto = _itemLogc.UpdateItem(id, item);

            _logger.LogInformation($"Complete: Updated OrderItems {id}, {itemDto}");

            return itemDto;
        }

        // Delete product items
        [HttpDelete]
        [Route("{id}")]
        public void RemoveItem(int id)
        {
            _logger.LogInformation($"Start: Deleting OrderItem {id}");

            _itemLogc.RemoveItem(id);

            _logger.LogInformation($"Complete: Delete OrderItem {id}");
        }

        // Send recipt as email
        [HttpGet]
        [Route("email/{product}")]
        public void SendEmail(int product)
        {
            _itemLogc.SendEmailAsync(product);
        }
    }
}
