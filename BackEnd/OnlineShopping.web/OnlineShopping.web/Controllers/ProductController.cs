using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShopping.business.CustomerLogic;
using OnlineShopping.data.Entities;
using OnlineShopping.web.Models;

namespace OnlineShopping.web.Controllers
{
    
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private ProductManage pManage = new ProductManage();

        // Get all Product

        [Route("all")]
        [HttpGet]
        public async Task<List<ProductViewModel>> GetProducts()
        {
            List<ProductViewModel> productsList = new List<ProductViewModel>();
            var products = await pManage.GetProducts();

            if(products.Count > 0)
            {
                foreach (var product in products)
                {
                    ProductViewModel currentProduct = new ProductViewModel
                    {
                        ProductName = product.ProductName,
                        ProductDescription = product.ProductDescription,
                        CategoryId = product.CategoryId,
                        CurrentPrice = product.CurrentPrice
                    };
                    productsList.Add(currentProduct);
                }
            }
            return productsList;
        }

        // Get by ID

        [Route("id/{id}")]
        [HttpGet]
        public async Task<ProductViewModel> GetProductById(int id)
        {
            var product = await pManage.GetProductById(id);

            ProductViewModel currentProduct = new ProductViewModel
            {
                ProductName = product.ProductName,
                ProductDescription = product.ProductDescription,
                CategoryId = product.CategoryId,
                CurrentPrice = product.CurrentPrice
            };

            return currentProduct;

        }

        //Get by Name

        [Route("name/{name}")]
        [HttpGet]
        public async Task<List<ProductViewModel>> GetProductByName(string name)
        {
            List<ProductViewModel> productList = new List<ProductViewModel>();

            // System.Diagnostics.Debug.WriteLine(name);

            var products = await pManage.GetProductByName(name);

            if (products != null)
            {
                foreach (var product in products)
                {
                    ProductViewModel currentProduct = new ProductViewModel
                    {
                        ProductName = product.ProductName,
                        ProductDescription = product.ProductDescription,
                        CategoryId = product.CategoryId,
                        CurrentPrice = product.CurrentPrice
                    };
                    productList.Add(currentProduct);
                }
            }

            return productList;
        }

        // Create Product
        [Authorize]
        [Route("new")]
        [HttpPost]

        public async Task<Product> CreateProduct(Product product)
        {
           return await pManage.CreateProduct(product);
        }

        // Edit Product
        [Authorize]
        [Route("edit/{id}")]
        [HttpPut]
        public async Task<Product> EditProduct(int id, Product product)
        {
            return await pManage.EditProduct(id, product);
        }


        // Delete Product
        [Authorize]
        [Route("delete/{id}")]
        [HttpDelete]
        public async Task<Product> DeleteProduct(int id)
        {
            return await pManage.DeleteProduct(id);
        }

    }
}
