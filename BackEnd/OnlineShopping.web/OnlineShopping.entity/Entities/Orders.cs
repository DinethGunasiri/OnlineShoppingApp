using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OnlineShopping.data.Entities
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

        public Customer Customer { get; set; }

        [Required]
        public string CustomerId { get; set; }

        public OrderItems OrderItems { get; set; }

        [Required]
        public int OrderItemsId { get; set; }
    }
}
