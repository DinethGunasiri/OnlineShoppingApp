using Microsoft.EntityFrameworkCore;
using OnlineShopping.data;
using OnlineShopping.Data.IRepositories;
using OnlineShopping.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace OnlineShopping.Data.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ShoppingContext context) : base(context)
        {

        }
        public Product GetProductById(int id)
        {
            return context.Products.Find(id);
        }

        public IEnumerable<Product> GetProducts()
        {
            return context.Products.ToList();
        }

        public Product InsertProduct(Product product)
        {
            context.Products.Add(product);
            return product;
        }

        public void RemoveProduct(int id)
        {
            Product product = context.Products.Find(id);
            context.Products.Remove(product);
        }
        public Product UpdateProduct(Product product)
        {
            context.Entry(product).State = EntityState.Modified;
            return product;
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
