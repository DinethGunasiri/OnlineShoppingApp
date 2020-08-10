using OnlineShopping.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShoppind.Business.DTOs
{
    public class ProductDTO
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public string ProductDescription { get; set; }

        public double CurrentPrice { get; set; }

        public double Discount { get; set; }

        public int CategoryId { get; set; }
    }
}
