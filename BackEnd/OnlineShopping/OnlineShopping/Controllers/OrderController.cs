using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineShoppind.Business.DTOs;
using OnlineShoppind.Business.OrderServices;

namespace OnlineShopping.Controllers
{
    [Authorize]
    [Route("api/order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderServices _orderLogic;
        private readonly ILogger _logger;

        public OrderController(IOrderServices orderServices, ILogger<OrderController> logger)
        {
            _orderLogic = orderServices;
            _logger = logger;
        }

        // Get orders
        [HttpGet]
        public IEnumerable<OrderDTO> GetOrders()
        {
            IEnumerable<OrderDTO> order = new List<OrderDTO>();

            _logger.LogInformation($"Start: Getting Orders details {order}");

            order = _orderLogic.GetOrders();

            if (order == null)
            {
                _logger.LogInformation($"Error in GetOrders {order}");
                throw new ArgumentException($"Error occur in getting all orders {order}");
            }

            _logger.LogInformation($"Complete: Getting Orders details {order}");
            return order;
        }

        // Get order by id
        [HttpGet]
        [Route("{id}")]
        public OrderDTO GetOrder(int id)
        {
            _logger.LogInformation($"Start: Getting Order details {id}");
            OrderDTO order = _orderLogic.GetOrderById(id);

            if (order == null)
            {
                _logger.LogInformation($"Cannot get order by id : {id}");
                throw new ArgumentException($"Error occur in getting order by id : {id}", nameof(id));
            }

            _logger.LogInformation($"Start: Getting Order details {id}, {order}");
            return order;
        }

        // Save order
        [HttpPost]
        public OrderDTO InsertOrder(OrderDTO order)
        {
            _logger.LogInformation($"Start: Inserting Order details {order}");

            OrderDTO orderDto = _orderLogic.InsertOrder(order);

            _logger.LogInformation($"Complete: Insert Order details {orderDto}");

            return orderDto;

            
        }

        // Delete order
        [HttpDelete]
        [Route("{id}")]
        public void DeleteOrder(int id)
        {
            _logger.LogInformation($"Start: Deleteing Order details {id}");

            _orderLogic.RemoveOrder(id);

            _logger.LogInformation($"Complete: Deleting Order details {id}");
        }
    }
}
