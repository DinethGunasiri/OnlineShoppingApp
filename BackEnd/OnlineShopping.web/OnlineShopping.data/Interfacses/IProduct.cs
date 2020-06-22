using OnlineShopping.data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.data.Interfacses
{
    public interface IProduct
    {
        // Get all Products
        Task<List<Product>> GetProducts();

        // Get Product by Id
        Task<Product> GetPrductByID(int id);

        // Get Product by name
        Task<List<Product>> GetProductByName(string name);

        // Get Products by Category
        Task<List<Product>> GetProductsByCategory(int category);

        // Add Products
        Task<Product> AddProduct(Product product);

        // Edit Product
        Task<Product> EditProduct(int id, Product product);

        // Delete Product
        Task<Product> DeleteProduct(int id);


    }
}
