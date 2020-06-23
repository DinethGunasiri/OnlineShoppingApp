using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopping.service.Models
{
    public class OrderViewModel
    {
        public int OrderId { get; set; }

        public DateTime OrderDate { get; set; }

        public string ShippingAddress { get; set; }

        public string CustomerId { get; set; }

        public int OrderItemsId { get; set; }
    }
}
