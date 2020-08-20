using AutoMapper;
using OnlineShoppind.Business.DTOs;
using OnlineShopping.data.UnitOfWork;
using OnlineShopping.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShoppind.Business.OrderServices
{
    public class OrderServicesLogic : IOrderServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OrderServicesLogic(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // Get order by id
        public OrderDTO GetOrderById(int id)
        {
            var orderDetails = _unitOfWork.Order.GetOrderById(id);


             if (orderDetails != null)
            {
                OrderDTO order = new OrderDTO
                {
                    OrderId = orderDetails.OrderId,
                    CustomerId = orderDetails.CustomerId,
                    ShippingAddress = orderDetails.ShippingAddress,
                    OrderDate = orderDetails.OrderDate,
                    TotalPrice = orderDetails.TotalPrice,
                    PaymentType = orderDetails.PaymentType
                };

                return order;
            }
            else
            {
                return null;
            }
          
        }

        // Get all orders
        public IEnumerable<OrderDTO> GetOrders()
        {
            var orderDetails = _unitOfWork.Order.GetOrders().ToList();
            List<OrderDTO> orderList = new List<OrderDTO>();

            foreach (var order in orderDetails)
            {
                OrderDTO orders = new OrderDTO
                {
                    CustomerId = order.CustomerId,
                    OrderDate = order.OrderDate,
                    OrderId = order.OrderId,
                    ShippingAddress = order.ShippingAddress,
                    TotalPrice = order.TotalPrice,
                    PaymentType = order.PaymentType
                };
                orderList.Add(orders);
            }
            return orderList;
        }

        // Insert order to database
        public OrderDTO InsertOrder(OrderDTO order)
        {
            var orders = _mapper.Map<Orders>(order);
            var InsertOrder = _unitOfWork.Order.InsertOrder(orders);

            _unitOfWork.SaveChanges();

            var orderDto = _mapper.Map<OrderDTO>(InsertOrder);

            return orderDto;

            
            // return order;
        }

        // Delete order from database
        public void RemoveOrder(int id)
        {
            _unitOfWork.Order.RemoveOrder(id);

            _unitOfWork.SaveChanges();
        }
    }
}
