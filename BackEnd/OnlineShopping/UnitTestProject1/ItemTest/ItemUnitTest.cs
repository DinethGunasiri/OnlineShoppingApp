using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OnlineShoppind.Business.DTOs;
using OnlineShoppind.Business.OrderItemServises;
using OnlineShoppind.Business.OrderServices;
using OnlineShopping.data.UnitOfWork;
using OnlineShopping.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace OnlineShopping.Test.ItemTest
{
    [TestClass]
    public class ItemUnitTest
    {
        private ItemServices itemServices;
        private Mock<IUnitOfWork> _unitOfWork;
        private Mock<IMapper> _mapper;
        private Mock<IConfiguration> _configuration;
        private Mock<IOrderServices> _orderService;

        [TestInitialize]
        public void Setup()
        {
            _mapper = new Mock<IMapper>();
            _unitOfWork = new Mock<IUnitOfWork>();
            _configuration = new Mock<IConfiguration>();
            _orderService = new Mock<IOrderServices>();

            itemServices = new ItemServices(_unitOfWork.Object, _mapper.Object, _configuration.Object, _orderService.Object);
        }

        [TestMethod]
        public void GetItemsLengthShopuldGreaterThanZero()
        {
            // Arrange

            var returnList = GetItemList();
            _unitOfWork.Setup(p => p.Items.GeItems()).Returns(returnList);

            // Act

            var result = itemServices.GetItems();

            // Assert

            Assert.AreEqual(3, result.Count());
        }

        [TestMethod]
        public void GetItemsReturnTypeShouldItemDto()
        {
            // Arrange

            var returnList = GetItemList();
            _unitOfWork.Setup(p => p.Items.GeItems()).Returns(returnList);

            // Act

            var result = itemServices.GetItems();

            // Assert

            Assert.AreEqual(typeof(List<ItemDTO>), result.GetType());
        }


        [TestMethod]
        public void GetItemByIdShouldReturnItemDetails()
        {
            // Arrange

            var returnList = GetItemList();

            _unitOfWork.Setup(i => i.Items.GetItemById(1)).Returns(returnList.Find(i => i.ItemId == 1));

            // Act

            var result = itemServices.GetItemById(1);

            // Assert

            Assert.AreEqual(1, result.ItemId);
            Assert.AreEqual(1, result.OrderId);
            Assert.AreEqual(2, result.ProductId);
            Assert.AreEqual(200, result.PurchasePrice);
            Assert.AreEqual(10, result.Quantity);
        }


        [TestMethod]
        public void InsertItemsShouldReturnItemsDetails()
        {
            // Arrange

            var returnList = GetItemList();

            OrderItems item = new OrderItems
            {
                ItemId = 4,
                OrderId = 1,
                ProductId = 3,
                PurchasePrice = 500,
                Quantity = 30
            };

            ItemDTO itemDto = new ItemDTO
            {
                ItemId = 4,
                OrderId = 1,
                ProductId = 3,
                PurchasePrice = 500,
                Quantity = 30
            };

            _unitOfWork.Setup(p => p.Items.InsertItems(item));
            _unitOfWork.Setup(p => p.Items.GeItems()).Returns(returnList);
            // Act

            var result = itemServices.InsertItem(itemDto);

            // Assert

            Assert.AreEqual(4, result.ItemId);
            Assert.AreEqual(1, result.OrderId);
            Assert.AreEqual(3, result.ProductId);
            Assert.AreEqual(500, result.PurchasePrice);
            Assert.AreEqual(30, result.Quantity);
        }

        [TestMethod]
        public void UpdateItemShouldReturnUpdatedData()
        {
            // Arrange

            var returnList = GetItemList();

            OrderItems item = new OrderItems
            {
                ItemId = 1,
                OrderId = 1,
                ProductId = 2,
                PurchasePrice = 200,
                Quantity = 50
            };

            ItemDTO itemDto = new ItemDTO
            {
                ItemId = 1,
                OrderId = 1,
                ProductId = 2,
                PurchasePrice = 200,
                Quantity = 50
            };

            _unitOfWork.Setup(p => p.Items.UpdateItems(item));
            _unitOfWork.Setup(p => p.Items.GetItemById(item.ItemId)).Returns(returnList.Find(p => p.ItemId == item.ItemId));

            // Act

            var result = itemServices.UpdateItem(itemDto.ItemId, itemDto);

            // Assert

            Assert.AreEqual(50, result.Quantity);
        }

        [TestMethod]
        public void DeleteItemsShouldSuccess()
        {
            // Arrange

            var returnList = GetItemList();

            OrderItems item = new OrderItems
            {
                ItemId = 1,
                OrderId = 1,
                ProductId = 2,
                PurchasePrice = 200,
                Quantity = 10
            };

            ItemDTO itemDto = new ItemDTO
            {
                ItemId = 1,
                OrderId = 1,
                ProductId = 2,
                PurchasePrice = 200,
                Quantity = 10
            };

            _unitOfWork.Setup(p => p.Items.RemoveItems(item.ItemId)).Verifiable();

            // Act

            itemServices.RemoveItem(itemDto.ItemId);

            // Assert

            Assert.IsTrue(true);
        }


        private List<OrderItems> GetItemList()
        {
            var _itemList = new List<OrderItems>()
            {
                new OrderItems
                {
                    ItemId = 1,
                    OrderId = 1,
                    ProductId = 2,
                    PurchasePrice = 200,
                    Quantity = 10
                },

                new OrderItems
                {
                    ItemId = 2,
                    OrderId = 1,
                    ProductId = 1,
                    PurchasePrice = 50.25,
                    Quantity = 5
                },

                new OrderItems
                {
                    ItemId = 3,
                    OrderId = 1,
                    ProductId = 3,
                    PurchasePrice = 700,
                    Quantity = 1
                }
            };
            return _itemList;
        }
    }
}
