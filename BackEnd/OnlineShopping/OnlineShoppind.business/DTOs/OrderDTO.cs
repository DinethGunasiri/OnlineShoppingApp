using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShoppind.Business.DTOs
{
    public class OrderDTO
    {
        public int OrderId { get; set; }

        public DateTime OrderDate { get; set; }

        public string ShippingAddress { get; set; }

        public double TotalPrice { get; set; }

        public string PaymentType { get; set; }

        public string CustomerId { get; set; }
    }
}
