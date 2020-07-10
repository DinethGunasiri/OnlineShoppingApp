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
        private ProductManage _productManage; // = new ProductManage();

        public ProductController()
        {
            _productManage = new ProductManage();
        }

        // Get all Product

        [HttpGet]
        public async Task<List<ProductViewModel>> GetProducts()
        {
            List<ProductViewModel> productsList = new List<ProductViewModel>();
            var products = await _productManage.GetProducts().ConfigureAwait(false);

            if(products.Count > 0)
            {
                foreach (var product in products)
                {
                    ProductViewModel currentProduct = new ProductViewModel
                    {
                        ProductId = product.ProductId,
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
            var product = await _productManage.GetProductById(id).ConfigureAwait(false);

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

        [Route("{name}")]
        [HttpGet]
        public async Task<List<ProductViewModel>> GetProductByName(string name)
        {
            List<ProductViewModel> productList = new List<ProductViewModel>();

            // System.Diagnostics.Debug.WriteLine(name);

            var products = await _productManage.GetProductByName(name).ConfigureAwait(false);

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
        [HttpPost]

        public async Task<Product> CreateProduct(Product product)
        {
           return await _productManage.CreateProduct(product).ConfigureAwait(false);
        }

        // Edit Product
        [Authorize]
        [Route("{id}")]
        [HttpPut]
        public async Task<Product> EditProduct(int id, Product product)
        {
            return await _productManage.EditProduct(id, product).ConfigureAwait(false);
        }


        // Delete Product
        [Authorize]
        [Route("{id}")]
        [HttpDelete]
        public async Task<Product> DeleteProduct(int id)
        {
            return await _productManage.DeleteProduct(id).ConfigureAwait(false);
        }

    }
}
