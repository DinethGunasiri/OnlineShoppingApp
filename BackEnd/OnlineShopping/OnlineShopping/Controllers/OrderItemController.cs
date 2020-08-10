using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineShoppind.Business.DTOs;
using OnlineShoppind.Business.OrderItemServises;

namespace OnlineShopping.Controllers
{
    [Route("api/items")]
    [ApiController]
    public class OrderItemController : ControllerBase
    {
        private readonly IItemServices _itemLogc;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public OrderItemController(IItemServices itemServices, IMapper mapper, ILogger<OrderItemController> logger)
        {
            _itemLogc = itemServices;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<ItemDTO> GetItems()
        {
            _logger.LogInformation("Start: Getting OrderItems");

            IEnumerable<ItemDTO> items = new List<ItemDTO>();

            items = _itemLogc.GetItems();

            _logger.LogInformation("Complete: Getting OrderItems", items);

            return items;
        }

        [HttpGet]
        [Route("{id}")]
        public ItemDTO GetItem(int id)
        {
            _logger.LogInformation("Start: Getting OrderItem");

            ItemDTO item = _itemLogc.GetItemById(id);

            _logger.LogInformation("Complete: Getting OrderItem", id, item);

            return item;
        }

        [HttpPost]
        public ItemDTO InsertItem(ItemDTO item)
        {
            _logger.LogInformation("Start: Inserting OrderItem");

            ItemDTO itemDto = _itemLogc.InsertItem(item);

            _logger.LogInformation("Complete: Insert rderItems", itemDto);

            return itemDto;
        }

        [HttpPut]
        [Route("{id}")]
        public ItemDTO UpdateItem(int id, ItemDTO item)
        {
            _logger.LogInformation("Start: Updating OrderItem");

            ItemDTO itemDto = _itemLogc.UpdateItem(id, item);

            _logger.LogInformation("Complete: Updated OrderItems",id, itemDto);

            return itemDto;
        }

        [HttpDelete]
        [Route("{id}")]
        public void RemoveItem(int id)
        {
            _logger.LogInformation("Start: Deleting OrderItem");

            _itemLogc.RemoveItem(id);

            _logger.LogInformation("Complete: Delete OrderItem", id);
        }

    }
}
