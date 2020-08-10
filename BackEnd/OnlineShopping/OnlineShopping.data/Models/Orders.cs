using OnlineShopping.data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OnlineShopping.Data.Models
{
    public class Orders
    {
        [Key]
        public int OrderId { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        [Required]
        [StringLength(200)]
        public string ShippingAddress { get; set; }

        [Required]
        public double TotalPrice { get; set; }

        [Required]
        [StringLength(255)]
        public string PaymentType { get; set; }

        public Customer Customer { get; set; }

        [Required]
        public string CustomerId { get; set; }
    }
}
