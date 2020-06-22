using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopping.web.Models
{
    public class ProductViewModel
    {
        public string ProductName { get; set; }

        public string ProductDescription { get; set; }

        public double CurrentPrice { get; set; }

        public int CategoryId { get; set; }
    }
}
