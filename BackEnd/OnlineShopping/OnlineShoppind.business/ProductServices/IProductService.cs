using OnlineShoppind.Business.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShoppind.Business.ProductServices
{
    public interface IProductService
    {
        IEnumerable<ProductDTO> GetProducts();
        ProductDTO GetProductById(int id);
        ProductDTO InsertProduct(ProductDTO product);
        ProductDTO UpdateProduct(int id, ProductDTO product);
        void RemoveProduct(int id);
    }
}
