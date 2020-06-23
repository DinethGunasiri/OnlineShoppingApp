using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopping.service.Models
{
    public class OrderItemsModel
    {
        public int ItemId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public double PurchasePrice { get; set; }
    }
}
