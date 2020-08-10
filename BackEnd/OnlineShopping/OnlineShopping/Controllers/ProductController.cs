using System.Collections.Generic;
using AutoMapper;
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
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public ProductController(IProductService productService, IMapper mapper, ILogger<ProductController> logger)
        {
            _productLogic = productService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<ProductDTO> GetProducts()
        {
            _logger.LogInformation("Start : Getting product details");
            IEnumerable<ProductDTO> products = new List<ProductDTO>();
            products = _productLogic.GetProducts();

            _logger.LogInformation("Completed : Products", products);
            return products;
        }

        [HttpGet]
        [Route("{id}")]
        public ProductDTO GetProduct(int id)
        {
            _logger.LogInformation("Start: Getting product details according to ProductId");
            ProductDTO product = _productLogic.GetProductById(id);

            _logger.LogInformation("Complete: Product", product);
            return product;
        }

        [Authorize]
        [HttpPost]
        public ProductDTO InsertProduct(ProductDTO product)
        {
            _logger.LogInformation("Start: Inserting product to database");
            ProductDTO productDto = _productLogic.InsertProduct(product);

            _logger.LogInformation("Complete: Product has insert to datdabase", productDto);
            return productDto;
        }

        [Authorize]
        [HttpPut]
        [Route("{id}")]
        public ProductDTO UpdateProduct(int id, ProductDTO product)
        {
            _logger.LogInformation("Start: Update product in database");
            ProductDTO productDTO = _productLogic.UpdateProduct(id, product);

            _logger.LogInformation("Complete: Product has updated", id, productDTO);
            return productDTO;
        }

        [Authorize]
        [HttpDelete]
        [Route("{id}")]
        public void RemoveOrder(int id)
        {
            _logger.LogInformation("Start: Removing order from database");

            _productLogic.RemoveProduct(id);

            _logger.LogInformation("Complete: Remove order from database", id);
        }

    }
}
