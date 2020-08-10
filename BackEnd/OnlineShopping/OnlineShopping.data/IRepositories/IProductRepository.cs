using OnlineShopping.data.IRepositories;
using OnlineShopping.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShopping.Data.IRepositories
{
    public interface IProductRepository : IRepository<Product>
    {
        IEnumerable<Product> GetProducts();
        Product GetProductById(int id);
        Product InsertProduct(Product product);
        Product UpdateProduct(Product product);
        void RemoveProduct(int id);
        void Save();
    }
}
