using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OnlineShopping.Data.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        [StringLength(255)]
        public string ProductName { get; set; }

        [Required]
        [StringLength(2000)]
        public string ProductDescription { get; set; }

        [Required]
        public double CurrentPrice { get; set; }

        public ProductCategory Category { get; set; }

        public double Discount { get; set; }

        [Required]
        public int CategoryId { get; set; }
    }
}
