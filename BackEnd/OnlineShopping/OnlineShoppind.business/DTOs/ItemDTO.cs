using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShoppind.Business.DTOs
{
    public class ItemDTO
    {
        public int ItemId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public double PurchasePrice { get; set; }

        public int OrderId { get; set; }
    }
}
