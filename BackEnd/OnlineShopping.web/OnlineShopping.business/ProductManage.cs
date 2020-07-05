using OnlineShopping.data.DataContext;
using OnlineShopping.data.Entities;
using OnlineShopping.data.Interfacses;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;

namespace OnlineShopping.business.CustomerLogic
{
    public class ProductManage
    {
        readonly IProduct _productDataAccess;

        public ProductManage()
        {
            _productDataAccess = ProductAccessFactory.GetProductDataAccessObj();
        }


        // Get All Products
        public async Task<List<Product>> GetProducts()
        {
            List<Product> products = await _productDataAccess.GetProducts().ConfigureAwait(false);

            return products;              
        }

        // Get Product by Id
        public async Task<Product> GetProductById(int id)
        {
            
            var product = await _productDataAccess.GetPrductByID(id).ConfigureAwait(false);
            
            return product;
               
        }

        // Get Product by name
        public async Task<List<Product>> GetProductByName(string name)
        {
            
            List<Product> product = await _productDataAccess.GetProductByName(name).ConfigureAwait(false);

            return product;
        }

        // Get Product by Category
        public async Task<List<Product>> GetProductByCategory(int id)
        {
            
            List<Product> products = await _productDataAccess.GetProductsByCategory(id).ConfigureAwait(false);

            return products;

        }

        // Create Product
        public async Task<Product> CreateProduct(Product product)
        {

            var productDetails = await _productDataAccess.AddProduct(product).ConfigureAwait(false);
            // System.Diagnostics.Debug.WriteLine(productDetails);

            return productDetails;
        }

        // Edit Product
        public async Task<Product> EditProduct(int id, Product product)
        {
            
            var productDetails = await _productDataAccess.EditProduct(id, product).ConfigureAwait(false);

            return productDetails;
        }

        // Delete Product
        public async Task<Product> DeleteProduct(int id)
        {
            
            var product = await _productDataAccess.DeleteProduct(id).ConfigureAwait(false);

            return product;
        }
    }
}
