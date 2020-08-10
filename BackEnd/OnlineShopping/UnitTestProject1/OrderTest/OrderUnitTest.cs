using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OnlineShoppind.Business.DTOs;
using OnlineShoppind.Business.OrderServices;
using OnlineShopping.data.UnitOfWork;
using OnlineShopping.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShopping.Test.OrderTest
{
    [TestClass]
    public class OrderUnitTest
    {

        private OrderServices _orderServises;
        private Mock<IUnitOfWork> _unitOfWork;
        private Mock<IMapper> _mapper;

        public OrderUnitTest()
        {
            _mapper = new Mock<IMapper>();
            _unitOfWork = new Mock<IUnitOfWork>();

            _orderServises = new OrderServices(_unitOfWork.Object, _mapper.Object);
        }


        [TestMethod]
        public void GetOrdersLengthShopuldGreaterThanZero()
        {
            // Arrange

            var returnList = GetOrderList();
            _unitOfWork.Setup(p => p.Order.GetOrders()).Returns(returnList);

            // Act

            var result = _orderServises.GetOrders();

            // Assert

            Assert.AreEqual(3, result.Count());
        }

        [TestMethod]
        public void GetOrdersReturnTypeShouldOrderDto()
        {
            // Arrange

            var returnList = GetOrderList();
            _unitOfWork.Setup(p => p.Order.GetOrders()).Returns(returnList);

            // Act

            var result = _orderServises.GetOrders();

            // Assert

            Assert.AreEqual(typeof(List<OrderDTO>), result.GetType());
        }


        [TestMethod]
        public void GetOrderByIdShouldReturnOrderDetails()
        {
            // Arrange 

            var returnList = GetOrderList();

            _unitOfWork.Setup(x => x.Order.GetOrderById(1)).Returns(returnList.Find(e => e.OrderId == 1));

            // Act

            var result = _orderServises.GetOrderById(1);

            // Assert
            Assert.AreEqual(1, result.OrderId);
            Assert.AreEqual("dineth@gmail.com", result.CustomerId);
            Assert.AreEqual("549/2A Mihindu Mawatha, Malwaththa", result.ShippingAddress);
            Assert.AreEqual(DateTime.Today, result.OrderDate);
        }



        [TestMethod]
        public void InsertOrderShouldReturnOrderDetails()
        {
            // Arrange

            var returnList = GetOrderList();

            Orders order = new Orders
            {
                OrderId = 4,
                CustomerId = "mike@gmail.com",
                ShippingAddress = "Ohayo, America",
                OrderDate = DateTime.Today
            };

            OrderDTO orderDto = new OrderDTO
            {
                OrderId = 4,
                CustomerId = "mike@gmail.com",
                ShippingAddress = "Ohayo, America",
                OrderDate = DateTime.Today
            };

            _unitOfWork.Setup(p => p.Order.InsertOrder(order));
            _unitOfWork.Setup(p => p.Order.GetOrders()).Returns(returnList);
            // Act

            var result = _orderServises.InsertOrder(orderDto);

            // Assert

            Assert.AreEqual(4, result.OrderId);
            Assert.AreEqual("mike@gmail.com", result.CustomerId);
            Assert.AreEqual("Ohayo, America", result.ShippingAddress);
            Assert.AreEqual(DateTime.Today, result.OrderDate);

        }

       
        [TestMethod]
        public void DeleteOrderShouldSuccess()
        {
            // Arrange

            var returnList = GetOrderList();

            Orders order = new Orders
            {

                OrderId = 4,
                CustomerId = "mike@gmail.com",
                ShippingAddress = "Ohayo, America",
                OrderDate = DateTime.Today
            };

            _unitOfWork.Setup(p => p.Order.RemoveOrder(order.OrderId)).Verifiable();

            // Act

            _orderServises.RemoveOrder(order.OrderId);

            // Assert

            Assert.IsTrue(true);
        }


        private List<Orders> GetOrderList()
        {
            var _orderList = new List<Orders>()
            {
                new Orders
                {
                    OrderId = 1,
                    CustomerId = "dineth@gmail.com",
                    ShippingAddress = "549/2A Mihindu Mawatha, Malwaththa",
                    OrderDate = DateTime.Today
                },

                 new Orders
                {
                    OrderId = 2,
                    CustomerId = "sam@gmail.com",
                    ShippingAddress = "Ohoyo, America",
                    OrderDate = DateTime.Today
                },

                  new Orders
                {
                    OrderId = 3,
                    CustomerId = "hirun@gmail.com",
                    ShippingAddress = "549/2A Mihindu Mawatha, Malwaththa",
                    OrderDate = DateTime.Today
                },

            };
            return _orderList;
        }

    }
}
