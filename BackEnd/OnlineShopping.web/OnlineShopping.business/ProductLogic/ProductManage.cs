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
        private IProduct _product = new data.Functions.ProductFunction();

        // Get All Products
        public async Task<List<Product>> GetProducts()
        {
            try
            {
                List<Product> products = await _product.GetProducts();

                if(products == null)
                {
                    throw new HttpResponseException(HttpStatusCode.BadRequest);
                }
                else
                {
                    return products;
                }
            }
            catch(Exception ex)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }                      
        }

        // Get Product by Id
        public async Task<Product> GetProductById(int id)
        {
            try
            {
                var product = await _product.GetPrductByID(id);

                if (product == null)
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }
                else
                {
                    return product;
                }
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        // Get Product by name
        public async Task<List<Product>> GetProductByName(string name)
        {
            try
            {
                List<Product> product = await _product.GetProductByName(name);

                if(product == null)
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }
                else
                {
                    return product;
                }
            }
            catch(Exception ex)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        // Get Product by Category
        public async Task<List<Product>> GetProductByCategory(int id)
        {
            try
            {
                List<Product> products = await _product.GetProductsByCategory(id);

                if(products == null)
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }
                else
                {
                    return products;
                }
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

        }

        // Create Product
        public async Task<Product> CreateProduct(Product product)
        {

            try
            {
                var productDetails = await _product.AddProduct(product);
               // System.Diagnostics.Debug.WriteLine(productDetails);

                if (productDetails == null)
                {
                    throw new HttpResponseException(HttpStatusCode.BadRequest);
                }
                else
                {
                    return productDetails;
                }
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
        }

        // Edit Product
        public async Task<Product> EditProduct(int id, Product product)
        {
            try
            {
                var productDetails = await _product.EditProduct(id, product);

                if(productDetails == null)
                {
                    throw new HttpResponseException(HttpStatusCode.BadRequest);
                }
                else
                {
                    return productDetails;
                }
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
        }

        // Delete Product
        public async Task<Product> DeleteProduct(int id)
        {
            try
            {
                var product = await _product.DeleteProduct(id);

                if(product == null)
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }
                else
                {
                    return product;
                }

            }
            catch (Exception ex)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }
    }
}
