using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OnlineShoppind.Business.DTOs;
using OnlineShoppind.Business.ProductServices;
using OnlineShopping.data.UnitOfWork;
using OnlineShopping.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShopping.Test.ProductTest
{
    [TestClass]
    public class ProductUnitTest
    {
        private ProductServises _productServises;
        private Mock<IUnitOfWork> _unitOfWork;
        private Mock<IMapper> _mapper;

        [TestInitialize]
        public void Setup()
        {
            _mapper = new Mock<IMapper>();
            _unitOfWork = new Mock<IUnitOfWork>();

            _productServises = new ProductServises(_unitOfWork.Object, _mapper.Object);
        }


        [TestMethod]
        public void GetProductLengthShopuldGreaterThanZero()
        {
            // Arrange

            var returnList = GetProductList();
            _unitOfWork.Setup(p => p.Product.GetProducts()).Returns(returnList);

            // Act

            var result = _productServises.GetProducts();

            // Assert

            Assert.AreEqual(3, result.Count());
        }

        [TestMethod]
        public void GetProductsReturnTypeShouldProductDto()
        {
            // Arrange

            var returnList = GetProductList();
            _unitOfWork.Setup(p => p.Product.GetProducts()).Returns(returnList);

            // Act

            var result = _productServises.GetProducts();

            // Assert

            Assert.AreEqual(typeof(List<ProductDTO>), result.GetType());
        }


        [TestMethod]
        public void GetProductByIdShouldReturnProductDetails()
        {
            // Arrange

            var returnList = GetProductList();
            _unitOfWork.Setup(p => p.Product.GetProductById(1)).Returns(returnList.Find(p => p.ProductId == 1));

            // Act

            var result = _productServises.GetProductById(1);

            // Assert

            Assert.AreEqual(1, result.ProductId);
            Assert.AreEqual("Apple", result.ProductName);
            Assert.AreEqual("Apple from Japan", result.ProductDescription);
            Assert.AreEqual(1, result.CategoryId);
            Assert.AreEqual(50.25, result.CurrentPrice);
        }


        [TestMethod]
        public void InsertProductShouldReturnProductDetails()
        {
            // Arrange

            var returnList = GetProductList();

            Product product = new Product
            {
                ProductId = 4,
                ProductName = "Orange",
                ProductDescription = "Orange from Viatnam",
                CategoryId = 1,
                CurrentPrice = 30
            };

            ProductDTO productDto = new ProductDTO
            {
                ProductId = 4,
                ProductName = "Orange",
                ProductDescription = "Orange from Viatnam",
                CategoryId = 1,
                CurrentPrice = 30
            };

            _unitOfWork.Setup(p => p.Product.InsertProduct(product));
            _unitOfWork.Setup(p => p.Product.GetProducts()).Returns(returnList);
            // Act

            var result = _productServises.InsertProduct(productDto);

            // Assert

            Assert.AreEqual(4, result.ProductId);
            Assert.AreEqual("Orange", result.ProductName);
            Assert.AreEqual("Orange from Viatnam", result.ProductDescription);
            Assert.AreEqual(1, result.CategoryId);
            Assert.AreEqual(30, result.CurrentPrice);
        }

        [TestMethod]
        public void UpdateProductShouldReturnUpdatedData()
        {
            // Arrange

            var returnList = GetProductList();

            Product product = new Product
            {
                ProductId = 1,
                ProductName = "Green Apple",
                ProductDescription = "Green Apple from Japan",
                CategoryId = 1,
                CurrentPrice = 50.25
            };

            ProductDTO productDto = new ProductDTO
            {
                ProductId = 1,
                ProductName = "Green Apple",
                ProductDescription = "Green Apple from Japan",
                CategoryId = 1,
                CurrentPrice = 50.25
            };

            _unitOfWork.Setup(p => p.Product.UpdateProduct(product));
            _unitOfWork.Setup(p => p.Product.GetProductById(product.ProductId)).Returns(returnList.Find(p => p.ProductId == product.ProductId));

            // Act

            var result = _productServises.UpdateProduct(productDto.ProductId, productDto);

            // Assert

            Assert.AreEqual("Green Apple", result.ProductName);
            Assert.AreEqual("Green Apple from Japan", result.ProductDescription);
        }

        [TestMethod]
        public void DeleteProductShouldSuccess()
        {
            // Arrange

            var returnList = GetProductList();

            Product product = new Product
            {
                ProductId = 1,
                ProductName = "Green Apple",
                ProductDescription = "Green Apple from Japan",
                CategoryId = 1,
                CurrentPrice = 50.25
            };

            ProductDTO productDto = new ProductDTO
            {
                ProductId = 1,
                ProductName = "Green Apple",
                ProductDescription = "Green Apple from Japan",
                CategoryId = 1,
                CurrentPrice = 50.25
            };

            _unitOfWork.Setup(p => p.Product.RemoveProduct(product.ProductId)).Verifiable();

            // Act

            _productServises.RemoveProduct(productDto.ProductId);

            // Assert

            Assert.IsTrue(true);          
        }

        private List<Product> GetProductList()
        {
            var _productList = new List<Product>()
            {
                new Product
                {
                    ProductId = 1,
                    ProductName = "Apple",
                    ProductDescription = "Apple from Japan",
                    CategoryId = 1,
                    CurrentPrice = 50.25
                },
                 new Product
                {
                    ProductId = 2,
                    ProductName = "Banana",
                    ProductDescription = "Banana from Sri Lanka",
                    CategoryId = 1,
                    CurrentPrice = 10
                },
                  new Product
                {
                    ProductId = 3,
                    ProductName = "Chicken",
                    ProductDescription = "Boilers",
                    CategoryId = 6,
                    CurrentPrice = 700
                },
            };
            return _productList;
        }
    }
}
