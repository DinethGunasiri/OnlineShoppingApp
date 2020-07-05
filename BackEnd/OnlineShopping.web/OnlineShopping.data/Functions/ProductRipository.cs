using Microsoft.EntityFrameworkCore;
using OnlineShopping.data.DataContext;
using OnlineShopping.data.Entities;
using OnlineShopping.data.Interfacses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.data.Functions
{
    public class ProductRipository : IProduct
    {        

        // Add Product
        public async Task<Product> AddProduct(Product product)
        {
           using(var context = new ShoppingContext(ShoppingContext.ops.dbOptions))
            {
              //  System.Diagnostics.Debug.WriteLine(product);

                await context.Products.AddAsync(product);
                await context.SaveChangesAsync();
            }

            return product;
        }

        // Delete Product

        public async Task<Product> DeleteProduct(int id)
        {
            var product = new Product();

            using(var _context = new ShoppingContext(ShoppingContext.ops.dbOptions))
            {
                product = await _context.Products.SingleOrDefaultAsync(c => c.ProductId == id);
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
            return product;
        }

        // Edit Product
        public async Task<Product> EditProduct(int id, Product product)
        {
            var productDetails = new Product();

            using(var _context = new ShoppingContext(ShoppingContext.ops.dbOptions))
            {
                productDetails = await _context.Products.SingleOrDefaultAsync(c => c.ProductId == id);

                if (productDetails != null)
                {
                    productDetails.ProductName = product.ProductName;
                    productDetails.ProductDescription = product.ProductDescription;
                    productDetails.CurrentPrice = product.CurrentPrice;
                    productDetails.CategoryId = product.CategoryId;

                    await _context.SaveChangesAsync();
                }
            }       
            return productDetails;
        }

        // Get Product by Id
        public async Task<Product> GetPrductByID(int id)
        {
            var product = new Product();

            using (var _context = new ShoppingContext(ShoppingContext.ops.dbOptions))
            {
                product = await _context.Products.SingleOrDefaultAsync(c => c.ProductId == id);
                
            }
            return product;
        }

        // Get Product by name
        public async Task<List<Product>> GetProductByName(string name)
        {
            List<Product> products = new List<Product>();
            List<Product> productList = new List<Product>();

            using(var _context = new ShoppingContext(ShoppingContext.ops.dbOptions))
            {
                products = await _context.Products.ToListAsync();

                foreach(var product in products)
                {
                    if(product.ProductName == name)
                    {
                        productList.Add(product);
                    }
                }
            }
            return productList;
        }

        // Get all Products
        public async Task<List<Product>> GetProducts()
        {
            
            List<Product> products = new List<Product>();

            using(var _context = new ShoppingContext(ShoppingContext.ops.dbOptions))
            {
                products = await _context.Products.ToListAsync();
            }
            return products;
        }

        // Get Product by category
        public async Task<List<Product>> GetProductsByCategory(int category)
        {
            List<Product> products = new List<Product>();
            List<Product> productList = new List<Product>();

            using(var _context = new ShoppingContext(ShoppingContext.ops.dbOptions))
            {
                products = await _context.Products.ToListAsync();

                foreach(var product in products)
                {
                    if(product.CategoryId == category)
                    {
                        productList.Add(product);
                    }
                }
            }
            return productList;
        }
    }
}
