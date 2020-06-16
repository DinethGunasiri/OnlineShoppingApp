using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ShoppingApp.common
{
    public class OrderItems
    {
        [Key]
        public int ItemId { get; set; }

        [Required]
        public Product Product { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        public int Quantity { get; set; }
        
        [Required]
        public double PurchasePrice { get; set; }

      
    }
}
