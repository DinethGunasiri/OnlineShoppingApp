using AutoMapper;
using OnlineShoppind.Business.DTOs;
using OnlineShopping.data.UnitOfWork;
using OnlineShopping.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShoppind.Business.ProductServices
{
    public class ProductServises : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductServises(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public ProductDTO GetProductById(int id)
        {
            var productDetails = _unitOfWork.Product.GetProductById(id);

            ProductDTO product = new ProductDTO
            {
                CategoryId = productDetails.CategoryId,
                CurrentPrice = productDetails.CurrentPrice,
                ProductDescription = productDetails.ProductDescription,
                ProductId = productDetails.ProductId,
                Discount = productDetails.Discount,
                ProductName = productDetails.ProductName
            };

            return product ;
        }

        public IEnumerable<ProductDTO> GetProducts()
        {
            List<ProductDTO> productList = new List<ProductDTO>();
            var products = _unitOfWork.Product.GetProducts().ToList();

            foreach (var product in products)
            {
                ProductDTO productDto = new ProductDTO
                {
                 CategoryId = product.CategoryId,
                 CurrentPrice = product.CurrentPrice,
                 ProductDescription = product.ProductDescription,
                 ProductId = product.ProductId,
                 Discount = product.Discount,
                 ProductName = product.ProductName
                };
                productList.Add(productDto);
            }
            return productList;
        }

        public ProductDTO InsertProduct(ProductDTO products)
        {
            var product = _mapper.Map<Product>(products);

            _unitOfWork.Product.Add(product);
            _unitOfWork.SaveChanges();
            return products;
        }

        public void RemoveProduct(int id)
        {
            _unitOfWork.Product.RemoveProduct(id);
            _unitOfWork.SaveChanges();
        }

        public ProductDTO UpdateProduct(int id, ProductDTO newproduct)
        {
            var product = _unitOfWork.Product.GetProductById(id);

            product.CategoryId = newproduct.CategoryId;
            product.CurrentPrice = newproduct.CurrentPrice;
            product.ProductDescription = newproduct.ProductDescription;
            product.ProductName = newproduct.ProductName;
            product.Discount = newproduct.Discount;

            _unitOfWork.Product.UpdateProduct(product);
            _unitOfWork.SaveChanges();

            return newproduct;
        }
    }
}
