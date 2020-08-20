using AutoMapper;
using OnlineShoppind.Business.DTOs;
using OnlineShopping.data.UnitOfWork;
using OnlineShopping.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

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

        // Get product by id
        public ProductDTO GetProductById(int id)
        {
            var productDetails = _unitOfWork.Product.GetProductById(id);


            if (productDetails != null)
            {
                ProductDTO product = new ProductDTO
                {
                    CategoryId = productDetails.CategoryId,
                    CurrentPrice = productDetails.CurrentPrice,
                    Discount = productDetails.Discount,
                    ProductDescription = productDetails.ProductDescription,
                    ProductId = productDetails.ProductId,
                    ProductName = productDetails.ProductName
                };

                return product;
            }
            else
            {
                return null;
            }

           
        }

        // Get all products
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

        // Create new product
        public ProductDTO InsertProduct(ProductDTO products)
        {
            var product = _mapper.Map<Product>(products);

            _unitOfWork.Product.Add(product);
            _unitOfWork.SaveChanges();
            return products;
        }

        // Delete product by id
        public void RemoveProduct(int id)
        {
            _unitOfWork.Product.RemoveProduct(id);
            _unitOfWork.SaveChanges();
        }

        // Edit product details
        public ProductDTO UpdateProduct(int id, ProductDTO newproduct)
        {
            if (newproduct == null)
            {
                throw new ArgumentNullException($"{newproduct} is null");
            }

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
