using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineShoppind.Business.DTOs;
using OnlineShoppind.Business.ProductServices;

namespace OnlineShopping.Controllers
{
    
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productLogic;
        private readonly ILogger _logger;

        public ProductController(IProductService productService, ILogger<ProductController> logger)
        {
            _productLogic = productService;
            _logger = logger;
        }


        // Get all products
        [HttpGet]
        public IEnumerable<ProductDTO> GetProducts()
        {
            
            IEnumerable<ProductDTO> products = new List<ProductDTO>();
            
            _logger.LogInformation($"Start : Getting product details {products}");

            products = _productLogic.GetProducts();

            if (products == null)
            {

            }

            _logger.LogInformation($"Completed : Products {products}");
            return products;
        }

        // Get product by id
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetProduct(int id)
        {
            _logger.LogInformation($"Start: Getting product details according to ProductId {id}");
            ProductDTO product = _productLogic.GetProductById(id);

            if (product == null)
            {
                _logger.LogInformation($"Somthing went wrong in GetProduct {id}");
                throw new ArgumentException($"Cannot get product by id {id}", nameof(id));
            }

            _logger.LogInformation($"Complete: Product {product}");
            return Ok(product);
        }

        // Save product to database
        [Authorize]
        [HttpPost]
        public ProductDTO InsertProduct(ProductDTO product)
        {
            _logger.LogInformation($"Start: Inserting product to database {product}");
            ProductDTO productDto = _productLogic.InsertProduct(product);

            _logger.LogInformation($"Complete: Product has insert to datdabase {productDto}");
            return productDto;
        }

        // Edit product
        [Authorize]
        [HttpPut]
        [Route("{id}")]
        public ProductDTO UpdateProduct(int id, ProductDTO product)
        {
            _logger.LogInformation($"Start: Update product in database {id}, {product}");
            ProductDTO productDTO = _productLogic.UpdateProduct(id, product);

            _logger.LogInformation($"Complete: Product has updated {id}, {productDTO}");
            return productDTO;
        }

        // Delete product
        [Authorize]
        [HttpDelete]
        [Route("{id}")]
        public void RemoveOrder(int id)
        {
            _logger.LogInformation($"Start: Removing order from database {id}");

            _productLogic.RemoveProduct(id);

            _logger.LogInformation($"Complete: Remove order from database {id}");
        }

    }
}
