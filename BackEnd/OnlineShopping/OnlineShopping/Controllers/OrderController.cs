using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineShoppind.Business.DTOs;
using OnlineShoppind.Business.OrderServices;

namespace OnlineShopping.Controllers
{
    [Route("api/order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderServices _orderLogic;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public OrderController(IOrderServices orderServices, IMapper mapper, ILogger<OrderController> logger)
        {
            _orderLogic = orderServices;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<OrderDTO> GetOrders()
        {
            _logger.LogInformation("Start: Getting Orders details");
            IEnumerable<OrderDTO> order = new List<OrderDTO>();
            order = _orderLogic.GetOrders();

            _logger.LogInformation("Complete: Getting Orders details", order);
            return order;
        }

        [HttpGet]
        [Route("{id}")]
        public OrderDTO GetOrder(int id)
        {
            _logger.LogInformation("Start: Getting Order details");
            OrderDTO order = _orderLogic.GetOrderById(id);

            _logger.LogInformation("Start: Getting Order details", id, order);
            return order;
        }

        [HttpPost]
        public OrderDTO InsertOrder(OrderDTO order)
        {
            _logger.LogInformation("Start: Inserting Order details");
            OrderDTO orderDto = _orderLogic.InsertOrder(order);

            _logger.LogInformation("Complete: Insert Order details", orderDto);
            return orderDto;
        }

        [HttpDelete]
        [Route("{id}")]
        public void DeleteOrder(int id)
        {
            _logger.LogInformation("Start: Deleteing Order details");

            _orderLogic.RemoveOrder(id);

            _logger.LogInformation("Complete: Deleting Order details");
        }

    }
}
